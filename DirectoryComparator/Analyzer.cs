using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DirectoryComparator.data;
using DrHydra.data;

namespace DirectoryComparator
{
    class Analyzer
    {
        private ComparableFolder _obscureFolder;
        private ComparableFolder _analyzedFolder;
        private ComparableFolder _filteredFolder;
        private TreeNode _treeNode;

        public Analyzer(ComparableFolder healthyFolder, ComparableFolder obscureFolder)
        {
            _obscureFolder = obscureFolder;
            _analyzedFolder = new ComparableFolder(healthyFolder.FolderPath);
            _analyzedFolder.BuildTree();
        }

        public TreeNode Analyze(BackgroundWorker worker)
        {
            SetFileStates(_analyzedFolder, _obscureFolder);
            return ConvertHydraFolderToNodeTree(_analyzedFolder, worker);
        }

        private TreeNode ConvertHydraFolderToNodeTree(ComparableFolder comparableFolder, BackgroundWorker worker)
        {
            var folderCount = comparableFolder.Folders.Count;
            var step = 50 / (folderCount + 1);

            _treeNode = new TreeNode(comparableFolder.Name);
            _treeNode.SelectedImageIndex = 4;
            _treeNode.ImageIndex = 4;

            foreach (var file in comparableFolder.Files)
            {
                CreateChildTreeNode(_treeNode, file);
            }

            worker.ReportProgress(50 + 1*step);
            Application.DoEvents();

            for (var index = 0; index < comparableFolder.Folders.Count; index++)
            {
                var folder = comparableFolder.Folders[index];
                var childNode = new TreeNode(folder.Name);
                childNode.ImageIndex = 4;
                childNode.SelectedImageIndex = 4;
                _treeNode.Nodes.Add(childNode);
                ConvertHydraFolderToNodeTree(childNode, folder);
                worker.ReportProgress(50 + step * index);
                Application.DoEvents();
            }

            return _treeNode;
        }

        private void ConvertHydraFolderToNodeTree(TreeNode rootNode, ComparableFolder rootFolder)
        {
            foreach (var file in rootFolder.Files)
            {
                CreateChildTreeNode(rootNode, file);
            }

            foreach (var folder in rootFolder.Folders)
            {
                var childNode = new TreeNode(folder.Name);
                childNode.ImageIndex = 4;
                childNode.SelectedImageIndex = 4;
                rootNode.Nodes.Add(childNode);
                ConvertHydraFolderToNodeTree(childNode, folder);
            }
        }

        private static void CreateChildTreeNode(TreeNode rootNode, ComparableFile file)
        {
            var childNode = new TreeNode(file.Name);

            switch (file.FileState)
            {
                case FileState.Additional:
                    childNode.ImageIndex = 1;
                    childNode.SelectedImageIndex = 1;
                    break;
                case FileState.Missing:
                    childNode.SelectedImageIndex = 2;
                    childNode.ImageIndex = 2;
                    break;
                case FileState.Edited:
                    childNode.SelectedImageIndex = 3;
                    childNode.ImageIndex = 3;
                    break;
                default:
                    childNode.SelectedImageIndex = 0;
                    childNode.ImageIndex = 0;
                    break;
            }

            rootNode.Nodes.Add(childNode);
        }

        private void SetFileStates(ComparableFolder analyzed, ComparableFolder obscure)
        {
            foreach (var file in analyzed.Files)
            {
                var correspondingFile = obscure.Files.SingleOrDefault(x => x.Name.Equals(file.Name));

                if (correspondingFile == null)
                {
                    file.FileState = FileState.Missing;
                    continue;
                }

                if (!correspondingFile.Hash.Equals(file.Hash))
                {
                    file.FileState = FileState.Edited;
                    continue;
                }

                file.FileState = FileState.Ok;
            }

            foreach (var file in obscure.Files.Where(x => !analyzed.Files.Any(y => x.Name.Equals(y.Name))))
            {
                file.FileState = FileState.Additional;
                analyzed.Files.Add(file);
            }

            foreach (var folder in analyzed.Folders)
            {
                var correspondingFolder = obscure.Folders.FirstOrDefault(x => x.Name.Equals(folder.Name));

                if (correspondingFolder == null)
                {
                    SetFileStateOfMissingFolder(folder);
                    continue;
                }

                SetFileStates(folder, correspondingFolder);
            }

            foreach (var folder in obscure.Folders.Where(x => !analyzed.Folders.Any(y => x.Name.Equals(y.Name))))
            {
                var additionalFolder = CreateAdditionalFolder(folder);
                analyzed.Folders.Add(additionalFolder);
            }
        }

        private ComparableFolder CreateAdditionalFolder(ComparableFolder folder)
        {
            var additionalFolder = new ComparableFolder(folder.FolderPath);

            foreach (var file in folder.Files)
            {
                file.FileState = FileState.Additional;
                additionalFolder.Files.Add(file);
            }

            foreach (var folderFolder in folder.Folders)
            {
                var additionalFolderFolder = CreateAdditionalFolder(folderFolder);
                additionalFolder.Folders.Add(additionalFolderFolder);
            }

            return additionalFolder;
        }

        private void SetFileStateOfMissingFolder(ComparableFolder folder)
        {
            foreach (var file in folder.Files)
            {
                file.FileState = FileState.Missing;
            }

            foreach (var folderOfFolder in folder.Folders)
            {
                SetFileStateOfMissingFolder(folderOfFolder);
            }
        }

        public TreeNode Filter(List<FileState> fileStates, List<string> extensions, BackgroundWorker worker)
        {
            _filteredFolder = new ComparableFolder(_analyzedFolder);
            worker.ReportProgress(0);
            FilterTreeNode(_filteredFolder, fileStates, extensions);
            worker.ReportProgress(50);
            return ConvertHydraFolderToNodeTree(_filteredFolder, worker);
        }

        private void FilterTreeNode(ComparableFolder rootFolder, List<FileState> fileStates, List<string> extensions)
        {
            rootFolder.Files.RemoveAll(x => !fileStates.Contains(x.FileState) || !extensions.Contains(x.Extension));

            foreach (var folder in rootFolder.Folders)
            {
                FilterTreeNode(folder, fileStates, extensions);
            }
        }
    }
}
