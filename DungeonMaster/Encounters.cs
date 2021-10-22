using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster
{
    public class Encounters
    {
        static Random rand = new Random();
        // Encounter generic

        //Encounters
        public static void FirstEncounter()
        {
            Console.Clear();
            Console.WriteLine("\nYou see a large beast appear! What is this! ");
           
            Console.ReadKey();
            Combat(false, "Creature", 1, 4);

        }
        //basic encounter for map combat
        public static void basicEncounters()
        {
            Console.Clear();
            Console.WriteLine("A wild creature appeared!");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }
        //Final bosses
        public static void GrandWizard()
        {
            Console.Clear();
            Console.WriteLine("I will have my VENGENCE!");
            Console.ReadKey();
            Combat(false, "Grand Wizard", 7, 7);
        }
        public static void GrandWizardRegen()
        {
            Console.Clear();
            Console.WriteLine("Just like the spirit in the amulet! He is back and ready to attack!");
            Console.ReadKey();
            Combat(false, "Grand Wizard Spirit", 8, 4);
        }
        //Give player coins
        public static void FindCoins()
        {
            
            Console.WriteLine("Congratulations you have found 50 coins");
            Console.ReadKey();
            int c = 50;
            Program.currentPlayer.coins = Program.currentPlayer.coins + c;
            
        }
        //First map boss
        public static void LevelOneBoss()
        {
            Console.Clear();
            Console.WriteLine("\nSorcerer's Apprentice Astrid: You dare touch the property of the GRAND WIZARD Balthazar! Prepare to die! ");
            Console.ReadKey();
            Combat(false, "Sourcerer's Appreticeship Astrid", 3, 4);
        }
        //Scripted story boss
        public static void LevelTwoBoss()
        {
            Console.Clear();
            Console.WriteLine("\nSorcerer's Apprentice Solomon: You will never reach the grand wizard!  ");
            Console.ReadKey();
            Combat(false, "Sourcerer's Appreticeship Solomon", 4, 5);
        }
        //User decision boss 
        public static void Traps()
        {
            Console.Clear();
            Console.WriteLine("SNAP! You have been caught in a bear trap! It tears through your ankle, and you lose 5 health");
            int c = 5; 
                Program.currentPlayer.health = Program.currentPlayer.health - c;
            if (Program.currentPlayer.health <= 5)
            {
                Console.WriteLine("You are dead!");
                Console.WriteLine("Please restart and choose your save file to continue from the last check point!");
                Program.currentPlayer.playerProg--;
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Ouch that hurt!");
                Console.ReadKey();

            }
        }

        //Randomly generated enemy
        public static void randomEncounters()
        {
            switch (rand.Next(0, 1))
            {
                case 0:
                    basicEncounters();
                    break;

            }


        }




        //Encounter and combat tools
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("==========================");
                Console.WriteLine("| (A)ttack  |  (D)efend  | ");
                Console.WriteLine("|  (S)hop    |   (H)eal   |  ");
                Console.WriteLine("==========================");
                Console.WriteLine("Potions: " + Program.currentPlayer.potions + "  Health: " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Attack
                    Console.WriteLine("You attempt to attack the " + n + " but it strikes you as aswell");
                    int damage = p - Program.currentPlayer.armourValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);


                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend
                    Console.WriteLine("As the " + n + " prepares to strike, you ready your weapon in a defensive stance");
                    int damage = (p / 4) - Program.currentPlayer.armourValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) / 2;

                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "s" || input.ToLower() == "shop")
                {
                    //Run
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint away from the " + n + ", it's strike catches you and sends you to the floor.");
                        int damage = p - Program.currentPlayer.armourValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health and are unable to escape");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("You manage to evade the " + n + " and succesfully escape!");
                        Console.ReadKey();
                        //go to shop
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }




                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {


                    //Heal
                    if (Program.currentPlayer.potions == 0)
                    {
                        Console.WriteLine("You do not have any potions");
                        int damage = p - Program.currentPlayer.armourValue;
                        if (damage < 0)
                            damage = 0;


                        Console.WriteLine("The " + n + "strikes you anyway and  you lose " + damage + " health");
                    }
                    else
                    {
                        Console.WriteLine("You reach into you bag and drink a potion, you have been healed");
                        int potionV = 5;
                        Program.currentPlayer.potions -= 1;
                        Console.WriteLine("You gain " + potionV + " health");
                        Program.currentPlayer.health += potionV;
                        Console.WriteLine("The " + n + " took advantage of you healing and striked!");
                        int damage = (p / 2) - Program.currentPlayer.armourValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lost " + damage + "Health.");

                    }
                    Console.ReadKey();
                }
                if (Program.currentPlayer.health <= 0)
                {
                    //Death
                    Console.WriteLine("The " + n + " has killed you, you LOSE! Better Luck Next Time");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();

            }
            int c = Program.currentPlayer.GetCoins();
            Console.Clear();
            Console.WriteLine("\nYou have destroyed " + n + ", it's body some how turns into " + c + " Gold Coins!");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }

        //list of random enemies for random encounters
        public static string GetName()
        {
            switch (rand.Next(0, 10))
            {
                case 0:
                    return "Spiked Ravager";
                case 1:
                    return "Soul Eater";
                case 2:
                    return "Floating Evil Spirit";
                case 3:
                    return "Giant Goblin";
                case 4:
                    return "Dreadpod";
                case 5:
                    return "Smogmutant";
                        case 6:
                    return "Cursed wraith";
                
            }
            return "Human Rogue";

        }
    }
}


