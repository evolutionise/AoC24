using System.Text.RegularExpressions;

public class Day3
{ 
//     private static readonly List<char> validLetters = ['m', 'u', 'l'];
//     static  List<char> ValidChars => Enumerable.Range(0,9).Select(x => (char)x).ToList().Concat(validLetters).ToList();

    private static string regexString = @"(mul\()(\d+)(,)(\d+)(\))";
    
    public static void Calculate()
    {
        var data = LoadData();
        var matches = ParseData(data);
        var instructions = matches.Select(ParseMatch);
        var result = CalculateResult(instructions);
        
        Console.WriteLine($"Day 3: {result}");

        var part2Result = CalculateResultWithConditionals(data);
        
        Console.WriteLine($"Day 3, Part 2: {part2Result}");

    }

    private static int CalculateResultWithConditionals(string data)
    {

        var groups = BreakDataByConditional(data);
        
        // var firstLine = ParseData(groups[0]);

        var parsedMatches = new List<(int, int)>();
        //
        // for (int i = 0; i < groups.Count; i++)
        // {
        //     var group = groups[i];
        //     if (i != 0)
        //     {
        //         
        //     }
        //     
        // }
        
        
        // Seeding with first piece which is enabled by default

        foreach (var line in groups)
        {
            var split = line.Split("do", 2);
            if (split.Length < 2)
            {
                continue;
            }
            var matches = ParseData(split[1]);
            parsedMatches.AddRange(matches.Select(ParseMatch));
        }

        parsedMatches.AddRange(ParseData(groups.First()).Select(ParseMatch));
        return CalculateResult(parsedMatches);
    }

    private static List<string> BreakDataByConditional(string data)
    {
        return data.Split("don't").ToList();
    }

    private static int CalculateResult(IEnumerable<(int, int)> instructions)
    {
        return instructions.Aggregate(0, (result, instruction) => result + (instruction.Item1 * instruction.Item2));
    }

    private static (int, int) ParseMatch(Match match)
    {
        var a = int.Parse(match.Groups[2].Value);
        var b = int.Parse(match.Groups[4].Value);
        return (a, b);
    }

    private static MatchCollection ParseData(string data)
    {
        return Regex.Matches(data, regexString);
    }

    private static string LoadData()
    {
        return File.ReadAllText("/Users/alix/src/aoc/AoC24/AoC24/Data/Day3.txt");
    }
}