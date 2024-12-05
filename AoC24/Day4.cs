using System.Text.RegularExpressions;

namespace AoC24;

public static class Day4
{
    public static void Calculate()
    {
        var data = LoadData();
        var result = SearchDataGrid(data.ToList());
    }

    private static int SearchDataGrid(IList<string> data)
    {
        var count = 0;
        count += CountHorizontal(data);
        count += CountVertical(data);
        count += CountDiagonal(data);
        return count;
    }

    private static int CountDiagonal(IList<string> data)
    {
        var convertedGrid = new List<string>();
        for (var i = 0; i < data[0].Length; i++)
        {
            convertedGrid.Add(data.Select(x => x[i]).ToString());
        }
    }

    private static int CountVertical(IList<string> data)
    {
        var convertedGrid = new List<string>();
        for (var i = 0; i < data[0].Length; i++)
        {
            convertedGrid.Add(data.Select(x => x[i]).ToString());
        }
        
        return CountHorizontal(convertedGrid);
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