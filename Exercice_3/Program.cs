using System;
using System.Collections.Generic;


namespace DesignPattern_Project_Ex3_Monopoly
{
   public class Program
   {
        public static void Main(string[] args)
        {
 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tWelcome to our Monopoly Game!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Project done by Amir MAHMOUDI & Yassine LAHBABI - DIA 4");
            Console.ResetColor();
            Console.WriteLine("\n Please choose the number of players for this game : ");
            int NumberOfPlayers = Convert.ToInt32(Console.ReadLine());
            Game one = new Game(NumberOfPlayers);
            Console.WriteLine(" Please choose the number of turns for the end of the game : ");
            int NbOfTrun = Convert.ToInt32(Console.ReadLine());
            one.Play(NbOfTrun);
            Console.ReadKey();
        }
   }
}
