namespace Day_2
{
  public interface IRockPaperSiccorsGame
  {
    RockPaperSiccorsItem MyValue { get; set; }
    RockPaperSiccorsItem OpponentValue { get; set; }

    int GetScore();
  }
}