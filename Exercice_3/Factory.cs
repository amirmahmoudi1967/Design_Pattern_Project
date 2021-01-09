using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern_Project_Ex3_Monopoly
{
    public static class Factory
    {
        public static Player CreatePlayer()
        {
            return new Player();
        }

    }
}
