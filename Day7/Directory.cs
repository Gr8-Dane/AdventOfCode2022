using System;
namespace Day7
{
	public class Directory
	{
		public string Name { get; private set; }
		public List<File> Files { get; private set; }
		public List<Directory> Directories { get; private set; }
		private int _size;

		public Directory(string name)
		{
			Files = new List<File>();
			Directories = new List<Directory>();
			Name = name;
            _size = 0;
		}

		public void AddDirectory(string directory)
		{
			if(_directoryNotAlreadyInDirectory(directory))
			{
				Directories.Add(new Directory(directory));
			}
		}

        private bool _directoryNotAlreadyInDirectory(string name)
        {
            var DirectoriesInDirectoryWithName = Directories.FindAll(p => p.Name == name);
            return DirectoriesInDirectoryWithName.Count() == 0;
        }

        public void AddFile(string name, int size)
		{
			if(_fileNotInFiles(name))
			{
				Files.Add(new File(name, size));
                _size += size;
			}
		}

		private bool _fileNotInFiles(string name)
		{
			var fileInFiles = Files.FindAll(p => p.Name == name);
			return fileInFiles.Count() == 0;
		}

		public int GetSize()
		{
			int totalSize = _size;
			foreach(var directory in Directories)
			{
				totalSize += directory.GetSize();
			}
            _size = totalSize;
			return _size;
		}

	}
}

