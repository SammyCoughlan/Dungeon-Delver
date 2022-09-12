using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dungeon_Delver
{
    internal class GAME
    {
        

        internal ROOM room1;
        internal ROOM room2;
        internal ROOM room3;
        internal string name;
        public static string Profession;

        internal void Run()
        {
            Console.Clear();
            string Banner = @"
_________          _______    _        _______  ______            _______ _________ _       _________         
\__   __/|\     /|(  ____ \  ( \      (  ___  )(  ___ \ |\     /|(  ____ )\__   __/( (    /|\__   __/|\     /|
   ) (   | )   ( || (    \/  | (      | (   ) || (   ) )( \   / )| (    )|   ) (   |  \  ( |   ) (   | )   ( |
   | |   | (___) || (__      | |      | (___) || (__/ /  \ (_) / | (____)|   | |   |   \ | |   | |   | (___) |
   | |   |  ___  ||  __)     | |      |  ___  ||  __ (    \   /  |     __)   | |   | (\ \) |   | |   |  ___  |
   | |   | (   ) || (        | |      | (   ) || (  \ \    ) (   | (\ (      | |   | | \   |   | |   | (   ) |
   | |   | )   ( || (____/\  | (____/\| )   ( || )___) )   | |   | ) \ \_____) (___| )  \  |   | |   | )   ( |
   )_(   |/     \|(_______/  (_______/|/     \||/ \___/    \_/   |/   \__/\_______/|/    )_)   )_(   |/     \|
                                                                                                              
";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Red;

            Console.WriteLine(Banner);

            Console.ResetColor();

            Console.WriteLine("Welcome to the Labyrintnth. Many people enter in hopes of glory, fortune, and recognition.\nIt is a dangerous place where everytime it is entered, its passages shift.\nMany go in, very few come out, and fewer still escape with anything but fear for this place. \n\nAnd yet, here you stand. Before you enter, are you: ");

            Console.WriteLine("\nA) Warrior \nor a \nB) Rogue?: ");
            string input = Console.ReadLine().ToUpper();

            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please input A or B: ");
                input = Console.ReadLine().ToUpper();
                if (input == "A")
                {
                    Profession = "Warrior";
                }
                else if (input == "B")
                {
                    Profession = "Rogue";
                }
                else
                {
                    Console.WriteLine("ERROR: Profession not found");
                    Profession = "";
                }

            }

            

            Console.WriteLine("And what is your name?: ");
            name = Console.ReadLine();
            
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Please enter a name: ");
                name = Console.ReadLine();
            }

            Console.WriteLine("Welcome: the " + Profession + " " + name + "! Press any key to enter the labyrinth.");
            Console.ReadLine();

            room1 = GenerateDungeon();
            room2 = GenerateDungeon();
            room3 = GenerateDungeon();





            room1.Enter();
            if(room1.Obstacle() == false)
            {
                GameOver();
            }
            else
            {
                room2.Enter();
                if(room2.Obstacle() == false)
                {
                    GameOver();

                }
                else
                {
                    room3.Enter();
                    if( room3.Obstacle() == false)
                    {
                        GameOver();
                    }
                    else
                    {
                        GameWin();
                    }
                }
            }




        }



        internal ROOM GenerateDungeon()
        {
            var rand = new Random();
            int roomtype = rand.Next(2);
            switch (roomtype)
            {
                case 0:
                    ROOM Riddleroom = new Riddle();
                    return Riddleroom;
                    break;
                case 1:
                    ROOM Battleroom = new Battle();
                    return Battleroom;
                    break;
                default:
                    Console.WriteLine("Error switch case");
                    ROOM Defaultroom = new Riddle();
                    return Defaultroom;
                    break;
            }
        }
        internal static void GameOver()
        {
            string input;
            Console.Clear();
            Console.WriteLine("You have failed. but do not feel bad, the Labrynth has claimed many a soul, you are not the first, and you will not be the last.");
            Console.WriteLine("Would you like to try again? Yes or No");
            input = Console.ReadLine().ToLower();
            while (!string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter a valid response (Either Yes or No): ");
                input = Console.ReadLine().ToLower();
            }
            if(input == "yes")
            {
                GAME newGame = new GAME();
                newGame.Run();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        internal void GameWin()
        {
            string input;
            Console.Clear();
            Console.WriteLine("As you step out of the final room, your eyes are greeted with piles upon piles of gleaming Gold, and shimmering treasure. \nYou have bested the labyrinth.\nBefore you can fill you pockets wtih gold, text once again appears in the air.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Continue?");
            Console.ResetColor();
            Console.WriteLine("They hang there menancingly. Do you wish to push you luck once more, or take your gold and escape? \nYes to continue, No to escape:");
            input = Console.ReadLine().ToLower();
            while (!string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter a valid response (Either Yes or No): ");
                input = Console.ReadLine().ToLower();
            }
            if (input == "yes")
            {
                GAME newGame = new GAME();
                newGame.Run();
            }
            else
            {
                Environment.Exit(0);
            }


        }

    }
}
