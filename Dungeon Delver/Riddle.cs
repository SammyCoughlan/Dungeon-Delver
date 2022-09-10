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
            string[,] RiddleArray = { {"Riddle","choice 1","Choice 2", "Choice 3","Correct answer"},
                                           {"Riddle","choice 1","Choice 2", "Choice 3","Correct Answer"},
                                           {"Riddle","choice 1","Choice 2", "Choice 3","Correct Answer"} };
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

        //help converting a string to integer from Stack Overflow user Sujith Karivelil
        //https://stackoverflow.com/questions/36003874/c-sharp-parsing-or-creating-int-and-string-from-readline

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
