using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMaster
{
    public class Levels
    {

        public static void FirstLevel(Player currentPlayer)
        {
            Console.Clear();
            Console.WriteLine("\nStill confused you start to wonder what on earth is going on. You notice a room down the end of the next corridor.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nWeary of more creatures you choose to investigate, the closer you get you start notice that the room is filled ");
            Console.WriteLine("with scripts and books, you see a large red book which grabs your attention and you choose to read it. ");
            Console.WriteLine("\nUpon opening the book, you notice the flames flicker with a gust of wind. This book holds great power... ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nUpon reading you notice it is full of old spells. No use to a warrior such as yourself, \nbut it must belong to something powerful enough to wield it's magic");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nYou believe what ever has this kind of magic, must be what put you here. You have decided you must find this thing  ");
            Console.WriteLine("and find out why you are here... or better yet destroy it for even thinking of messing with the great warrior " + currentPlayer.name + "!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nYou carry on inspecting books and within one of them you find 200 coins!");
            int c = 200;
            Program.currentPlayer.coins += c;
            Console.ReadKey();
            Console.WriteLine("\nBANG! Something has entered the room with you!");
            Console.ReadKey();
            Encounters.LevelOneBoss();
            Console.Clear();
            Console.WriteLine("\nYou defeated the apprentice.... you find a sacred amulet that has a trapped spirit. The spirit begins to talk....");
            Console.WriteLine("\nSpirit: Finally a noble man that holds me! I have been trapped for 100 years by the grand wizard. ");
            Console.WriteLine("\nYou must defeat him to release me! But first you must defeat each of his apprentices. After each victory I will take you");
            Console.WriteLine("\nto the shop so that you can upgrade your armour and weapons, you must do this before you face the grand wizard  ");
            Console.WriteLine("\nor he will destroy you!");
            Console.WriteLine("\n Good Luck " + currentPlayer.name + " I must now go before the beasts of this dungeon hear me!");
            Console.ReadKey();
            currentPlayer.playerProg++;
            Shop.LoadShop(currentPlayer);
            
        }

        public static void SecondLevel(Player currentPlayer)
        {
            Console.Clear();
            Console.WriteLine("\nYou have become determined to find this so called grand wizard Balthazar!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nYou pick up the nearest lecturn and leave the library room and begin your journey, you search around ");
            Console.WriteLine("\nand you find some stairs. This must the way out! As you go up you hear screams in the wind... Something ");
            Console.WriteLine("is up here. As you reach the top of the stairs you come to fork.\n\n Should you go (L)eft or (R)ight? \n");
            string input = Console.ReadLine().ToLower();
            if (input == "l" || input == "Left")
            {
                Encounters.randomEncounters();

            }
            else if (input == "r" || input == "Right")
            {
                Encounters.Traps();
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nYou continue on your journey and find a room with sacred symbols around frame of it.... You know something is in there.");
            Console.WriteLine("\nYou slowly peak the door as you open it..... you can see the apprentice distracted while reading a tome...");
            Console.WriteLine("\nNow is the time to strike!");
            Console.WriteLine("\nYou slyly creep towards him, being careful with every footstep... Just as you are about to strike he turns around!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nSorcerers Apprentice Solomon: How dare you attempt to sneak up on me!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nhe swings his arm and hits you directly in the chest with great force. Your armour protects you, ");
            Console.WriteLine("\nbut you take several steps back.\n\nIt's time to fight!");
            Console.ReadKey();
            Console.Clear();
            Encounters.LevelTwoBoss();
            Console.Clear();
            Console.WriteLine("\nFor defeating the last apprentice you have earned a bonus of 500 coins!");
            int c = 500;
            Program.currentPlayer.coins += c;
            Console.ReadKey();
            Console.WriteLine("\nAmulet Spirit: The Grand master will know you are here.... best gear up before you go and face him. He is very powerful " + currentPlayer.name + "!");
            currentPlayer.playerProg++;
            Shop.LoadShop(currentPlayer);

        }

        public static void BossLevel(Player currentPlayer)
        {
            Console.Clear();
            Console.WriteLine("\nFully equipped and full of hope you continue your journey and you believe,");
            Console.WriteLine("\nit is time for you to face the being that put you here.");
            Console.WriteLine("\nWithin the room you are in you notice another door.... this was not here before.");
            Console.WriteLine("\nAs you open it you see a vast space with walls.");
            Console.WriteLine("\nEither side. There is little to no light but you can make out the faint structure of a gate at the end of the space.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\nYou take one step forward...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\nYou see creatures climbing the walls and roaring towards you. All eyes are on you.....");
            Console.WriteLine("\nA creature leaps towards you from the walls...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nA strange noise bellows from toward the gate...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nThe creature is struck down and launched into the darkness before it can reach you.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nStrange Voice: Leave him! He is mine! Come forth warrior and face your death!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nYou know that is going to be the grand master. You know it is time to find out the truth");
            Console.WriteLine("\nand find out why the Grand Master put you here.");
            Console.WriteLine("\nYou know it is time to find out the truth and find out why the Grand Master put you here.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nYou begin to walk towards the gate.... each steps appears to get quicker...");
            Console.WriteLine("\nyou are ready for this... you must know. You open the gate...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nAs you enter the room... it vast and well lit. Luxurious with a throne...");
            Console.WriteLine("\nThis person lives like a king! You see a cloaked figure stading.");
            Console.WriteLine("\nin the centre of the room. This is it!! It's time to fight!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nGrand Wizard: Before I destroy, I will tell you why I abducted you.");
            Console.WriteLine("\n45 years ago your father killed my son! Now I will do the same to him!");
            Console.WriteLine("\nI have been totured by this memory for years! Now you must die so I can have sweet vengence.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nYou realise that your father that never spoke to you was indeed a horrible but great warrior.");
            Console.WriteLine("\nYou understand the Grand Wizards frustration.");
            Console.WriteLine("\nBut you are not here to die, you want to live. And so the battle begins!");
            Encounters.GrandWizard();
            Encounters.GrandWizardRegen(); 
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nCongratulations you have defeated the grand wizard! You see a doorway appear and a great light shine through!");
            Console.WriteLine("\nYou see a doorway appear and a great light shine through! It is done.");
            Console.WriteLine("\nTired and beat up, you stumble toward the door and you are teleported back, to where things are more familiar.");
            Console.WriteLine("\nYou are home!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nThings are more familiar here, you are home!");
            Console.WriteLine("\nYou see a mist like substance fade from your amulet... the spirit is free as well!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nThank you for playing dungeon master!");
            Console.ReadKey();

        }
    }
}