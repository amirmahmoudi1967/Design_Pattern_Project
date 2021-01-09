using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;


namespace DesignPattern_Project_Ex3_Monopoly
{
    class Game
    {

        private List<Player> players = new List<Player>();

        public Game(int nbPlayers)
        {
            for (int i = 0; i < nbPlayers; i++)
            {
                players.Add(Factory.CreatePlayer());
                players[i].Name = Convert.ToString(i);
            }
        }
        public void Play(int nbTurn)
        {
            int max_lap = 0;
            int max_pos = 0;
            int bestPlayer = -1;


            // Setting names 
            Thread[] t = new Thread[players.Count];
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine("\n set name of player " + i);
                string name = Console.ReadLine();
                players[i].Name = name;
                players[i].nbturn_set = nbTurn;
            }
            // Using threads for each player
            for (int i = 0; i < players.Count; i++)
            {
                t[i] = new Thread(new ThreadStart(players[i].Game_start));
                t[i].Start();
            }

            // We need to wait for the threads to end 
            foreach (Thread th in t)
                th.Join();


            // Result
            for (int i = 0; i < players.Count; i++)
            {
                if (max_lap < players[i].Lap || (max_lap == players[i].Lap && max_pos < players[i].Position))
                {
                    bestPlayer = i;
                    max_lap = players[i].Lap;
                    max_pos = players[i].Position;
                }

                Console.WriteLine("Players " + players[i].Name + " completed " + players[i].Lap + " lap(s) and is in position " + players[i].Position);
            }

            Console.WriteLine("Players " + players[bestPlayer].Name + " Win!");
        }

    }
}
