using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster
{
    [Serializable]
    public class Player
    {
        public int playerProg = 0;
        public int id;
        public string name;
        public int coins = 50;
        public int health = 35;
        public int damage = 1;
        public int armourValue = 0;
        public int potions = 5;
        public int weaponValue = 1;
        public int positionYIndex;
        public int positionXIndex;
        public int mods = 0;

        public void PlayerStartPosition()
        {
            Map.GetStartPos();

        }
        //Function to the allow the user to move around the map using keys
        public bool Move()
        {
            Console.Clear();
            Console.WriteLine("Hi line 32" + positionXIndex + " "+ positionXIndex);
           
            Console.WriteLine("\nUse W, A, S, D to move around the room\n");
            Console.WriteLine("\nW = Up");
            Console.WriteLine("\nA = Left");
            Console.WriteLine("\nS = Down");
            Console.WriteLine("\nD = Right");
            Map.DisplayMap(positionXIndex, positionYIndex);
            string input = Console.ReadLine().ToLower();
            
            if (input == "w")
            {

                if (Map.IsWall(positionXIndex, positionYIndex - 1))
                {
                    Console.WriteLine("That is a wall, you cannot move");
                    Console.ReadKey();
                    return true;
                } else
                {
                    Console.WriteLine("You have moved up!");
                    Console.ReadKey();
                    positionYIndex--;
                }
            }
            else if (input == "a")
            {
                if (Map.IsWall(positionXIndex - 1, positionYIndex))
                {
                    Console.WriteLine("That is a wall, you cannot move");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("You have moved to the left!");
                    Console.ReadKey();
                    positionXIndex--;
                }

            }
            else if (input == "s")
            {
                if (Map.IsWall(positionXIndex, positionYIndex + 1))
                {
                    Console.WriteLine("That is a wall, you cannot move");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("You have moved down!");
                    Console.ReadKey();
                    positionYIndex++;
                }

            }
            else if (input == "d")
            {
                if (Map.IsWall(positionXIndex + 1, positionYIndex))
                {
                    Console.WriteLine("That is a wall, you cannot move");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("You have moved to the right!");
                    Console.ReadKey();
                    positionXIndex++;
                }

            }
            if (Map.IsBoss(positionXIndex, positionYIndex))
            {
                Encounters.FirstEncounter();
                
            }
            if (Map.IsFinish(positionXIndex, positionYIndex))
            {
                Levels.FirstLevel(this);
                return false;

            }
            if(Map.IsEncounter(positionXIndex, positionYIndex))
            {
                Encounters.randomEncounters();
            }
            if (Map.IsCoins(positionXIndex, positionYIndex))
            {
                Encounters.FindCoins();
            }

            return true;

        }
        
        public int GetHealth()
        {
            Random rand = new Random();
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return rand.Next(lower, upper);
        }

        

        public int GetPower()
        {
            Random rand = new Random();
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }

        public int GetCoins()
        {
            Random rand = new Random();
            int upper = (15 * mods + 50);
            int lower = (10 * mods + 10);
            return rand.Next(lower, upper);
        }


    }
}
