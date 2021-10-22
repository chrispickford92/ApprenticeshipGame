using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DungeonMaster
{
    [Serializable]
    class Program
    {
        //initialise map
        public static Map Maps = new Map();        
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;

        static void Main(string[] args)
        {
            Map.LoadMap();
             String MenuOptions;


            Console.WriteLine("Dungeon Master!\n");
            
            

            
            //Keep menu open until a decision is made by the user
            bool Menu = false;
                while (Menu == false)
                {
                    Console.WriteLine("Choose an option:\n(1). Start New Game\n(2). Continue\n(3). User Manual & Controls");
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
                        NewStart();
                        Menu = false;
                    }
                    //user manual displayed on the same page. Will be cleared once user is ready to start
                    else if (MenuOptions == "3")
                    {
                    Console.Clear();
                        Console.WriteLine("Controls & Instructions");
                        Menu = false;
                        Console.WriteLine("Intructions");
                    Console.WriteLine("\nAny letter or number with () around it, is usable!");
                    Console.WriteLine("\nComplete the game and defeat the final boss");
                    Console.WriteLine("\nUse W, A, S, D to move around the map");
                    Console.WriteLine("\nDefeat monsters using attacks ");
                    Console.WriteLine("\nKeep health by using potions, be careful it can run out quickly!");
                    Console.WriteLine("\nPress any key to return to the main menu");
                    Console.WriteLine("\nUse the shop to purchase upgrades");
                    Console.WriteLine("\n\n\nPress any key to return to the main menu");
                    Console.ReadKey();
                    
                    Console.Clear();
                    



                }

                    else
                    {
                        Console.WriteLine("incorrect");
                        Menu = false;
                    }


                

            }
        }





        static void NewStart()
        {

            //Starts the player off with a new game, places them in the map. 
            Console.Clear();
            while (currentPlayer.health > 0)
            {
                if (currentPlayer.playerProg == 0)
                {
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
                        Console.WriteLine("\nYou cannot even remember your own name....?");
                    }


                    else
                    {
                        Console.Write("\nYou remember your name is " + currentPlayer.name);
                    }



                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("\n\nYou open your eyes to dark room, you can barely see anything.... ");                    
                    Console.ReadKey();

                    //Give player a start position, start loop of map until the user encounters something or finishes
                    //Once player has finised, add progression and move to the next level. 
                    currentPlayer.PlayerStartPosition();
                    while (currentPlayer.health > 0 && currentPlayer.Move())
                    {
                        
                    }

                    
                    currentPlayer.playerProg++;
                    Save();
                    Console.WriteLine("Game Saved!");
                    Console.ReadKey();

                }
                else if (currentPlayer.playerProg == 1)
                {
                    Levels.FirstLevel(currentPlayer);
                    
                   
                    Save();
                    Console.Clear();

                    Console.WriteLine("\nGame Saved!");
                    Console.ReadKey();
                }
                else if (currentPlayer.playerProg == 2)
                {
                    Levels.SecondLevel(currentPlayer);
                    
                    Save();
                    Console.Clear();
                    Console.WriteLine("\nGame Saved!");
                    Console.ReadKey();

                }
                else if (currentPlayer.playerProg == 3)
                {
                    Levels.BossLevel(currentPlayer);
                    
                    Save();
                    Console.Clear();
                    Console.WriteLine("\nGame Saved!");
                    Console.ReadKey();
                }
                else if (currentPlayer.playerProg > 3)
                {
                    Console.WriteLine("You have completed the game, please start again!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }



        }
        //Quit the game and save
        public static void quit()
        {
            Console.Clear();
            Console.WriteLine("\nYour game has been saved!");
            Save();
            Environment.Exit(0);
        }
        //Save the game
        public static void Save()
        {
            string player = JsonConvert.SerializeObject(currentPlayer);
            string path = "saves/" + currentPlayer.name+currentPlayer.id.ToString() + ".level";
            File.WriteAllText(path, player);
           
        }
        //Load the game from the load page accessible in the menu
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


            
            //Loop to cycle through datafiles and display them within the load game page
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
  

