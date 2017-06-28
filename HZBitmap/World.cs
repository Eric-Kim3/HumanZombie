using System;

namespace HZBitmap
{
    class World
    {
        protected int xSize;
        protected int ySize;
        protected int xDir;
        protected int yDir;
        private int xLocation;
        private int yLocation;
        protected Creature[,] objWorld;

        public World() { }
        #region Initialize World
        public World(int x, int y)
        {
            xSize = x;
            ySize = y;
            objWorld = new Creature[x, y];

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Creature c = new Creature();
                    objWorld[j, i] = c;
                }
            }
        }
        #endregion

        #region Move
        public void Move()
        {
            for (int a = 0; a < ySize; a++)
            {
                for (int b = 0; b < xSize; b++)
                {
                    xLocation = b;
                    yLocation = a;
                    RandomDirection();
                    switch (objWorld[b, a].getChar)
                    {
                        case 'H':
                            {
                                if (ValidateDirection() == 0)
                                {
                                    //if the direction meets the standard, move
                                    CreatureMove(b, a);
                                    objWorld[b, a].getTried = -1;
                                }

                                else if (ValidateDirection() == 2 && objWorld[b, a].getTurns >= 7)
                                {
                                    //if last spot to move is a zombie, kill the zombie
                                    KillCreature(b, a, 'H');
                                }

                                else if (objWorld[b, a].getTried < 8 && objWorld[b, a].getTried > 4) //after 4th attempt, it tries to find an empty spot
                                {
                                    if (EmptySpaceAround(b, a) != -1)
                                    {
                                        //if empty space is n
                                        MoveCertainDirection(EmptySpaceAround(b, a));
                                        CreatureMove(b, a);
                                        objWorld[b, a].getTried = -1;
                                    }
                                    else
                                    {
                                        Die(b, a, 6);
                                    }

                                }
                                //Runs reproduce method
                                //Method will check to see if it meets the standard to reproduce
                                Reproduce(b, a);
                                Die(b, a, 6);

                                break;
                            }
                        case 'Z':
                            {
                                //kills creature before it goes through any process if it has been moved 5 times.
                                Die(b, a, 5);
                                if (ValidateDirection() == 0)
                                {
                                    CreatureMove(b, a);
                                    objWorld[b, a].getTried = -1;
                                }
                                else if (ValidateDirection() == 1)
                                {
                                    KillCreature(b, a, 'Z');
                                }

                                else if (objWorld[b, a].getTried < 8 && objWorld[b, a].getTried > 7) //after 4th attempt, it tries to find an empty spot
                                {
                                    if (EmptySpaceAround(b, a) != -1)
                                    {
                                        MoveCertainDirection(EmptySpaceAround(b, a));
                                        CreatureMove(b, a);
                                        objWorld[b, a].getTried = -1;
                                    }
                                    else
                                    {
                                        Die(b, a, 5);
                                    }
                                }

                                //Die(b, a, 5);
                                break;

                            }
                    }
                    //sets current creature Moved value to True so if the loop hits the moved creature, it doesn't go through process again
                    objWorld[b, a].getMoved = true;
                }
            }
            //sets all creatures' Moved value to false
            for (int j = 0; j < ySize; j++)
            {
                for (int i = 0; i < xSize; i++)
                {
                    objWorld[i, j].getMoved = false;
                }
            }
        }
        #endregion

        #region KillsCreature
        private void KillCreature(int x, int y, char c)
        {
            //Kills Creature and turns the killer moved to true and new creature to false.
            try
            {
                objWorld[x + xDir, y + yDir].getChar = c;
                objWorld[x + xDir, y + yDir].getTurns = 0;
                objWorld[x + xDir, y + yDir].getTried = -1;
                objWorld[x + xDir, y + yDir].getMoved = false;
                objWorld[x, y].getTurns = 0;
                objWorld[x, y].getTried = -1;
                objWorld[x, y].getMoved = true;
            }
            catch (IndexOutOfRangeException ex)
            {
            }
        }
        #endregion

        #region Die
        private void Die(int x, int y, int turns)
        {
            //The Creature dies if its turn is greater or equal to "Turns"
            if (objWorld[x, y].getTurns >= turns)
            {
                Nullify(x, y);
            }
        }
        #endregion

        #region Nullify
        private void Nullify(int x, int y)
        {
            //Sets current creature to an Empty space
            objWorld[x, y].getChar = 'O';
            objWorld[x, y].getTurns = 0;
            objWorld[x, y].getTried = 0;
            objWorld[x, y].getMoved = false;
        }
        #endregion

        #region MoveCertainDirection
        public void MoveCertainDirection(int direction)
        {
            //Sets the direction to 0 to ensure the creature doesn't have pre-existing direction
            xDir = 0;
            yDir = 0;
            //It sets which direction to move by the result of the input
            /* 
             * 0 moves left
             * 1 moves right
             * 2 moves up
             * 3 moves down
             * 4 moves left up
             * 5 moves right up
             * 6 moves left down
             * 7 moves right down
            */
            switch (direction)
            {
                case 0: //<
                    {
                        xDir--;
                        break;
                    }
                case 1: //>
                    {
                        xDir++;
                        break;
                    }
                case 2: //^
                    {
                        yDir--;
                        break;

                    }
                case 3: //v
                    {
                        yDir++;
                        break;
                    }
                case 4: //<^
                    {
                        xDir--;
                        yDir--;
                        break;
                    }
                case 5: //>^
                    {
                        xDir++;
                        yDir--;
                        break;
                    }
                case 6: //<v
                    {
                        xDir--;
                        yDir++;
                        break;
                    }
                case 7: //>v
                    {
                        xDir++;
                        yDir++;
                        break;
                    }
                case -1:
                    {

                        break;
                    }

            }
        }
        #endregion

        #region EmptySpaceAround
        public int EmptySpaceAround(int x, int y)
        {
            //checks the x and y to see if it's inside the scope
            /*Returns number to see which direction is empty
             * 0 empty space on left
             * 1 empty space on right
             * 2 empty space on up
             * 3 empty space on down
             * 4 empty space on left up
             * 5 empty space on right up
             * 6 empty space on right down
             * 7 empty space on left down
            */
            if (x + 1 < objWorld.GetLength(0) && y + 1 < objWorld.GetLength(1) && x - 1 >= 0 && y - 1 >= 0)
            {
                if (objWorld[x - 1, y].getChar == 'O')
                    return 0;
                if (objWorld[x + 1, y].getChar == 'O')
                    return 1;
                if (objWorld[x, y - 1].getChar == 'O')
                    return 2;
                if (objWorld[x, y + 1].getChar == 'O')
                    return 3;
                if (objWorld[x - 1, y - 1].getChar == 'O')
                    return 4;
                if (objWorld[x + 1, y - 1].getChar == 'O')
                    return 5;
                if (objWorld[x + 1, y + 1].getChar == 'O')
                    return 6;
                if (objWorld[x - 1, y + 1].getChar == 'O')
                    return 7;
            }
            return -1;
        }
        #endregion

        #region CreatureMove
        public void CreatureMove(int x, int y)
        {
            //Checks boundry of the direction it is moving
            //Moves the creature to that place.
            //try to move, if boundrycheck doesn't work then
            //gets another direction to move and moves

            try
            {
                if (BoundryCheck(x, y))
                {
                    objWorld[x + xDir, y + yDir].getChar = objWorld[x, y].getChar;
                    objWorld[x + xDir, y + yDir].getMoved = true;
                    objWorld[x + xDir, y + yDir].getTurns++;
                    objWorld[x, y].getChar = 'O';
                }

                else
                {
                    RandomDirection();
                    CreatureMove(x, y);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
            }
        }
        #endregion

        #region Reproduce
        public void Reproduce(int x, int y)
        {
            //checks if 5 turns has been processed before reproducing
            if (objWorld[x, y].getTurns == 5)
            {
                if (BoundryCheck(x, y))
                {
                    if (EmptySpaceAround(x, y) != -1)
                    {
                        MoveCertainDirection(EmptySpaceAround(x, y));
                        objWorld[x, y].getChar = 'H';
                        objWorld[x, y].getMoved = true;
                        objWorld[x, y].getTried = 0;
                    }
                }
            }
        }
        #endregion

        #region BoundryCheck
        public bool BoundryCheck(int x, int y)
        {
            int xCheck = x + xDir;
            int yCheck = y + yDir;
            return (xCheck >= 0 && yCheck >= 0 && xCheck < objWorld.GetLength(0) && yCheck < objWorld.GetLength(1));
        }
        #endregion

        #region PlaceCreature
        public void PlaceCreature(int numHuman, int numZombie)
        {
            //calls InputCreature to place creatures on its random place
            InputCreature(numHuman, 'H');
            InputCreature(numZombie, 'Z');
        }
        #endregion

        #region InputCreature
        private void InputCreature(int numCreature, char whatCreature)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < numCreature; i++)
            {
                //gets random number of its x and y to place
                int xRand = rnd.Next(xSize);
                int yRand = rnd.Next(ySize);
                //check to see if that random place is empty 
                bool objCheck = (objWorld[xRand, yRand].getChar != 'Z') && (objWorld[xRand, yRand].getChar != 'H') && (objWorld[xRand, yRand].getChar == 'O');

                if (objCheck)
                {
                    objWorld[xRand, yRand].getChar = whatCreature;
                    objWorld[xRand, yRand].getXlocation = xRand;
                    objWorld[xRand, yRand].getYlocation = yRand;

                }
                else
                    i--;
            }
        }
        #endregion

        #region ValidateDirection
        public int ValidateDirection()
        {
            //checks boundry first
            //Returns value to the direction
            /* 0 is Empty
             * 1 is Human
             * 2 is Zombie
            */
            if (BoundryCheck(xLocation, yLocation))
            {
                try
                {
                    if (objWorld[xLocation + xDir, yLocation + yDir].getChar == 'O')
                        return 0;
                    if (objWorld[xLocation + xDir, yLocation + yDir].getChar == 'H')
                        return 1;
                    if (objWorld[xLocation + xDir, yLocation + yDir].getChar == 'Z')
                        return 2;
                    return 3;
                }
                catch (IndexOutOfRangeException ex)
                {
                }
            }
            return 3;
        }
        #endregion

        #region RandomDirection
        public void RandomDirection()
        {
            //ensures direction is set to zero
            xDir = 0;
            yDir = 0;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int _rnd = rnd.Next(0, 200);
            int randomNum;
            /* 0 to 24 is 0
             * 25 to 49 is 1
             * 50 to 74 is 2
             * 75 to 99 is 3
             * 100 to 124 is 4
             * 125 to 149 is 5
             * 150 to 174 is 6
             * 175 to 199 is 7
            */
            if (_rnd < 25)
                randomNum = 0;
            else if (_rnd >= 25 && _rnd < 50)
                randomNum = 1;
            else if (_rnd >= 50 && _rnd < 75)
                randomNum = 2;
            else if (_rnd >= 75 && _rnd < 100)
                randomNum = 3;
            else if (_rnd >= 100 && _rnd < 125)
                randomNum = 4;
            else if (_rnd >= 125 && _rnd < 150)
                randomNum = 5;
            else if (_rnd >= 150 && _rnd < 175)
                randomNum = 6;
            else
                randomNum = 7;

            //It sets which direction to move by the result of the input
            /* 
             * 0 moves left
             * 1 moves right
             * 2 moves up
             * 3 moves down
             * 4 moves left up
             * 5 moves right up
             * 6 moves left down
             * 7 moves right down
            */
            switch (randomNum)
            {
                case 0: //<
                    {
                        xDir--;
                        break;
                    }
                case 1: //>
                    {
                        xDir++;
                        break;
                    }
                case 2: //^
                    {
                        yDir--;
                        break;

                    }
                case 3: //v
                    {
                        yDir++;
                        break;
                    }
                case 4: //<^
                    {
                        xDir--;
                        yDir--;
                        break;
                    }
                case 5: //>^
                    {
                        xDir++;
                        yDir--;
                        break;
                    }
                case 6: //<v
                    {
                        xDir--;
                        yDir++;
                        break;
                    }
                case 7: //>v
                    {
                        xDir++;
                        yDir++;
                        break;
                    }
            }
        }
        #endregion

        #region getWorld
        public char[,] getWorld
        {
            get
            {
                char[,] tWorld = new char[xSize, ySize];
                for (int j = 0; j < ySize; j++)
                {
                    for (int i = 0; i < xSize; i++)
                    {
                        tWorld[i, j] = objWorld[i, j].getChar;
                    }
                }

                return tWorld;
            }
        }
        #endregion

    }
}
