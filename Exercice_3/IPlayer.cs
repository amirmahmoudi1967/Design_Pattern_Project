using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_Project_Ex3_Monopoly
{
    interface IPlayer
    {
        bool InJail { get; }
        string Name { get; set; }
        int JailTime { get; set; }
        int Lap { get; set; }
        int Position { get; set; }
        void Movement(int val_dice);
        void Jail();
        void Game_start();
        int[] Dice_Randomizer();
    }
}
