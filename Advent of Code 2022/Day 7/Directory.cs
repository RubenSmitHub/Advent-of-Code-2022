namespace Day_7
{
  public class Directory : INode
  {
    public Directory(INode parent, string name)
    {
      Parent = parent;
      Name = name;
    }

    protected Directory(string name)
    {
      Name = name;
      Parent = null;
    }

    public List<INode> Children { get; set; } = new List<INode>();

    public List<File> Files { get; set; } = new List<File>();

    public bool IsRead { get; set; }

    public string Name { get; set; }

    public INode? Parent { get; set; }

    public int TotalSize
    {
      get
      {
        int totalFromDirectories = (from child in Children select child.TotalSize).Sum();
        int totalFromFiles = (from file in Files select file.Size).Sum();
        return totalFromDirectories + totalFromFiles;
      }
    }
  }
}