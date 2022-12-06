using System.IO;
using System;

namespace Day5AdventOfCode
{
	public class ReadMovements
	{
		private string[] _text;
		public List<List<int>> Operations { get; private set; }

		private int _numberOfBoxesToMove = 1;
		private int _originalStack = 3;
		private int _newStack = 5;

		public ReadMovements()
		{
            Operations = new List<List<int>>();
            _text = File.ReadAllLines(@"Movements.txt");
            _getOperations(_text);
        }

		private void _getOperations(string[] text)
		{
			List<int> operation;
			foreach(var line in text)
			{
				string[] words = line.Split(' ');
				if(words.Count() != 0)
				{
                    operation = new List<int>();
                    operation.Add(int.Parse(words[_numberOfBoxesToMove]));
                    operation.Add(int.Parse(words[_originalStack]));
                    operation.Add(int.Parse(words[_newStack]));
                    Operations.Add(operation);
                }
            }
		}


		public string[] GetText { get { return _text; }}

	}
}

