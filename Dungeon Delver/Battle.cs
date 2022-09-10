using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Delver
{
    internal class Battle : ROOM
    {
        internal int Dodge;
        internal int Attack;
        internal int Health = 5;
        internal int Monster;
        internal int MonHealth;
        internal string choice;
        internal int MonChoice;
        internal int toHit;
        internal int Ac;
        internal int MonToHit;
        internal bool hit;
        internal bool MonHit;

        internal string prof = GAME.Profession;

        //Monster array always has name at 0, Attack at 1, Defense at 2, and Health at 3
        internal object[,] Monsters = { {"Kobold", 1, 5, 1},
                                        {"Goblin", 1, 10, 2},
                                        {"Orc", 5, 12, 3},
                                        {"Owl Bear", 7, 15, 3}
                                      };

        internal override void Enter()
        {
            PuzzleType = "Battle";
            base.Description();
            SummonMonster();
            Stats();

        }

        public void Stats()
        {
            if (prof == "Warrior")
            {
                Dodge = 15;
                Attack = +5;
            }
            else if (prof == "Rogue")
            {
                Dodge = 18;
                Attack = +2;
            }
        }

        internal void SummonMonster()
        {
            //Help converting an object into an int from educba.com
            Random rand = new Random();
            Monster = rand.Next(4);
            MonHealth = Convert.ToInt32(Monsters[Monster, 3]);

            Console.WriteLine("Before you have any more time to explore, you notice something begins to materialize before you. Where once there was nothing, suddenly there is a " + Monsters[Monster, 0] + " standing there waiting for you. you barley have time to open your mouth before it lunges, attacking you.");
        }

        internal override bool Obstacle()
        {
            while (MonHealth > 0 && Health > 0)
            {

                Console.Clear();
                Console.WriteLine("Your health is " + Health + ". The Monsters health is " + MonHealth + ". Press any button to swing.");
                Console.ReadLine();

                Console.WriteLine("You attack!");
                if (PCAttack() == true)
                {
                    Console.WriteLine("You land a mighty blow!");
                    MonHealth--;
                }
                else
                {
                    Console.WriteLine("You swing, but miss!");
                }

                Console.WriteLine("The monster swings...");
                if(MonsterAttack() == true)
                {
                    Console.WriteLine("You try to dodge, but the monster is too quick and lands an attack. You feel the searing burn of a new wound.");
                    Health--;
                }
                else
                {
                    Console.WriteLine("The monster lunges but you nimbly dodge out of the way.");
                }

                Console.WriteLine("Press any button to continue the battle.");
                Console.ReadLine();

            }

            if (MonHealth == 0 && Health != 0)
            {
                Console.WriteLine("With a final blow the monster falls, dissapearing into nothingness before it can hit the ground.");
                Console.WriteLine("With a sacrifice taken, the labrynth rewards you. you feel any wounds you have close and heal, and you no longer feel the exaution of battle.");
                Win = true;
            }
            else if (MonHealth == 0 && Health == 0)
            {
                Console.WriteLine("You and the monster swing at the same time, each landing a blow on the other. You feel the monsters attack tear through you, and you begin to fall, knowing your death is approaching. as you fall, time slows, the world goes dark, and you begin to feel the labrynth stir. It has claimed another soul to itself.");
                Win = false;
            }
            else
            {
                Console.WriteLine("The beast lands a killing blow on you. You feel the monsters attack tear through you, and you begin to fall, knowing your death is approaching. as you fall, time slows, the world goes dark, and you begin to feel the labrynth stir. It has claimed another soul to itself.");
                Win = false;
            }
            return Win;

        }

        internal bool PCAttack()
        {

            toHit = Roll() + Attack;
            if(toHit >= Convert.ToInt32(Monsters[Monster, 2]))
            {
                hit = true;
            }else
            {
                hit = false;
            }

            return hit;
        }

        internal bool MonsterAttack()
        {
            MonToHit = Roll() + Convert.ToInt32(Monsters[Monster, 2]);
            if (MonToHit >= Dodge)
            {
                MonHit = true;
            }
            else
            {
                MonHit = false;
            }
            return MonHit;
        }

        internal int Roll()
        {
            Random d20 = new Random();
            int result = d20.Next(1,21);
            return result;
        }


        
    }
}
