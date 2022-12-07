using System;
using System.IO;

namespace Day7
{
	public class DirectoryDoesntExistException : Exception
	{
		public DirectoryDoesntExistException(string message) : base(message)
		{

		}
	}

    public class DirectoryNavigator
	{
		public List<Directory> PreviousDirectory { get; private set; }
		public Directory CurrentDirectory { get; private set; }
		public List<Directory> KnownDirectories { get; private set; }

		public DirectoryNavigator()
		{
			PreviousDirectory = new List<Directory>();
            KnownDirectories = new List<Directory>();
        }

		public Dictionary<string, int> GetDirectorySizes()
		{
			Dictionary<string, int> DirectorySizes = new Dictionary<string, int>();
			foreach(var directory in KnownDirectories)
			{
				DirectorySizes.Add(directory.Name, directory.GetSize());
			}
			return DirectorySizes;
		}

		public void AddDirectory(string directory)
		{
			CurrentDirectory.AddDirectory(directory);
			if(_unknownDirectory(directory))
			{
				KnownDirectories.Add(CurrentDirectory.Directories.FirstOrDefault(p => p.Name == directory));
			}
		}

		private bool _unknownDirectory(string directory)
		{
            var knownDirectories = KnownDirectories.FindAll(p => p.Name == directory);
            return knownDirectories.Count() == 0;
        }

		public void MoveIntoDirectory(string directory)
		{
			if(CurrentDirectory == null)
			{
				CurrentDirectory = new Directory(directory);
				KnownDirectories.Add(CurrentDirectory);
				return;
			}
			PreviousDirectory.Add(CurrentDirectory);
			CurrentDirectory = CurrentDirectory.Directories.FirstOrDefault(p => p.Name == directory);
			if(CurrentDirectory == null)
			{
				throw new DirectoryDoesntExistException("Directory Doesn't Exist in Current Directory");
			}
		}

		public void MoveOutOfDirectory()
		{
			CurrentDirectory = PreviousDirectory.Last();
			PreviousDirectory.RemoveAt(PreviousDirectory.Count() - 1);
		}

		public void AddFile(string name, int size)
		{
			CurrentDirectory.AddFile(name, size);
		}


    }
}

