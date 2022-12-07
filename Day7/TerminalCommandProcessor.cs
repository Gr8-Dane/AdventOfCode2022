using System;
namespace Day7
{
	public class TerminalCommandProcessor
	{
		private int _numDirs = 0;

		DirectoryNavigator directoryNavigator;
		private TerminalInputOutput terminalLines;

		public TerminalCommandProcessor()
		{
			directoryNavigator = new DirectoryNavigator();
		}

		public  List<int> GetDirectorySizes()
		{
			return directoryNavigator.GetDirectorySizes();
		}

		public void ProcessCommands(List<string> inputOutputs)
		{
            terminalLines = new TerminalInputOutput(inputOutputs);

            while (terminalLines.NextLine())
			{
				if (terminalLines.CurrentLine.Contains("$"))
				{
					_executeCommand(terminalLines.CurrentLine.Split(' '));
				}
            }
			Console.WriteLine("Number of Directories Encounter = " + _numDirs);
			Console.WriteLine("Number of Directories Actually Added = " + directoryNavigator.NumDirs);
		}

		private void _executeCommand(string[] command)
		{
			switch(command[1])
			{
				case "cd":
					_changeDirectoryTo(command[2]);
					break;
				case "ls":
                    _listDirectoriesAndFiles();
					break;
            }
		}

		private void _changeDirectoryTo(string directory)
		{
			if(directory == "..")
			{
				directoryNavigator.MoveOutOfDirectory();
				return;
			}

			directoryNavigator.MoveIntoDirectory(directory);
		}

		private void _listDirectoriesAndFiles()
		{
            var retVal = terminalLines.NextLine();
			while (!terminalLines.CurrentLine.Contains("$") && retVal == true)
			{
				var pieces = terminalLines.CurrentLine.Split(' ');
				if (pieces[0] == "dir")
				{
					directoryNavigator.AddDirectory(pieces[1]);
					_numDirs++;
				}
				else
				{
					directoryNavigator.AddFile(pieces[1], int.Parse(pieces[0]));
				}
				retVal = terminalLines.NextLine();
			}
			terminalLines.MovePosition(-1);
		}
    }
}

