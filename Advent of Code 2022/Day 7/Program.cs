using Day_7;

string[] lines = System.IO.File.ReadAllLines("input.txt");

INode CurrentDirectory = RootDirectory.GetInstance();

int lineIndex = 0;


while (lineIndex < lines.Length)
{
  string? line = lines[lineIndex];
  if (line == null) break;

  // Check if cmd
  if (line.StartsWith("$"))
  {
    ExecuteCommand(line.Substring(2));
  }
  else
  {
    Console.WriteLine($"Missed line {line}");
  }

}

int AnswerPart1 = 0;
CalculateAnswer1();

Console.WriteLine($"Answer part 1: {AnswerPart1}");


int AnswerPart2 = 0;

int TotalSpace = 70000000;
int RequiredFreeSpace = 30000000;

int ToDeleteEstimateSize = RequiredFreeSpace - (TotalSpace - RootDirectory.GetInstance().TotalSize);

INode ClosestMatchPart2 = FindClosestDirectory(ToDeleteEstimateSize);

int answerPart2 = ClosestMatchPart2.TotalSize;

Console.WriteLine($"Answer part 2: {answerPart2}");


INode FindClosestDirectory(int toDeleteEstimateSize)
{
  INode result = RootDirectory.GetInstance();

  FindClosestSubDirectory(ref result, RootDirectory.GetInstance(), ToDeleteEstimateSize);

  return result;
}

void FindClosestSubDirectory(ref INode bestMatch, INode Dir, int TargetSize)
{


  foreach (INode item in Dir.Children)
  {
    if (item.TotalSize >= TargetSize && item.TotalSize < bestMatch.TotalSize)
    {
      bestMatch = item;
    }

    FindClosestSubDirectory(ref bestMatch, item, TargetSize);
  }

}

void CalculateAnswer1()
{
  INode root = RootDirectory.GetInstance();


  getAnswer1_OfSubDirectories(root);


}

void getAnswer1_OfSubDirectories(INode Directory)
{
  foreach (INode item in Directory.Children)
  {
    Console.WriteLine(item.Name);
    getAnswer1_OfSubDirectories(item);

  }

  if (Directory.TotalSize <= 100000)
    AnswerPart1 += Directory.TotalSize;

}

void ExecuteCommand(string cmd)
{
  if (cmd.StartsWith("cd"))
  {
    ExecuteCurrentDirectoryCommand(cmd.Split(" ")[1]);
  }
  else if (cmd.StartsWith("ls"))
  {
    ExecuteListCommand();
  }
}

void ExecuteListCommand()
{
  lineIndex++;

  AddChildren();

}

void AddChildren()
{
  string CurrentLine = lines[lineIndex];

  while (CurrentLine.StartsWith("$") != true)
  {
    if (CurrentLine.StartsWith("dir"))
    {
      ElfDirectory SubDir = new ElfDirectory(CurrentDirectory, CurrentLine.Split(" ")[1]);
      SubDir.Parent = CurrentDirectory;
      CurrentDirectory.Children.Add(SubDir);
    }
    else
    {
      ElfFile File = new ElfFile()
      {
        Size = int.Parse(CurrentLine.Split(" ")[0]),
        Name = CurrentLine.Split(" ")[1]
      };

      CurrentDirectory.Files.Add(File);

    }

    lineIndex++;
    if (lineIndex >=lines.Length)
    {
      break;
    }
    CurrentLine = lines[lineIndex];
  }
}

void ExecuteCurrentDirectoryCommand(string dir)
{
  if (dir.Equals("/"))
  {
    CurrentDirectory = RootDirectory.GetInstance();
  }
  else if (dir.Equals(".."))
  {
    CurrentDirectory = CurrentDirectory.Parent!;
  }
  else
  {
    var result = CurrentDirectory.Children.Find(T => T.Name.Equals(dir));

    if (result == null)
    {
      return;
    }
    CurrentDirectory = result;
  }

  lineIndex++;
}