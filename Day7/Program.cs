using Day7;

public class Program
{
    static void Main()
    {
        var commandReader = new ReadTerminal();
        var commands = commandReader.InputOutputs;

        var processor = new TerminalCommandProcessor();
        processor.ProcessCommands(commands);
        var sizes = processor.GetDirectorySizes();

        int totalSize = 0;
        foreach(KeyValuePair<string, int> pair in sizes)
        {
            if(pair.Value < 100000)
            {
                totalSize += pair.Value;
            }
        }

        Console.WriteLine(totalSize);
    }
}