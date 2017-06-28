using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZBitmap
{
    class Creature
    {
        private int turns;
        private bool moved;
        private int xLocation;
        private int yLocation;
        private char charCr;
        private int tried;

        public Creature()
        {
            charCr = 'O';
            turns = 0;
            moved = false;

        }
        public int getTried
        {
            get { return tried; }
            set { tried = value; }
        }
        public int getYlocation
        {
            get { return yLocation; }
            set { yLocation = value; }
        }
        public int getXlocation
        {
            get { return xLocation; }
            set { xLocation = value; }
        }
        public int getTurns
        {
            get { return turns; }
            set { turns = value; }
        }
        public bool getMoved
        {
            get { return moved; }
            set { moved = value; }
        }
        public char getChar
        {
            get { return charCr; }
            set { charCr = value; }
        }
    }
}
