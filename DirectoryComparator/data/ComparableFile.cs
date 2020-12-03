using System.IO;
using System.Linq;
using DrHydra;
using DrHydra.data;

namespace DirectoryComparator.data
{
    class ComparableFile
    {
        public ComparableFile(string path)
        {
            Name = path.Split(Path.DirectorySeparatorChar).Last();
            FilePath = path;
            Hash = ComputeHashOfFile();
            Extension = Name.Split('.').Last();
        }

        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Extension { get; set; }
        public string Hash { get; set; }
        public FileState FileState { get; set; }

        private string ComputeHashOfFile()
        {
            var file = File.ReadAllText(FilePath);
            return HashUtils.GetHashString(file);
        }
    }
}
