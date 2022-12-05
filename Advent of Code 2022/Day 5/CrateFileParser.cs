using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
  internal class CrateFileParser
  {

    public List<CrateStack>? Stacks { get; set; }

    public static CrateFileParser ReadFromFile(string filepath)
    {
      CrateFileParser Instance = new CrateFileParser();
      Instance.Stacks = new List<CrateStack>();

      string FileContents = File.ReadAllText(filepath);

      using (StringReader sr = new(FileContents))
      {
        CrateParseSection CurrentCrateParseSection = CrateParseSection.CrateStacks;

        while (true)
        {
          string? line = sr.ReadLine();
          if (line == null) break;

          switch (CurrentCrateParseSection)
          {
            case CrateParseSection.CrateStacks:
              CrateStackParse(ref Instance, line);
              break;
            case CrateParseSection.CrateMoveInstruction:
              Instance.Stacks = CrateStack.Reverse(Instance);
              break;
            case CrateParseSection.CorrectStackOrder:
              break;
          }
        }

        return Instance;
      }
    }

    private static void CrateStackParse(ref CrateFileParser instance, string line)
    {
      throw new NotImplementedException();
    }
  }
}