using System.Collections;

public static class Day6
{
    public static void Calculate()
    {
        var map = ReadData();
        var thing = Patrol(map);

    }

    private static int Patrol(List<List<char>> map)
    {
        var startingPosition = GetStartingPosition(map);
        
        var nextMove = GetNextMove(startingPosition, map);
        
        
        
        
        return 0;
    }

    private static Move GetNextMove(Position position, List<List<char>> map)
    {
        switch (position.Direction)
        {
            case Direction.Up:
                if (position.X <= 0) return Move.Finish;
                if (map[position.Y - 1][position.X] == '.') return Move.Straight;
                return Move.Turn;
                
        }
        var forward = new Position(position.X - 1, position.Y, Direction.Up, map);
            
            
            
            map[position.Y - 1][position.X];
        return Move.Finish;
    }

    private static Position GetStartingPosition(List<List<char>> map)
    {
        foreach (var line in map.Select((value, y) => (value, y)))
        {
            foreach (var c in line.value.Select((yValue, x) => (yValue, x)))
            {
                if (c.yValue == '^')
                {
                    return new Position(c.x, line.y, Direction.Up, map);
                }
            }
        }
        throw new Exception("Could not find start position");
    }

    private static List<List<char>> ReadData()
    {
        var lines = File.ReadLines("/Users/alix/src/aoc/AoC24/AoC24/Data/Day6.txt").ToList();
        return lines.Select(x => x.ToCharArray().ToList()).ToList();
    }
}

internal enum Move
{
    Straight = 0,
    Turn = 1,
    Finish = 2,
}

internal class Position(int x, int y, Direction direction, List<List<char>> map)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    private List<List<char>> Map { get; set; } = map;
    public char Value => Map[Y][X];
    public Direction Direction { get; set; } = direction;
}

internal enum Direction
{
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3,
}