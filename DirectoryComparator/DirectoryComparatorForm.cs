using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DirectoryComparator.data;
using DrHydra.data;

namespace DirectoryComparator
{
    public partial class DirectoryComparatorForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private ComparableFolder _healthyComparableFolder;
        private ComparableFolder _obscureComparableFolder;
        private Analyzer _analyzer;
        private readonly BackgroundWorker _worker;
        private readonly BackgroundWorker _filterer;
        private TreeNode _topNode;
        private bool _expanded = true;

        public DirectoryComparatorForm()
        {
            InitializeComponent();
            treeView1.ImageList = imageList1;
            barButtonItemAnalyze.Enabled = false;
            barButtonItemExpandCollapse.Enabled = false;
            barButtonItemFilter.Enabled = false;
            
            _worker = new BackgroundWorker {WorkerReportsProgress = true};
            _worker.ProgressChanged += worker_ProgressChanged;
            _worker.DoWork += worker_DoWork;
            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            _filterer = new BackgroundWorker { WorkerReportsProgress = true };
            _filterer.ProgressChanged += filterer_ProgressChanged;
            _filterer.DoWork += filterer_DoWork;
            _filterer.RunWorkerCompleted += filterer_RunWorkerCompleted;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BuildTreeView(_topNode);
            InitComboBox1();
            InitComboBox2();
            barButtonItemExpandCollapse.Enabled = true;
            barButtonItemFilter.Enabled = true;
            barButtonItemAnalyze.Enabled = true;
            barButtonItemExpandCollapse.Enabled = true;
            barButtonItemFilter.Enabled = true;
            barButtonItemObscure.Enabled = true;
            barButtonItemHealthy.Enabled = true;
            Cursor.Current = Cursors.Default;
            barEditItemProgress.EditValue = 0;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            barEditItemProgress.EditValue = e.ProgressPercentage;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _worker.ReportProgress(1);
            var healthyThread = new Thread(TreeBuilderDoWork);
            var obscureThread = new Thread(TreeBuilderDoWork);
            healthyThread.Start(_healthyComparableFolder);
            obscureThread.Start(_obscureComparableFolder);
            healthyThread.Join();
            _worker.ReportProgress(25);
            obscureThread.Join();
            _worker.ReportProgress(50);
            _analyzer = new Analyzer(_healthyComparableFolder, _obscureComparableFolder);
            _topNode = _analyzer.Analyze(_worker);
            _worker.ReportProgress(100);
        }

        private void TreeBuilderDoWork(object folder)
        {
            var comparableFolder = (ComparableFolder) folder;
            comparableFolder.BuildTree();
        }

        private void filterer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BuildTreeView(_topNode);
            barButtonItemExpandCollapse.Enabled = true;
            barButtonItemFilter.Enabled = true;
            barButtonItemAnalyze.Enabled = true;
            barButtonItemExpandCollapse.Enabled = true;
            barButtonItemFilter.Enabled = true;
            barButtonItemObscure.Enabled = true;
            barButtonItemHealthy.Enabled = true;
            Cursor.Current = Cursors.Default;
            barEditItemProgress.EditValue = 0;
        }

        private void filterer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            barEditItemProgress.EditValue = e.ProgressPercentage;
        }

        private void filterer_DoWork(object sender, DoWorkEventArgs e)
        {
            var fileStatesStrings = repositoryItemCheckedComboBoxEdit1.Items.GetCheckedValues().Select(x => x.ToString()).ToList();
            var fileStates = new List<FileState>();

            foreach (var s in fileStatesStrings)
            {
                Enum.TryParse(s, out FileState fileState);
                fileStates.Add(fileState);
            }

            var extensions = repositoryItemCheckedComboBoxEdit2.Items.GetCheckedValues().Select(x => x.ToString()).ToList();
            _topNode = _analyzer.Filter(fileStates, extensions, _filterer);
        }

        private void barButtonItemHealthy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dialogResult = folderBrowserDialogHealthy.ShowDialog(this);

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            _healthyComparableFolder = new ComparableFolder(folderBrowserDialogHealthy.SelectedPath);

            if (_obscureComparableFolder != null)
            {
                barButtonItemAnalyze.Enabled = true;
            }

            barStaticItemHealthy.Caption = "Healthy:  " + folderBrowserDialogHealthy.SelectedPath;
        }

        private void barButtonItemObscure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dialogResult = folderBrowserDialogObscure.ShowDialog(this);

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            _obscureComparableFolder = new ComparableFolder(folderBrowserDialogObscure.SelectedPath);

            if (_healthyComparableFolder != null)
            {
                barButtonItemAnalyze.Enabled = true;
            }

            barStaticItemObscure.Caption = "Obscure: " + folderBrowserDialogObscure.SelectedPath;
        }

        private void barButtonItemAnalyze_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_healthyComparableFolder == null)
            {
                MessageBox.Show("Healthy path not set");
                return;
            }

            if (_obscureComparableFolder == null)
            {
                MessageBox.Show("Obscure path not set");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            barButtonItemAnalyze.Enabled = false;
            barButtonItemExpandCollapse.Enabled = false;
            barButtonItemFilter.Enabled = false;
            barButtonItemObscure.Enabled = false;
            barButtonItemHealthy.Enabled = false;
            _worker.RunWorkerAsync();
        }

        private void InitComboBox1()
        {
            var list = new List<string>()
            {
                "Ok",
                "Missing",
                "Edited",
                "Additional"
            };

            repositoryItemCheckedComboBoxEdit1.DataSource = list;

            foreach (CheckedListBoxItem item in repositoryItemCheckedComboBoxEdit1.Items)
            {
                item.CheckState = CheckState.Checked;
            }
        }

        private void InitComboBox2()
        {
            var list = new List<string>();

            if (_healthyComparableFolder == null || _obscureComparableFolder == null)
            {
                return;
            }

            GetFileExtensions(_healthyComparableFolder, list);
            GetFileExtensions(_obscureComparableFolder, list);

            repositoryItemCheckedComboBoxEdit2.DataSource = list;

            foreach (CheckedListBoxItem item in repositoryItemCheckedComboBoxEdit2.GetItems())
            {
                item.CheckState = CheckState.Checked;
            }
        }


        private void GetFileExtensions(ComparableFolder folder, ICollection<string> list)
        {
            foreach (var file in folder.Files)
            {
                if (list.Contains(file.Extension)) continue;
                list.Add(file.Extension);
            }

            foreach (var folderFolder in folder.Folders)
            {
                GetFileExtensions(folderFolder, list);
            }
        }

        private void barButtonItemFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(_analyzer == null) return;

            Cursor.Current = Cursors.WaitCursor;
            barButtonItemAnalyze.Enabled = false;
            barButtonItemExpandCollapse.Enabled = false;
            barButtonItemFilter.Enabled = false;
            barButtonItemObscure.Enabled = false;
            barButtonItemHealthy.Enabled = false;
            _filterer.RunWorkerAsync();
        }

        private void BuildTreeView(TreeNode topNode)
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(topNode);
            treeView1.EndUpdate();
            treeView1.ExpandAll();
            _expanded = true;
        }

        private void barButtonItemExpandCollapse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_expanded)
            {
                treeView1.CollapseAll();
            }
            else
            {
                treeView1.ExpandAll();
            }

            _expanded = !_expanded;
        }
    }
}
