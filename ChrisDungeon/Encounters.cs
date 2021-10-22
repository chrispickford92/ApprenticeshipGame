using System;
using System.Collections.Generic;
using System.Text;

namespace ChrisDungeon
{
    public class Encounters
    {
        static Random rand = new Random();
        // Encounter generic

        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("\nYou throw open the door, and begin to charge towards the silloutte, you see a rusty bar on the floor ");
            Console.WriteLine("and pick it up as a weapon as you run. As you get closer, you see the creature turn towards you!");
            Console.ReadKey();
            Combat(false, "Creature", 1, 4);

        }

        public static void basicEncounters()
        {
            Console.Clear();
            Console.WriteLine(" You turn the corner and see a creature....");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }

        public static void GrandWizard()
        {
            Console.Clear();
            Console.WriteLine("You enter the lair of the of the grand wizard, you seem hunched over reading through old magic scripts");
            Combat(false, "Grand Wizard", 10, 4);
        }

        public static void randomEncounters()
        {
            switch (rand.Next(0, 1))
            {
                case 0:
                    basicEncounters();
                    break;

            }


        }

      


        //Encounter tools
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
                Console.WriteLine("|  (R)un    |   (H)eal   |  ");
                Console.WriteLine("==========================");
                Console.WriteLine("Potions: " + Program.currentPlayer.potions + "  Health: " + Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Attack
                    Console.WriteLine("You attempt to attack the " + n + " but it strikes you as you aswell");
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

                    Console.WriteLine("You lose " + damage + "health and deal " + attack + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
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
            Console.WriteLine("You have destroyed " + n + ", it's body some how turns into " + c + " Gold Coins!");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }
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


