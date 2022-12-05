using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
  internal class Range
  {
    public int StartIndex { get; set; } = 0;

    public int EndIndex { get; set; } = 0;

    public bool Contains(Range r)
    {
      return (r.StartIndex >= StartIndex & r.EndIndex <= EndIndex);

    }

    public bool Overlaps(Range r)
    {
      if (StartIndex >= r.StartIndex & StartIndex <= r.EndIndex)
      {
        return true;
      }
      if (EndIndex >= r.StartIndex & EndIndex <= r.EndIndex)
      {
        return true;
      }


      return false;

    }

    public bool DoNotOverlap(Range r)
    {
      if (StartIndex < r.StartIndex & EndIndex < r.StartIndex)
      {
        return true;
      }
      if (StartIndex > r.EndIndex & EndIndex > r.EndIndex)
      {
        return true;
      }
      return false;
    }
  }
}
