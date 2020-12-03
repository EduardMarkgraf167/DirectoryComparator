using System.Collections.Generic;
using System.IO;
using System.Linq;
using DrHydra.data;

namespace DirectoryComparator.data
{
    class ComparableFolder
    {
        public ComparableFolder(string path)
        {
            FolderPath = path;
            Name = path.Split(Path.DirectorySeparatorChar).Last();
            Folders = new List<ComparableFolder>();
            Files = new List<ComparableFile>();
        }

        public ComparableFolder(ComparableFolder originalFolder)
        {
            var copiedNode = new ComparableFolder(originalFolder.FolderPath);
            Name = copiedNode.Name;
            FolderPath = copiedNode.FolderPath;
            Copy(originalFolder, copiedNode);
            Folders = copiedNode.Folders;
            Files = copiedNode.Files;
        }

        public string Name { get; } 
        public string FolderPath { get; }
        public List<ComparableFolder> Folders { get; private set; }
        public List<ComparableFile> Files { get; private set; }

        private void BuildTree(ComparableFolder rootFolder)
        {
            var files = Directory.GetFiles(rootFolder.FolderPath);
            rootFolder.Files = files.Select(x => new ComparableFile(x)).ToList();

            foreach (var path in Directory.GetDirectories(rootFolder.FolderPath))
            {
                var folder = new ComparableFolder(path);
                rootFolder.Folders.Add(folder);
                BuildTree(folder);
            }
        }

        public void BuildTree()
        {
            var thisFolder = new ComparableFolder(FolderPath);
            BuildTree(thisFolder);
            Files = thisFolder.Files;
            Folders = thisFolder.Folders;
        }

        private void Copy(ComparableFolder original, ComparableFolder copied)
        {
            foreach (var file in original.Files)
            {
                var copiedFile = new ComparableFile(file.FilePath) { FileState = file.FileState };
                copied.Files.Add(copiedFile);
            }

            foreach (var folder in original.Folders)
            {
                var copiedFolder = new ComparableFolder(folder.FolderPath);
                copied.Folders.Add(copiedFolder);
                Copy(folder, copiedFolder);
            }
        }
    }
}
