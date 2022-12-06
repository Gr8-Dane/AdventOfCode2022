

using Day5AdventOfCode;

public class Program
{


    static void Main()
    {
        var StackArranger = new StackArranger();
        StackArranger.Arrange();
        var topBoxes = StackArranger.GetTopBoxesOfStacks();
        Console.WriteLine(topBoxes);
    }


}
