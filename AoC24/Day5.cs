public static class Day5
{
    public static void Calculate()
    {
        // Rules
        
        // Read rules
        // read updates
        
        // per update
        // select applicable rules (where both page numbers of the rule are present)
        
        // validate update against rules
        
        // if correct, calculate middle page
        
        // return sum of middle pages
        var lines = File.ReadLines("/Users/alix/src/aoc/AoC24/AoC24/Data/Day5.txt").ToList();
        var rules = ReadRuleData(lines);
        var updates = ReadUpdateData(lines);

        var total = 0;

        foreach (var update in updates)
        {
            var applicableRules = GetApplicableRules(rules, update);
            var isValidUpdate = IsValidateUpdate(applicableRules, update);
            if (isValidUpdate)
            {
                total += GetMiddlePageOfUpdate(update);
            }
        }
        
        Console.WriteLine($"Day 5, Part 1: {total}");
        
    }

    private static int GetMiddlePageOfUpdate(List<int> update)
    {
        if(update.Count % 2 == 0) throw new Exception("Can't find middle of an event set");
        var middle = update[update.Count / 2];
        return middle;
    }

    private static bool IsValidateUpdate(IEnumerable<(int, int)> applicableRules, List<int> update)
    {
        foreach (var rule in applicableRules)
        {
            var firstInstanceOfSecondPage = update.FindIndex(x => x == rule.Item2);
            var lastInstanceOfFirstPage = update.FindLastIndex(x => x == rule.Item1);
            if(firstInstanceOfSecondPage < lastInstanceOfFirstPage) return false;
        }
        return true;
    }

    private static IEnumerable<(int, int)> GetApplicableRules(List<(int, int)> rules, List<int> update)
    {
        foreach (var rule in rules)
        {
            if (update.Contains(rule.Item1) && update.Contains(rule.Item2))
            {
                yield return rule;
            }
        }
    }

    private static List<List<int>> ReadUpdateData(IEnumerable<string> lines)
    {
        return lines.Take(1177..)
            .Select(x => x.Split(','))
            .Select(y => y.Select(int.Parse).ToList()).ToList();
    }

    private static List<(int, int)> ReadRuleData(IEnumerable<string> lines)
    {
        
        return lines.Take(1176).Select(ParseRuleLine).ToList();
    }

    private static (int, int) ParseRuleLine(string s)
    {
        var numbers = s.Split('|');
        return (int.Parse(numbers[0]), int.Parse(numbers[1]));
    }
}