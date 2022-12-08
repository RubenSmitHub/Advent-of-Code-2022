﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
  public interface INode
  {
    public string Name { get; set; }

    public List<INode> Children { get; set; }

    public List<File> Files { get; set; }
    
    public INode? Parent { get; set; }

    public int TotalSize { get; }

    public bool IsRead { get; set; }

  }
}
