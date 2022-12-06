using Day_5;
using System.Text;

CrateFileParser parser = new CrateFileParser();

parser.ReadFromFile("input.txt");

// SolvePart1();
SolvePart2();


PrintStackTops(parser.Stacks);







void PrintStackTops(List<CrateStack>? stacks)
{
  Console.Clear();
  if (stacks == null) return;

  StringBuilder sb = new StringBuilder();

  for (int i = 0; i < stacks.Count; i++)
  {
    sb.Append($"{stacks[i].Items.Pop()}");
  }
  Console.WriteLine(sb.ToString());

}

Console.WriteLine("end");

void SolvePart1()
{
  for (int i = 0; i < parser.MoveInstructions.Count; i++)
  {
    MoveInstruction instruction = parser.MoveInstructions[i];

    for (int j = 0; j < instruction.Amount; j++)
    {
      if (parser.Stacks == null) break;

      // Part 1
      parser.Stacks[instruction.ToIndex - 1].Items.Push(parser.Stacks[instruction.FromIndex - 1].Items.Pop());

    }

  }
}

void SolvePart2()
{
  for (int i = 0; i < parser.MoveInstructions.Count; i++)
  {
    MoveInstruction instruction = parser.MoveInstructions[i];

    Stack<string> Crane = new Stack<string>();

    for (int j = 0; j < instruction.Amount; j++)
    {
      if (parser.Stacks == null) break;

      Crane.Push(parser.Stacks[instruction.FromIndex - 1].Items.Pop());

    }
    for (int j = 0; j < instruction.Amount; j++)
    {
      if (parser.Stacks == null) break;

      parser.Stacks[instruction.ToIndex - 1].Items.Push(Crane.Pop());


    }

  }
}
