using System;
namespace Day5AdventOfCode
{
	public class StackArranger
	{
        public string StackArrangement = @"W B D N C F J
                P Z V Q L S T
                P Z B G J T 
                D T L J Z B H C
                G V B J S
                P S Q
                B V D F L M P N
                P S M F B D L R
                V D T R";
        public Dictionary<int, List<string>> Stacks = new Dictionary<int, List<string>>();

        private List<List<int>> _operations;

        public StackArranger()
		{
            _populateStacks(Stacks, StackArrangement);

            ReadMovements movementReader = new ReadMovements();
            _operations = movementReader.Operations;
        }

        public void Arrange()
        {
            int quantity = 0;
            int location = 1;
            int destination = 2;

            foreach(var operation in _operations)
            {
                _moveStack(operation[quantity], operation[location], operation[destination]);
            }

            _printCurrentStackArrangement();
        }

        public string GetTopBoxesOfStacks()
        {
            var topBoxes = "";
            foreach(var stack in Stacks)
            {
                topBoxes = topBoxes + stack.Value.Last();
            }

            return topBoxes;
        }

        private void _moveStack(int quantity, int location, int destination)
        {
            int stackBottom = Stacks[location].Count() - quantity;

            var stack = Stacks[location].GetRange(stackBottom, quantity);
            Stacks[destination].AddRange(stack);
            Stacks[location].RemoveRange(stackBottom, quantity);
        }

        private void _moveBoxes(int quantity, int location, int destination)
        {
            for(int boxNumber = 0; boxNumber < quantity; boxNumber++)
            {
                _moveBox(location, destination);
            }
        }

        private void _moveBox(int location, int destination)
        {
            Stacks[destination].Add(Stacks[location].Last());
            Stacks[location].RemoveAt(Stacks[location].Count() - 1);
        }

        private void _populateStacks(Dictionary<int, List<string>> stacks, string stackArrangement)
        {
            var DividedStacks = stackArrangement.Split('\n');
            var stackNum = 1;
            foreach(var DividedStack in DividedStacks)
            {
                var cleanStack = DividedStack.Trim();
                var stack = new List<string>(cleanStack.Split(' '));
                stacks.Add(stackNum, stack);
                stackNum++;
            }
        }

        private void _printCurrentStackArrangement()
        {
            foreach (var stack in Stacks)
            {
                string printString = "";
                foreach (var box in stack.Value)
                {
                    printString = printString + box;
                }
                Console.WriteLine(printString);
            }
        }
    }
}

