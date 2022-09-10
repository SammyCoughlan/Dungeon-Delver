using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver
{
    class ROOM
    {

        internal string PuzzleType;
        internal bool Win;



        internal void Description()
        {
            Console.WriteLine("As you enter the room, the closes behind you. You turn only to see a smooth wall with no sign of the door you just came through. Above you letters begin to write in the air. They stay afloat, reading: " + PuzzleType);
            Console.WriteLine("You stand a moment, preparing yourself. Press any button to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        internal virtual void Enter()
        {
            Description();

        }

        internal virtual bool Obstacle()
        {
            bool succeed = false;
            return succeed;

        }

    }
}
