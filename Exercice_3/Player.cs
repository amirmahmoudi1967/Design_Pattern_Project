using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

public static class Factory
{
    public static Player CreatePlayer()
    {
        return new Player();
    }
}

interface IPlayer
{
    bool InJail { get; }
    string Name { get; set; }
    int JailTime { get; set; }
    int Lap { get; set; }
    int Position { get; set; }
    void Move(int val_dice);
    void Jail();
    void execute();
}

public class Player : IPlayer
{
    /*btw 0 and 39*/
    private int position;
    private bool ifInJail;
    private int timeInJail;
    private string name;
    private int lap;
    private int nbturn;

    public int nbturn_set
    {
        set { nbturn = value; }
        get { return nbturn; }
    }

    public bool InJail
    {
        get { return ifInJail; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int JailTime
    {
        get { return timeInJail; }
        set { timeInJail = value; }
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
        ifInJail = false;
        lap = 0;
    }

    public void Move(int val)
    {
        position = position + val;

        /*if you do a full plateau turn */
        if ((position + val) > 39)
        {
            position = position + val - 40;
            lap++;
        }
    }
    public void Jail()
    {
        Console.WriteLine("No Luck M. " + name);
        position = 10;
        ifInJail = true;
        timeInJail = 0;
    }
    public int[] TwoDice()
    {
        int[] array = new int[2];
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rnd.Next(1, 7);
        }
        return array;
    }

    public void execute()
    {
        /*The game!*/
        /*insert thread*/

        for (int j = 0; j < nbturn; j++)
        {


            /*start of the player i turn*/

            /*dice gestion*/

            /*Double or not Double*/
            int[] resDices;
            int sumDices;
            int CountDouble = 0;
            do
            {
                resDices = TwoDice();
                sumDices = resDices[0] + resDices[1];
                if (resDices[1] == resDices[0])
                {
                    CountDouble++;
                }
                if (CountDouble >= 3)
                {
                    Jail();
                }

                /*let's move a bit (or not)*/
                if (InJail)
                {
                    if (resDices[1] == resDices[0] || JailTime >= 3)
                    {
                        Move(sumDices);
                        timeInJail = 0;
                    }
                    else
                    {
                        timeInJail++;
                    }
                }

                if (!InJail)
                {
                    Move(sumDices);
                    if (position == 30)
                    {
                        Jail();
                    }
                }
            } while (resDices[1] == resDices[0] && CountDouble < 3);
            CountDouble = 0;
        }
    }
}