namespace AoC24;

public class Day1
{
    public int Calculate()
    {
        var data = ReadData();
        var distance = CalculateDistance(data);
        Console.WriteLine(distance);
        return distance;
    }

    private int CalculateDistance((List<int>, List<int>) data)
    {
        data.Item1.Sort();
        data.Item2.Sort();
        var distance = 0;
        for (var i = 0; i < data.Item1.Count; i++)
        {
            var lineDiff = data.Item2[i] - data.Item1[i];
            distance += int.Abs(lineDiff);
        }
        return distance;
    }

    private (List<int>, List<int>) ReadData()
    {
        var file = File.ReadLines("/Users/alix/src/aoc/AoC24/AoC24/Data/Day1.txt");
        var lists = (new List<int>(), new List<int>());
        var thing = file
            .Select(x => x.Split("   "));

        foreach (var x in thing)
        {
            // Console.WriteLine($"{x[0]} {x[1]}");
            lists.Item1.Add(int.Parse(x[0]));
            lists.Item2.Add(int.Parse(x[1]));
        }
        
        return lists;
    }
}