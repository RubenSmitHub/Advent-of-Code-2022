using Day_4;

string FileContents = File.ReadAllText("Input.txt");

int TotalInRange = 0;
int TotalOverlaps = 0;
int TotalNotEverlaps = 0;
int Total = 0;

using (StringReader sr = new(FileContents))
{
  while (true)
  {
    string? Line = sr.ReadLine();
    if (Line == null) break;

    string RangeAText = Line.Split(',')[0];
    string RangeBText = Line.Split(',')[1];

    Day_4.Range a = new()
    {
      StartIndex = int.Parse(RangeAText.Split("-")[0]),
      EndIndex = int.Parse(RangeAText.Split("-")[1])
    };

    Day_4.Range b = new()
    {
      StartIndex = int.Parse(RangeBText.Split("-")[0]),
      EndIndex = int.Parse(RangeBText.Split("-")[1])
    };

    if (a.Contains(b) | b.Contains(a))
    {
      TotalInRange++;
    }

    bool IsOverlapping = false;
    if (a.Overlaps(b))
    {
      TotalOverlaps++;
      IsOverlapping = true;
    }

    bool IsNotOverlapping = false;
    if (a.DoNotOverlap(b))
    {
      TotalNotEverlaps++;
      IsNotOverlapping = true;
    }
    Total++;

    if ((IsOverlapping & IsNotOverlapping) | (!IsNotOverlapping & !IsOverlapping))
    {
      Console.WriteLine("Error in:");
      Console.WriteLine($"{RangeAText} with {RangeBText} isOverlapping: {IsOverlapping}, isNotOverlapping: {IsNotOverlapping}");
    }
  }
}

Console.WriteLine($"Result Part 1: {TotalInRange}");
Console.WriteLine();
Console.WriteLine($"Total not overlaps {TotalNotEverlaps} / {Total}");
Console.WriteLine($"Total: { TotalOverlaps} / { Total}");
Console.WriteLine($"Result Part 2: {TotalOverlaps}");
