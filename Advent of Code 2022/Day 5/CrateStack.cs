using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
  internal class CrateStack
  {
    public int Index { get; set; }
    
    public Stack<String> Items { get; set; } = new Stack<String>();

    public static CrateStack Reverse(CrateStack stack)
    {
      CrateStack RevStack = new CrateStack();
      RevStack.Index = stack.Index;

      //Reverse order of items in stack
      foreach (string item in stack.Items)
      {
        RevStack.Items.Push(stack.Items.Pop());
      }

      return RevStack;
    }

    private void InternalAddToStack(string s)
    {
      Items.Push(s);
    }

    public void AddFormattedItemToStack(string s)
    {
      if (s.Substring(1, 1).Equals(" "))
        return;

      else
        InternalAddToStack(s.Substring(1, 1));
    }
  }
}
