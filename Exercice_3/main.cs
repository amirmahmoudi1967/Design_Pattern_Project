using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Monopoly! Choose a number of players : ");
        int NumberOfPlayers = Convert.ToInt32(Console.ReadLine());
        Game one = new Game(NumberOfPlayers);
        Console.WriteLine("Choose a number of turn before the end : ");
        int NbOfTrun = Convert.ToInt32(Console.ReadLine());
        one.Play(NbOfTrun);
        Console.ReadKey();
    }
}
