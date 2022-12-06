
string FileContents = File.ReadAllText("Input.txt");

bool StartPacketMarkerDetected = false;
bool StartMessageMarkerDetected = false;

Queue<string> StartOfPacketMarker = new Queue<string>(4);
Queue<string> StartOfMessageMarker = new Queue<string>(14);

int part1answer = 0;
int part2answer = 0;

using (StringReader sr = new(FileContents))
{
  
  while (StartPacketMarkerDetected == false | StartMessageMarkerDetected == false)
  {
    int result = sr.Read();
    if (result == -1) break;

    if (StartPacketMarkerDetected == false)
    {
      if (StartOfPacketMarker.Count == 4)
      {
        StartOfPacketMarker.Dequeue();
      }
      StartOfPacketMarker.Enqueue(char.ConvertFromUtf32(result));

      StartPacketMarkerDetected = IsMarker(StartOfPacketMarker, 4);

      part1answer++;
    }

    if (StartMessageMarkerDetected == false)
    {
      if (StartOfMessageMarker.Count == 14)
      {
        StartOfMessageMarker.Dequeue();
      }

      StartOfMessageMarker.Enqueue(char.ConvertFromUtf32(result));

      StartMessageMarkerDetected = IsMarker(StartOfMessageMarker, 14);
      part2answer++;

    }
    


    
  }
}

Console.WriteLine($"Answer part 1: {part1answer}");
Console.WriteLine($"Answer part 2: {part2answer}");


bool IsMarker(Queue<string> marker, int length)
{
  if (marker.Count != length)
  {
    return false;
  }

  var calc = marker.ToArray<string>();
  
  for (int i = 0; i < marker.Count; i++)
    for (int j = i + 1; j < marker.Count; j++)
      if (calc[i] == calc[j])
        return false;

  return true;

}