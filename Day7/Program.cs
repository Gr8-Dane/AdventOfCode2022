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
        foreach(var size in sizes)
        {
            if(size <= 100000)
            {
                totalSize += size;
            }
        }

        Console.WriteLine(totalSize);
    }
}