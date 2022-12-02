
using System.Text;
using Day_1;

string FileContents = File.ReadAllText("input.txt");

List<elf> SantasElfs = new List<elf>();

using (StringReader Reader = new(FileContents))
{
  while (true)
  {
    string? line = Reader.ReadLine();
    if (line == null) break;

    int currentCalories = 0;

    elf currentElf = new elf();

    while (int.TryParse(line, out currentCalories))
    {
      currentElf.Calories += currentCalories;
      line = Reader.ReadLine();
    }

    SantasElfs.Add(currentElf);

  }

  Console.Write("Answer part 1: ");
  Console.WriteLine(SantasElfs.Max(t => t.Calories));

  Console.Write("Answer part 2: ");
  Console.WriteLine(SantasElfs.OrderByDescending(t => t.Calories).Take(3).Sum(y => y.Calories));



}