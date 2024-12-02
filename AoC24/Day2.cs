using Exception = System.Exception;

namespace AoC24;

public class Day2
{
    public static void Calculate()
    {
        var data = ReadData();
        var answer = CalculateSafety(data);
        Console.WriteLine($"Day 2: {answer}");
    }

    private static int CalculateSafety(IEnumerable<IList<int>> data)
    {
        var answer = 0;
        foreach (var line in data)
        {
            answer += CalculateSafetyOfLine(line);
        }
        
        return answer;
    }

    private static int CalculateSafetyOfLine(IList<int> line)
    {
        var lastEquality = Equality.Same;
        for (int i = 0; i < line.Count - 1; i++)
        {
            if (i == 0)
            {
                var a = line[i];
                var b = line[i + 1];
                lastEquality = GetEquality(a, b);
                continue;
            }
            
            var level = line[i];
            var nextLevel = line[i + 1];
            var equality = GetEquality(level, nextLevel);

            if (equality == Equality.Same) return 0;
            if (lastEquality != equality) return 0;
            if( int.Abs(level - nextLevel) > 3 ) return 0;
        }

        return 1;
    }

    private static Equality GetEquality(int level, int nextLevel)
    {
        if (level == nextLevel) return Equality.Same;
        if (level < nextLevel) return Equality.Increase;
        if (level > nextLevel) return Equality.Decrease;
        throw new Exception("Invalid level");
    }

    private static IEnumerable<IList<int>> ReadData()
    {
        var file = File.ReadLines("/Users/alix/src/aoc/AoC24/AoC24/Data/Day2.txt");
        var data = file
            .Select(l => l.Split(' '))
            .Select(l => l.Select(int.Parse).ToList());
        
        return data;
    }

    enum Equality
    {
        Same = 0,
        Increase = 1,
        Decrease = 2,
    }
}