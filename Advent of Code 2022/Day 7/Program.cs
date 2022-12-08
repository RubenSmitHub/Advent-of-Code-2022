using Day_7;

RootDirectory root = RootDirectory.GetInstance();

string FileContents = System.IO.File.ReadAllText("input.txt");

INode currentDirectory = root;

StringReader sr = new(FileContents);


while (true)
{
  string? line = sr.ReadLine();
  if (line == null) break;

  // Check if cmd
  if (line.StartsWith("$"))
  {
    ExecuteCommand(line[2..]);
  }

}
Console.WriteLine($"total size {root.TotalSize}");

void ExecuteCommand(string cmd)
{
  if (cmd.StartsWith("cd"))
  {
    ExecuteCurrentDirectoryCommand(cmd.Split(" ")[0], cmd.Split(" ")[1..]);
  }
  else if (cmd.StartsWith("ls"))
  {
    ExecuteListDirectoryCommand();
  }
}

void ExecuteListDirectoryCommand()
{
  while (true)
  {
    string? line = sr.ReadLine();
    if (line == null) break;
 
    string type = line.Split(" ")[0];
    if (type == "$") break;
    if (type == "dir")
    {
      Day_7.Directory dir = new Day_7.Directory(currentDirectory, line.Split(" ")[1]);
      currentDirectory.Children.Add(dir);

    }
    else
    {
      Day_7.File file = new Day_7.File() 
      { 
        Name = line.Split(" ")[1], 
        Size = int.Parse(line.Split(" ")[0])
      };
      currentDirectory.Files.Add(file);

    }
  }
}


void ExecuteCurrentDirectoryCommand(string cmd, string[] args)
{
  string name = args[0];

  if (name == "..")
  {
    currentDirectory = currentDirectory.Parent;

  }else if (name == "/")
  {
    currentDirectory = RootDirectory.GetInstance();
  }else
  {
    currentDirectory = currentDirectory.Children.FirstOrDefault(x => x.Name == name);

  }
}