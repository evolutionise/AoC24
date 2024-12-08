using System.Text.RegularExpressions;

namespace AoC24;

public static class Day4
{
    public static void Calculate()
    {
        var data = LoadData();
        var result = SearchDataGrid(data.ToList());
        Console.WriteLine($"Day 4, Part 1: {result}");
    }

    private static int SearchDataGrid(IList<string> data)
    {
        var count = 0;
        count += CountHorizontal(data);
        count += CountVertical(data);
        count += CountDiagonalLeftToRight(data);
        count += CountDiagonalRightToLeft(data);
        return count;
    }

    private static int CountDiagonalRightToLeft(IList<string> data)
    {
        var convertedGrid = new List<string>();
        var wordLength = 4;
        
        // start at 1 because we handle the 0th row separately
        // can skip the last line because it's not like it can have enough characters anyway
        for (var i = 1; i < data.Count - 1; i++)
        {
            convertedGrid.Add(GenerateReverseHorizontalLine(data, i));
        }
        return CountHorizontal(convertedGrid);
    }

    private static string GenerateReverseHorizontalLine(IList<string> data, int index)
    {
        var flattenedLine = new List<char>();
        var currentLine = data[index];
        
        for (var i = currentLine.Length - 1; i >= 0; i--)
        {
            flattenedLine.Add(data[index][i]);
            index++;
            if (index >= data.Count) break;
        }
        return flattenedLine.ToString();
    }

    private static int CountDiagonalLeftToRight(IList<string> data)
    {
        var convertedGrid = new List<string>();
        var wordLength = 4;

        // start at 1 because we handle the 0th row separately
        // can skip the last line because it's not like it can have enough characters anyway
        for (var i = 1; i < data.Count - 1; i++)
        {
            convertedGrid.Add(GenerateHorizontalLine(data, i));
        }
        //handle line 1
        for (var i = 0; i + wordLength <= data[0].Length; i++)
        {
            List<char> line = [];
            for (var j = i; j < data[0].Length; j++)
            {
                line.Add(data[i][j]);
            }
            convertedGrid.Add(line.ToString());
        }

        return CountHorizontal(convertedGrid);
    }

    private static string GenerateHorizontalLine(IList<string> data, int index)
    {
        var flattenedLine = new List<char>();
        var currentLine = data[index];
        
        for (var i = 0; i < currentLine.Length - 1; i++)
        {
            flattenedLine.Add(data[index][i]);
            index++;
            if (index >=  data.Count) break;
        }
        return flattenedLine.ToString();
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