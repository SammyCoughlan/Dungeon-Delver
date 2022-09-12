using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver
{
    internal class Riddle : ROOM
    {

        //with this multidimensional array, the riddle will always be at 0 and the correct answer at 4
        
        internal override void Enter()
        {
            PuzzleType = "Riddle";
            base.Description();
        }

        internal override bool Obstacle()
        {
            string[,] RiddleArray = { {"What starts with an 'E', and ends with and 'E', but only has one letter in it.","Darkness","Your name", "A Clockface","An Envelope"},
                                           {"You can carry it everywhere you go, and it does not get heavy. What is it?","Darkness","A Clockface", "An Envelope","Your Name"},
                                           {"The more there is, the less you see. What am I?","An Envelope","A Clockface", "Your Name","Darkness"} };
            int riddle;
            var rnd = new Random();
            riddle = rnd.Next(3);

            int correct = rnd.Next(1, 4);

            RiddleArray[riddle, correct] = RiddleArray[riddle, 4];


            Console.WriteLine(RiddleArray[riddle,0]);

            for (int r = 1; r <= 3; r++)
            {
                Console.WriteLine(r +") "+ RiddleArray[riddle, r]);
            }

            Console.WriteLine("Please enter your choice as a number: ");
            string answer = Console.ReadLine();
            int answer1;

        
       

            if (!Int32.TryParse(answer, out answer1))
            {
                Console.WriteLine("ERROR");
            }

            if(answer1 == correct)
            {
                Console.WriteLine("Correct!");
                Win = true;
            }else
            {
                Console.WriteLine("Incorrect.");
                Win = false;
            }
            return Win;
        }

    }
}
