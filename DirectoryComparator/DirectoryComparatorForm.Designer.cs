namespace DirectoryComparator
{
    partial class DirectoryComparatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryComparatorForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemHealthy = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemObscure = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAnalyze = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckedComboBoxEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.barButtonItemFilter = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExpandCollapse = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemHealthy = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemObscure = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItemProgress = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupFilter = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialogHealthy = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialogObscure = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItemHealthy,
            this.barButtonItemObscure,
            this.barButtonItemAnalyze,
            this.barEditItem1,
            this.barEditItem2,
            this.barButtonItemFilter,
            this.barButtonItemExpandCollapse,
            this.barStaticItemHealthy,
            this.barStaticItemObscure,
            this.barEditItemProgress});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckedComboBoxEdit1,
            this.repositoryItemCheckedComboBoxEdit2,
            this.repositoryItemProgressBar1});
            this.ribbonControl1.Size = new System.Drawing.Size(1143, 158);
            // 
            // barButtonItemHealthy
            // 
            this.barButtonItemHealthy.Caption = "Set Healthy Directory";
            this.barButtonItemHealthy.Id = 1;
            this.barButtonItemHealthy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemHealthy.ImageOptions.Image")));
            this.barButtonItemHealthy.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemHealthy.ImageOptions.LargeImage")));
            this.barButtonItemHealthy.Name = "barButtonItemHealthy";
            this.barButtonItemHealthy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemHealthy_ItemClick);
            // 
            // barButtonItemObscure
            // 
            this.barButtonItemObscure.Caption = "Set Obscure Directory";
            this.barButtonItemObscure.Id = 2;
            this.barButtonItemObscure.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemObscure.ImageOptions.Image")));
            this.barButtonItemObscure.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemObscure.ImageOptions.LargeImage")));
            this.barButtonItemObscure.Name = "barButtonItemObscure";
            this.barButtonItemObscure.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemObscure_ItemClick);
            // 
            // barButtonItemAnalyze
            // 
            this.barButtonItemAnalyze.Caption = "Analyze";
            this.barButtonItemAnalyze.Id = 3;
            this.barButtonItemAnalyze.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemAnalyze.ImageOptions.Image")));
            this.barButtonItemAnalyze.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemAnalyze.ImageOptions.LargeImage")));
            this.barButtonItemAnalyze.Name = "barButtonItemAnalyze";
            this.barButtonItemAnalyze.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAnalyze_ItemClick);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "File state";
            this.barEditItem1.Edit = this.repositoryItemCheckedComboBoxEdit1;
            this.barEditItem1.Id = 13;
            this.barEditItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barEditItem1.ImageOptions.Image")));
            this.barEditItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barEditItem1.ImageOptions.LargeImage")));
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "File type ";
            this.barEditItem2.Edit = this.repositoryItemCheckedComboBoxEdit2;
            this.barEditItem2.Id = 14;
            this.barEditItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barEditItem2.ImageOptions.Image")));
            this.barEditItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barEditItem2.ImageOptions.LargeImage")));
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemCheckedComboBoxEdit2
            // 
            this.repositoryItemCheckedComboBoxEdit2.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit2.Name = "repositoryItemCheckedComboBoxEdit2";
            // 
            // barButtonItemFilter
            // 
            this.barButtonItemFilter.Caption = "Fillter";
            this.barButtonItemFilter.Id = 15;
            this.barButtonItemFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemFilter.ImageOptions.Image")));
            this.barButtonItemFilter.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemFilter.ImageOptions.LargeImage")));
            this.barButtonItemFilter.Name = "barButtonItemFilter";
            this.barButtonItemFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemFilter_ItemClick);
            // 
            // barButtonItemExpandCollapse
            // 
            this.barButtonItemExpandCollapse.Caption = "Expand / Collapse";
            this.barButtonItemExpandCollapse.Id = 16;
            this.barButtonItemExpandCollapse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemExpandCollapse.ImageOptions.Image")));
            this.barButtonItemExpandCollapse.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemExpandCollapse.ImageOptions.LargeImage")));
            this.barButtonItemExpandCollapse.Name = "barButtonItemExpandCollapse";
            this.barButtonItemExpandCollapse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExpandCollapse_ItemClick);
            // 
            // barStaticItemHealthy
            // 
            this.barStaticItemHealthy.Caption = "Healthy:  --------------------------------------";
            this.barStaticItemHealthy.Id = 18;
            this.barStaticItemHealthy.Name = "barStaticItemHealthy";
            // 
            // barStaticItemObscure
            // 
            this.barStaticItemObscure.Caption = "Obscure: --------------------------------------";
            this.barStaticItemObscure.Id = 19;
            this.barStaticItemObscure.Name = "barStaticItemObscure";
            // 
            // barEditItemProgress
            // 
            this.barEditItemProgress.Caption = "Progress: ";
            this.barEditItemProgress.Edit = this.repositoryItemProgressBar1;
            this.barEditItemProgress.EditWidth = 150;
            this.barEditItemProgress.Id = 21;
            this.barEditItemProgress.Name = "barEditItemProgress";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.Step = 1;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroupFilter,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Functions";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemAnalyze);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemHealthy);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemObscure);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Main Functions";
            // 
            // ribbonPageGroupFilter
            // 
            this.ribbonPageGroupFilter.ItemLinks.Add(this.barEditItem1);
            this.ribbonPageGroupFilter.ItemLinks.Add(this.barEditItem2);
            this.ribbonPageGroupFilter.ItemLinks.Add(this.barButtonItemFilter);
            this.ribbonPageGroupFilter.Name = "ribbonPageGroupFilter";
            this.ribbonPageGroupFilter.Text = "Filter";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemExpandCollapse);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Visualization";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup3.ItemLinks.Add(this.barStaticItemHealthy);
            this.ribbonPageGroup3.ItemLinks.Add(this.barStaticItemObscure);
            this.ribbonPageGroup3.ItemLinks.Add(this.barEditItemProgress);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Info";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1143, 377);
            this.panel1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(1143, 377);
            this.treeView1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Apply_16x16.png");
            this.imageList1.Images.SetKeyName(1, "Add_16x16.png");
            this.imageList1.Images.SetKeyName(2, "Cancel_16x16.png");
            this.imageList1.Images.SetKeyName(3, "Warning_16x16.png");
            this.imageList1.Images.SetKeyName(4, "BO_Folder.png");
            // 
            // DirectoryComparatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 535);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("DirectoryComparatorForm.IconOptions.LargeImage")));
            this.Name = "DirectoryComparatorForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Directory Comparator";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemHealthy;
        private DevExpress.XtraBars.BarButtonItem barButtonItemObscure;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAnalyze;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemFilter;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogHealthy;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogObscure;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExpandCollapse;
        private DevExpress.XtraBars.BarStaticItem barStaticItemHealthy;
        private DevExpress.XtraBars.BarStaticItem barStaticItemObscure;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarEditItem barEditItemProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
    }
}

