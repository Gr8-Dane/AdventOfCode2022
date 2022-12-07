using System;
namespace Day7
{
	public class TerminalInputOutput
	{
		public List<string> InputsOutputs { get; private set; }
		int index = 0;
		int size = 0;
		public string CurrentLine { get; private set; }

		public TerminalInputOutput(List<string> inputOutputs)
		{
			InputsOutputs = inputOutputs;
			size = inputOutputs.Count();
		}

		public bool NextLine()
		{
			if(index == size)
			{
				return false;
			}
			CurrentLine = InputsOutputs[index];
			index++;
			return true;
		}

		public void MovePosition(int increment)
		{
			index += increment;
		}
	}
}

