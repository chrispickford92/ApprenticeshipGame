using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChrisDungeon
{
    [Serializable]
    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;

        static void Main(string[] args)
        {
            
            String MenuOptions;


            Console.WriteLine("Dungeon Master!\n");
            

            bool Menu = false;
            while (Menu == false) { 
                Console.WriteLine("Choose an option:\n1. Start New Game\n2. Continue\n3. User Manual & Controls");
            MenuOptions = Console.ReadLine();

            
                if (MenuOptions == "1")
                {
                    if (!Directory.Exists("saves"))
                    {
                        Directory.CreateDirectory("saves");
                    }
                    NewStart();
                    Menu = true;
                }                  
                
                else if (MenuOptions == "2")
                {
                    currentPlayer = Load();
                    Menu = true;
                }
                   
                else if (MenuOptions == "3")
                {
                    Console.WriteLine("User Manual & Controls is Under construction");
                    Menu = true;
                }

                else {
                    Console.WriteLine("incorrect");
                    Menu = false;
                }

                while (mainLoop)
                {
                    Encounters.randomEncounters();
                }
                    

            }
        }

        static void NewStart()
        {
            Console.Clear();

            Random rnd = new Random();
            currentPlayer.id = rnd.Next(1, 10000000);
            Console.Clear();
            Console.WriteLine("What is your name: ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nYou open your eyes and find your self in a cold, stone, dark room. You feel dazed and confused, you find it hard to ");
            Console.WriteLine("focus. You are finding it hard to remember anything about your past.");

            if (currentPlayer.name == "")
            {
                Console.WriteLine("\nYou cannot even remember your own name....");
            }
                

            else
            {
                Console.Write("\nYou remember your name is " + currentPlayer.name);
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n\nYou feel around in the darkness until you find a door handle. You feel some resistance as you turn the ");
            Console.WriteLine("handle, but the lock breaks. You see a silhouette of a creature down a poorly lit dark corridor.\n");
            Console.ReadKey();
            Encounters.FirstEncounter();

        }

        public static void quit()
        {
            Console.WriteLine("Your game has been saved!");
            Save();
            Environment.Exit(0);
        }

        public static void Save()
        {
            string player = JsonConvert.SerializeObject(currentPlayer);
            string path = "saves/" + currentPlayer.id.ToString() + ".level";
            File.WriteAllText(path, player);
           
        }

        public static Player Load()
        {
            Console.Clear();
            Console.WriteLine("Choose you which player you would like to continue with:");
            string[] paths = Directory.GetFiles(@"saves\");
            List<Player> players = new List<Player>();
            
          
            foreach (string p in paths)
            {
                string jsonplayer = File.ReadAllText(p);
                Player playerone = JsonConvert.DeserializeObject<Player>(jsonplayer);
                players.Add(playerone);
               

            }


            
            
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Choose your player:");

                foreach (Player p in players)
                {
                    Console.WriteLine(p.id + " : " + p.name);
                }

                Console.WriteLine("Please input player name or ID (ID:# or playername)");
                string[] data = Console.ReadLine().Split(':');

                try
                {
                    if(data[0] == "id")
                    {
                        if(int.TryParse(data[1],out int id))
                        {
                            foreach (Player player in players)
                            {
                                if (player.id == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("There is no player with that id!");
                                Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("Your id needs to be a number! Press any key to continue");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if(player.name == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("There is no player with that name!");
                        Console.ReadKey();
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Your id needs to be a number! Press any key to continue");
                    Console.ReadKey();
                }
            }
            

        }
    }
}
  

