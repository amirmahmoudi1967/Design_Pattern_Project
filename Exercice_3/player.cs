using System;

interface IPlayer
{
    bool InJail { get; }
    string Name { get; set; }
    int JailTime { get; set; }
    int Lap { get; set; }
    void Move(int val_dice);
    void Jail();
    void execute();
}

public class Player : IPlayer
{
    #region initialisation
    private int timeInJail;
    private bool ifInJail;
    private string name;
    private int nb_turn;
    private int lap;
    private int position;  //Between 0 and 39


    public int set_nb_turn
    {
        set { nb_turn = value; }
        get { return nb_turn; }
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
        get { return position; }
        set { position = value; }
    }

    public Player()
    {
        position = 0;
        ifInJail = false;
        lap = 0;
    }
    #endregion initialisation

    public void Move(int val_dice)
    {
        position = position + val_dice;

        //Implementing the circular game board in case the player reaches position 39 and still needs to move forward. 
        if ((position + val_dice) > 39)
        {
            position = position + val_dice - 40;
            lap++;
        }
    }

    public void Jail()
    {
        Console.WriteLine("Too bad for you" + name+" ! You are in Jail");
        position = 10;
        ifInJail = true;
        timeInJail = 0;
    }

    public void execute()
    {
        for (int j = 0; j < nb_turn; j++)
        {
            int[] resDices;
            int sumDices, dice_1, dice_2;
            int CountDouble = 0;
            do
            {
                Random rnd = new Random();
                dice_1 = rnd.Next(1, 7);
                dice_2 = rnd.Next(1, 7);
                sumDices = dice_1 + dice_2;
                if (dice_1 == dice_2)
                {
                    CountDouble++;
                }
                if (CountDouble >= 3)
                {
                    Jail();
                }


                if (InJail)
                {
                    if (dice_1 == dice_2 || JailTime >= 3)
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
            } while (dice_1 == dice_2 && CountDouble < 3);
            CountDouble = 0;

        }
    }
}
