

string FileContents = File.ReadAllText("input.txt");


int CommonItemsSum = 0;

using (StringReader sr = new(FileContents))
{
  while (true)
  {
    string? line = sr.ReadLine();
    if (line == null) break;


    string compartiment1 = line.Substring(0, line.Length / 2);
    string compartiment2 = line[(line.Length / 2)..];

    Console.WriteLine($"{line} -> {compartiment1} | {compartiment2}");

    for (int i = 0; i < compartiment1.Length; i++)
    {
      Char curChar = compartiment1[i];

      if (compartiment2.Contains(curChar,StringComparison.Ordinal))
      {
        CommonItemsSum+= GetCharValue(curChar);
        compartiment2 = compartiment2.Replace(curChar.ToString(),"");
      }
    }
  }

}

Console.WriteLine($"Result: {CommonItemsSum}");

int GetCharValue(char curChar)
{
  int result = 0;

  if (char.IsUpper(curChar))
  {
    result = curChar - 'A' + 27;
  }
  else
  {
    result = curChar - 'a' + 1;
  }

  return result;
}