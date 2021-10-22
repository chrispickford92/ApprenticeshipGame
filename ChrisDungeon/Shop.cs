using System;
using System.Collections.Generic;
using System.Text;

namespace ChrisDungeon
{
    public class Shop
    {
        static int armorMod;
        static int weaponMod;
        static int difMod;

        public static void LoadShop(Player p)
        {
            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionP;
            int armourP;
            int weaponP;
            int difP;




            while (true)
            {
                potionP = 20 + 10 * p.mods;
                armourP = 75 * (p.armourValue + 1);
                weaponP = 75 * p.weaponValue;
                difP = 300 + 100 * p.mods;



                Console.Clear();
                Console.WriteLine("           SHOP            ");
                Console.WriteLine("==========================");
                Console.WriteLine("(P)otions:    " + potionP);
                Console.WriteLine("(W)eapon:     " + weaponP);
                Console.WriteLine("(A)rmour:     " + armourP);
                Console.WriteLine("(D)ifficulty: " + difP);
                Console.WriteLine("==========================");
                Console.WriteLine("(E)xit");
                Console.WriteLine("(Q)uit");


                Console.WriteLine(p.name + "'s Statistics  ");
                Console.WriteLine("==========================");
                Console.WriteLine("Current Health: " + p.health);
                Console.WriteLine("Coins         : " + p.coins);
                Console.WriteLine("Potions       : " + p.potions);
                Console.WriteLine("Weapon        : " + p.weaponValue);
                Console.WriteLine("Armour        : " + p.armourValue);
                Console.WriteLine("Difficulty    : " + p.mods);
                Console.WriteLine("==========================");

                //User input
                string input = Console.ReadLine().ToLower();
                if(input == "p" || input == "potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if (input == "a" || input == "Armour")
                {
                    TryBuy("armour", armourP, p);
                }
                else if (input == "d" || input == "Difficulty")
                {
                    TryBuy("dif", difP, p);
                }
                else if (input == "e" || input == "Exit")
                {
                    break;
                }
                else if (input == "q" || input == "Quit")
                {
                    Program.quit();
                }

            }

            
        }
        static void TryBuy(string item, int cost, Player p)
        {
            if(p.coins >= cost)
            {
                if(item == "potion")
                {
                    p.potions++;
                } else if (item == "weapon")
                {
                    p.weaponValue++;
                } else if (item == "armour")
                {
                    p.armourValue++;
                } else if (item == "Difficulty")
                {
                    p.mods++;
                }
                p.coins -= cost;
            }
            else
            {
                Console.WriteLine("You do not have enough coin traveller");
                Console.ReadKey();
            }
        }


    }
}
