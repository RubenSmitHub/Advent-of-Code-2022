namespace Day_5
{
  internal class CrateFileParser
  {
    public List<CrateStack>? Stacks { get; set; }

    public List<MoveInstruction> MoveInstructions { get; set; } = new List<MoveInstruction>();

    public void ReadFromFile(string filepath)
    {
      string FileContents = File.ReadAllText(filepath);

      using (StringReader sr = new(FileContents))
      {
        CrateParseSection CurrentCrateParseSection = CrateParseSection.CrateStacks;

        while (true)
        {
          int eof = sr.Peek();
          if (eof == -1) break;

          switch (CurrentCrateParseSection)
          {
            case CrateParseSection.CrateStacks:
              ParseAllCrateStacks(sr);
              CurrentCrateParseSection = CrateParseSection.CrateMoveInstruction;
              break;

            case CrateParseSection.CrateMoveInstruction:
              ParseMoveInstruction(sr.ReadLine());
              break;

            default: break;
          }
        }
      }
    }

    private void ParseMoveInstruction(string? v)
    {
      if (v == null) return;

      string formatted = v;
      formatted = formatted.Replace("move ", "");
      formatted = formatted.Replace(" from ", ",");
      formatted = formatted.Replace(" to ", ",");

      string[] values = formatted.Split(",");

      MoveInstruction instruction = new()
      {
        Amount = int.Parse(values[0]),
        FromIndex = int.Parse(values[1]),
        ToIndex = int.Parse(values[2])
      };

      MoveInstructions.Add(instruction);
    }

    private void ParseAllCrateStacks(StringReader sr)
    {
      // Parse the crate string to the stacks

      bool init = false;
      int StackCount = 0;

      while (true)
      {
        string? line = sr.ReadLine();
        if (line == null) return;

        if (init == false)
        {
          // Sample:
          // [A] [B]
          // 1234567
          StackCount = (line.Length + 1) / 4;

          Stacks = new List<CrateStack>(StackCount);
          for (int i = 0; i < StackCount; i++)
          {
            Stacks.Add(new CrateStack());
          }

          if (Stacks.Count == 0)
          {
            return;
          }
          init = true;
        }

        if (line.Equals("\n"))
        {
          return;
        }
        if (line.StartsWith("["))
        {
          for (int i = 0; i < StackCount; i++)
          {
            string FormattedCrate = line.Substring((i * 4) + 1, 1);
            if (FormattedCrate.Equals(" ") == false)
            {
              Stacks?[i].Items.Push(FormattedCrate);
            }
          }
        }
        if (line.StartsWith(" "))
        {
          for (int i = 0; i < StackCount - 1; i++)
          {
            if (Stacks == null) return;
            Stacks[i].Index = int.Parse(line.Substring((i * 4) + 1, 1));
          }
          // read next blanc line
          sr.ReadLine();

          for (int i = 0; i < StackCount; i++)
          {
            if (Stacks == null) break;
            Stacks[i] = CrateStack.Reverse(Stacks[i]);
          }
          return;
        }
      }
    }
  }
}