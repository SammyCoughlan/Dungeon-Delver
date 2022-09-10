using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Welcome to the Labrynth. Many people enter in hopes of glory, fortune, and recognition. It is a dangerous place where everytime it is entered, its passages shift. Many go in, very few come out, and fewer still escape with anything but fear for this place. And yet, here you stand. Please enter your name: ");

            name = Console.ReadLine();
            Console.WriteLine("Welcome "+ name+". Are you ready to enter? press any key to continue");
            Console.ReadKey();

            Console.WriteLine("Are you a A) Warrior, or a B) Rogue?: ");
            string input = Console.ReadLine();
            if(input== "A")
            {
                Profession = "Warrior";
            }else if(input== "B")
            {
                Profession = "Rogue";
            }
            else
            {
                Console.WriteLine("ERROR: Profession not found");
                Profession = "Warrior";
            }

            room1 = GenerateDungeon();
            room2 = GenerateDungeon();
            room3 = GenerateDungeon();





            room1.Enter();
            if(room1.Obstacle() == false)
            {
                Environment.Exit(0);
            }
            else
            {
                room2.Enter();
                if(room2.Obstacle() == false)
                {
                    Environment.Exit(0);

                }
                else
                {
                    room3.Enter();
                    if( room3.Obstacle() == false)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Having made it successfully through all 3 dungeons, you find yourself in a completley new room. It is filled with gold coin. You win");
                    }
                }
            }
            //room2.Enter();
            //room3.Enter();




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

    }
}
