using Day_5;
using System.Text;

CrateFileParser parser = new CrateFileParser();

parser.ReadFromFile("input.txt");

for (int i = 0; i < parser.MoveInstructions.Count; i++)
{
  MoveInstruction instruction = parser.MoveInstructions[i];

  for (int j = 0; j < instruction.Amount; j++)
  {
    if (parser.Stacks == null) break;

    parser.Stacks[instruction.ToIndex-1].Items.Push(parser.Stacks[instruction.FromIndex-1].Items.Pop());

  }

}

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
