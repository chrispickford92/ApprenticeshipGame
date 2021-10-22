using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DungeonMaster
{
    public class Map
    {
        public static string[] MapOne;
        //Load map function
        public static void LoadMap()
        {
            string mapText = File.ReadAllText(@"Map\Map.txt");
            MapOne = mapText.Split(Environment.NewLine);
        }

            public static bool IsWall(int x,int y)
            {
            if (MapOne[y][x] == '-')
            {                
                return true;
            }
            else
            {
                return false;
            }
                
        }

        //Determine if it is a boss in map
        public static bool IsBoss(int x, int y)
        {
            if (MapOne[y][x] == '1')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Determine if it coins in map

        public static bool IsCoins(int x, int y)
        {
            if (MapOne[y][x] == 'C')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Display the map to the user while navigating around the map. 

        public static void DisplayMap(int x, int y)
        {
            Console.WriteLine("\nMap:\n");
            for (int indexY = 0; indexY < MapOne.Length; indexY++)
            {
                string CP = MapOne[indexY]; 


                if (indexY == Program.currentPlayer.positionYIndex)
                {
                    string somestring = CP;
                    char[] ch = somestring.ToCharArray();
                    ch[x] = 'X'; // index starts at 0!
                    CP = new string(ch); 
                    


                }
                
                Console.WriteLine(CP.Replace('C', '?').Replace('E', '?').Replace('1', '?'));
            }
            
           
            Console.WriteLine("X = Current Position, F = Finish, ? = Investigate");
            
        }

        //Determine whether the map has been finished

        public static bool IsFinish(int x, int y)
            {
                if (MapOne[y][x] == 'F')
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        //Determine if it is an encouter within the map
        public static bool IsEncounter(int x, int y)
        {
            if (MapOne[y][x] == 'E')
            {
                return true;
            }
            else
            {
                return false;
            }

        }




        public static void GetStartPos()
            {
            for (int y = 0; y < MapOne.Length; y++)
            {
                for (int x = 0; x < MapOne[y].Length; x++)
                {
                    if (MapOne[y][x] == 'S')
                    {
                        Program.currentPlayer.positionXIndex = x;
                        Program.currentPlayer.positionYIndex = y;


                    }

                }

            }
        }
    }
}


            