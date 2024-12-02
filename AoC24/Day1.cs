namespace AoC24;

public class Day1
{
    public void Calculate()
    {
        ReadData();
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