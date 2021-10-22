using System;
using System.Collections.Generic;
using System.Text;

namespace ChrisDungeon
{
    [Serializable]
    public class Player
    {

         


        

        public int id;
        public string name;
        public int coins = 30000;
        public int health = 10;
        public int damage = 1;
        public int armourValue = 0;
        public int potions = 5;
        public int weaponValue = 1;

        public int mods = 0;
        
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
