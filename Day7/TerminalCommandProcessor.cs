using System;
namespace Day7
{
	public class TerminalCommandProcessor
	{
		DirectoryNavigator directoryNavigator;
		private TerminalInputOutput terminalLines;

		public TerminalCommandProcessor()
		{
			directoryNavigator = new DirectoryNavigator();
		}

		public Dictionary<string, int> GetDirectorySizes()
		{
			return directoryNavigator.GetDirectorySizes();
		}

		public void ProcessCommands(List<string> inputOutputs)
		{
            terminalLines = new TerminalInputOutput(inputOutputs);

            while (terminalLines.NextLine())
			{
				var inputOutputElements = terminalLines.CurrentLine.Split(' ');

				if (inputOutputElements[0] == "$")
				{
					_executeCommand(inputOutputElements);
				}
            }
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

