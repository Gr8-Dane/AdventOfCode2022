using System;
namespace Day7
{
	public class ReadTerminal
	{
        public List<string> InputOutputs { get; private set; }
        private string[] _text;

        public ReadTerminal()
		{
            _text = System.IO.File.ReadAllLines(@"TerminalInputOutput.txt");
            InputOutputs = new List<string>(_text);
        }
        public string[] GetText { get { return _text; } }
    }
}



