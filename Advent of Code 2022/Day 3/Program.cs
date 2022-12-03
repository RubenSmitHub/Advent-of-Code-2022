

string FileContents = File.ReadAllText("input.txt");

int groupsum = 0;

// Part 2 solution
using (StringReader sr = new(FileContents))
{
  while (true)
  {
    string? member1 = sr.ReadLine();
    string? member2 = sr.ReadLine();
    string? member3 = sr.ReadLine();
    if (member1 == null) break;
    if (member2 == null) break;
    if (member3 == null) break;

    for (int i = 0; i < member1?.Length; i++)
    {
      char c = (char)member1[i];
      if (member2.Contains(c) & member3.Contains(c))
      {
        groupsum += GetCharValue(c);
        break;
      }
    }
  }
}

Console.WriteLine($"Result: {groupsum}");



// PART 1 SOLUTION

// int CommonItemsSum = 0;

//using (StringReader sr = new(FileContents))
//{
//  while (true)
//  {
//    string? line = sr.ReadLine();
//    if (line == null) break;


//    string compartiment1 = line.Substring(0, line.Length / 2);
//    string compartiment2 = line[(line.Length / 2)..];

//    Console.WriteLine($"{line} -> {compartiment1} | {compartiment2}");

//    for (int i = 0; i < compartiment1.Length; i++)
//    {
//      Char curChar = compartiment1[i];

//      if (compartiment2.Contains(curChar,StringComparison.Ordinal))
//      {
//        CommonItemsSum+= GetCharValue(curChar);
//        compartiment2 = compartiment2.Replace(curChar.ToString(),"");
//      }
//    }
//  }

//}

//Console.WriteLine($"Result: {CommonItemsSum}");

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