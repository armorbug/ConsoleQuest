//level generation

using System.Collections;
using System.Collections.Generic;

namespace Levels;

public class Level
{
    private char[,] currentLevel;

    // E - enemy room
    // . - empty (none) room
    // H - HP room - four/two/zero per level, scales with difficulty
    // W - weapon room - two per level 
    // S - spawn room - one per level 
    // X - exit - one per level, guarded by a boss monster 
    // O - entrance - one per level
    public Level(int depth, int x = 5, int y = 5, string difficulty = "normal")
    {
        Random random = new Random();
        this.currentLevel = new char[x, y];
        Dictionary<Char, Int32> rooms = new Dictionary<Char, Int32>();
        
        int nonCrucialRooms = x*y - 3; //rooms that are not start, exit, or spawn

        // set room count based on difficulty
        // easy - 4 health rooms, 2 weapon rooms, 1/3 of the rooms have enemies
        // normal - 3 health rooms, 1 weapon room, 1/2 of the rooms have enemies
        // hard - 1 health room, 1 weapon room, 2/3 of the rooms have enemies
        // insane - 0 health rooms, 1 weapon room, 4/5 of the rooms have enemies
        // crazy - 0 health rooms, 0 weapon rooms, all remaining rooms have enemies 

        switch (difficulty)
        {
            case "easy":
                rooms['H'] = 4;
                rooms['W'] = 2;
                rooms['E'] = (nonCrucialRooms - rooms['H'] - rooms['W'])/3;
                rooms['.'] = nonCrucialRooms - rooms['H'] - rooms['W'] - rooms['E'];
                break;
            case "normal":
                rooms['H'] = 3;
                rooms['W'] = 1;
                rooms['E'] = (nonCrucialRooms - rooms['H'] - rooms['W'])/2;
                rooms['.'] = nonCrucialRooms - rooms['H'] - rooms['W'] - rooms['E'];
                break;
            case "hard":
                rooms['H'] = 1;
                rooms['W'] = 1;
                rooms['E'] = (nonCrucialRooms - rooms['H'] - rooms['W'])*2/3;
                rooms['.'] = nonCrucialRooms - rooms['H'] - rooms['W'] - rooms['E'];
                break;
            case "insane":
                rooms['H'] = 0;
                rooms['W'] = 1;
                rooms['E'] = (nonCrucialRooms - rooms['W'])*4/5;
                rooms['.'] = nonCrucialRooms - rooms['W'] - rooms['E'];
                break;
            case "crazy":
                rooms['H'] = 0;
                rooms['W'] = 0;
                rooms['E'] = nonCrucialRooms;
                rooms['.'] = 0;
                break;
        }

        char[] chars = new char[x*y];
        int count = 0;

        foreach (char c in rooms.Keys)
        {
            for (int i = 0; i < rooms[c]; i++)
            {
                chars[count] = c;
                count++;
            }
        }

        Console.WriteLine(chars);

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
