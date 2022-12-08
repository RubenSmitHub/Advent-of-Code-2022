using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
  public class RootDirectory : Directory
  {


    private static RootDirectory _root = new RootDirectory("/");

    protected RootDirectory(string name) : base(name)
    {
    }

    public static RootDirectory GetInstance() => _root;

  }
}
