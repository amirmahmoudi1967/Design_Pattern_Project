using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

public class Game
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
        int maxLap = 0;
        int maxPosition = 0;
        int bestPlayer = -1;


        /*set names*/
        Thread[] t = new Thread[players.Count];
        for (int i = 0; i < players.Count; i++)
        {
            Console.WriteLine("\n set name of player " + i);
            string name = Console.ReadLine();
            players[i].Name = name;
            players[i].nbturn_set = nbTurn;
        }
        /* threading player */
        for (int i = 0; i < players.Count; i++)
        {
            t[i] = new Thread(new ThreadStart(players[i].execute));
            t[i].Start();
        }

        // Here I need to wait all the threads to have ended
        foreach (Thread th in t)
            th.Join();


        // Result
        for (int i = 0; i < players.Count; i++)
        {
            if (maxLap < players[i].Lap || (maxLap == players[i].Lap && maxPosition < players[i].Position))
            {
                bestPlayer = i;
                maxLap = players[i].Lap;
                maxPosition = players[i].Position;
            }

            Console.WriteLine("Players " + players[i].Name + " completed " + players[i].Lap + " lap(s) and is in position " + players[i].Position);
        }

        Console.WriteLine("Players " + players[bestPlayer].Name + " Win!");
    }
}