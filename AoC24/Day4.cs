using System.Text.RegularExpressions;

namespace AoC24;

public static class Day4
{
    public static void Calculate()
    {
        var data = LoadData();
        var result = SearchDataGrid(data);
    }

    private static int SearchDataGrid(IEnumerable<string> data)
    {
        var count = 0;
        count += CountHorizontal(data);
        return count;
    }

    private static int CountHorizontal(IEnumerable<string> data)
    {
        var total = 0;
        foreach (var line in data)
        {
            total += Regex.Matches(line, @"(XMAS)|(SAMX)").Count;
        }

        return total;
    }

    private static IEnumerable<string> LoadData()
    {
        return File.ReadLines("/Users/alix/src/aoc/AoC24/AoC24/Data/Day4.txt");
    }
}