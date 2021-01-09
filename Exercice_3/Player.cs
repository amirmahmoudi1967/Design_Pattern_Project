using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace DesignPattern_Project_Ex3_Monopoly
{
    public class Player : IPlayer
    {
        /*btw 0 and 39*/
        private int position;
        private bool JailState;
        private int jail_time;
        private string name;
        private int lap;
        private int round_nb;

        public int nbturn_set
        {
            set { round_nb = value; }
            get { return round_nb; }
        }

        public bool InJail
        {
            get { return JailState; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int JailTime
        {
            get { return jail_time; }
            set { jail_time = value; }
        }
        public int Lap
        {
            get { return lap; }
            set { lap = value; }
        }
        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public Player()
        {
            position = 0;
            JailState = false;
            lap = 0;
        }

        public void Movement(int val)
        {
            position = position + val;

            // For a full turn of our gameboard. 
            if ((position + val) > 39)
            {
                position = position + val - 40;
                lap++;
            }
        }
        public void Jail()
        {
            Console.WriteLine("The player " + name + " got in jail !");
            position = 10;
            JailState = true;
            jail_time = 0;
        }
        public int[] Dice_Randomizer()
        {
            int[] array = new int[2];
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 7);
            }
            return array;
        }

        public void Game_start()
        {
            // Inserting a thread. 

            for (int j = 0; j < round_nb; j++)
            {

                int[] res_dices;
                int sum_dices;
                int same_dices = 0;
                do
                {
                    res_dices = Dice_Randomizer();
                    sum_dices = res_dices[0] + res_dices[1];
                    if (res_dices[1] == res_dices[0])
                    {
                        same_dices++;
                    }
                    if (same_dices >= 3)
                    {
                        Jail();
                    }

                    if (InJail)
                    {
                        if (res_dices[1] == res_dices[0] || JailTime >= 3)
                        {
                            Movement(sum_dices);
                            jail_time = 0;
                        }
                        else
                        {
                            jail_time++;
                        }
                    }

                    if (!InJail)
                    {
                        Movement(sum_dices);
                        if (position == 30)
                        {
                            Jail();
                        }
                    }
                } while (res_dices[1] == res_dices[0] && same_dices < 3);
                same_dices = 0;
            }
        }


    }
}
