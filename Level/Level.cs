//level generation

namespace Levels;

public class Level
{
    private char[,] currentLevel;

    // E - enemy room
    // N - empty (none) room
    // H - HP room
    // W - weapon room  
    // S - spawn room
    // X - exit
    // O - entrance
    public Level(int depth, int x = 5, int y = 5)
    {
        Random random = new Random();
        char[] rooms = { 'E', 'N', 'H', 'W', 'S' };
        char[] requiredRooms = {'O','X'};

        this.currentLevel = new char[x, y];

        int entranceX = random.Next(x);
        int entranceY = random.Next(y);
        int exitX = random.Next(x);
        int exitY = random.Next(y);

        currentLevel[entranceX, entranceY] = 'O';
        currentLevel[exitX, exitY] = 'X';

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (!requiredRooms.Contains(currentLevel[i, j]))
                {
                    currentLevel[i, j] = rooms[random.Next(rooms.Length)];
                }
            }
        }




    }

    //print the current level layout
    public void PrintLevel()
    {
        for (int i = 0; i < currentLevel.GetLength(0); i++)
        {
            for (int j = 0; j < currentLevel.GetLength(1); j++)
            {
                Console.Write(currentLevel[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
