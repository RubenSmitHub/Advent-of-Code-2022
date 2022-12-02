using Day_2;

string FileContents = File.ReadAllText("input.txt");

int numberOfGames = 0;
int totalscore = 0;

using (StringReader sr = new(FileContents))
{

  while (true)
  {
    string? line = sr.ReadLine();
    if (line == null) break;

    IRockPaperSiccorsGame Game = RockPaperSiccorsGameDay2.FromStringInput(line);
    totalscore += Game.GetScore();
    numberOfGames += 1;
    Console.Write($"+{Game.GetScore()}");
  }
}
Console.WriteLine();
Console.WriteLine($"Total score: {totalscore} in {numberOfGames} games.");
