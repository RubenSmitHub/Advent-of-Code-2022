using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
  public class RootDirectory : ElfDirectory
  {


    private static RootDirectory? _root;

    protected RootDirectory(string name) : base(name)
    {
    }

    public static RootDirectory GetInstance()
    {
      if (_root == null) _root = new RootDirectory("/");
      return _root;
    }



  }
}
