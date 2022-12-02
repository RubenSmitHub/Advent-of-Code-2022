namespace Day_2
{
  public class RockPaperSiccorsGame : IRockPaperSiccorsGame
  {
    public RockPaperSiccorsItem MyValue { get; set; }
    public RockPaperSiccorsItem OpponentValue { get; set; }

    public RockPaperSiccorsGame(RockPaperSiccorsItem myValue, RockPaperSiccorsItem opponentValue)
    {
      MyValue = myValue;
      OpponentValue = opponentValue;
    }

    private RockPaperSiccorsGame()
    {

    }

    public int GetScore()
    {
      int ShapeScore = GetShapeScore(MyValue);
      int OutComeScore = GetOutcomeScore(MyValue, OpponentValue);

      return ShapeScore + OutComeScore;

    }

    public static RockPaperSiccorsGame FromStringInput(string s)
    {
      RockPaperSiccorsGame Game = new()
      {
        OpponentValue = RockPaperSiccorsItemFromABC(s[..1]),
        MyValue = RockPaperSiccorsItemFromXYZ(s.Substring(2, 1))
      };

      return Game;

    }

    private static RockPaperSiccorsItem RockPaperSiccorsItemFromABC(string v)
    {
      return v switch
      {
        "A" => RockPaperSiccorsItem.Rock,
        "B" => RockPaperSiccorsItem.Paper,
        "C" => RockPaperSiccorsItem.Sciccors,
        _ => throw new ArgumentException(),
      };
    }

    private static RockPaperSiccorsItem RockPaperSiccorsItemFromXYZ(string v)
    {
      return v switch
      {
        "X" => RockPaperSiccorsItem.Rock,
        "Y" => RockPaperSiccorsItem.Paper,
        "Z" => RockPaperSiccorsItem.Sciccors,
        _ => throw new ArgumentException(),
      };
    }

    private int GetOutcomeScore(RockPaperSiccorsItem myValue, RockPaperSiccorsItem opponentValue)
    {
      return myValue switch
      {
        RockPaperSiccorsItem.Rock => opponentValue switch
        {
          RockPaperSiccorsItem.Rock => 3,
          RockPaperSiccorsItem.Paper => 0,
          RockPaperSiccorsItem.Sciccors => 6,
          _ => throw new ArgumentException("No valid item"),
        },
        RockPaperSiccorsItem.Paper => opponentValue switch
        {
          RockPaperSiccorsItem.Rock => 6,
          RockPaperSiccorsItem.Paper => 3,
          RockPaperSiccorsItem.Sciccors => 0,
          _ => throw new ArgumentException("No valid item"),
        },
        RockPaperSiccorsItem.Sciccors => opponentValue switch
        {
          RockPaperSiccorsItem.Rock => 0,
          RockPaperSiccorsItem.Paper => 6,
          RockPaperSiccorsItem.Sciccors => 3,
          _ => throw new ArgumentException("No valid item"),
        },
        _ => throw new ArgumentException("No valid item"),
      };
    }

    private int GetShapeScore(RockPaperSiccorsItem myValue)
    {
      switch (myValue)
      {
        case RockPaperSiccorsItem.Rock: return 1;
        case RockPaperSiccorsItem.Paper: return 2;
        case RockPaperSiccorsItem.Sciccors: return 3;
        default: throw new ArgumentException("No valid item");
      }
    }
  }
}
