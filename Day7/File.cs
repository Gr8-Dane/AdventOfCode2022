using System;
namespace Day7
{
	public class File
	{
		public string Name { get; private set; }
		public int Size { get; private set; }
		public File(string name, int size)
		{
			Name = name;
			Size = size;
		}
	}
}

