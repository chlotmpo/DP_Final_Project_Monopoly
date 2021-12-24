using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public sealed class BoardSingleton
    {
        private ICell[] boardGame;
        private static BoardSingleton instance = null;
        private static readonly object padlock = new object();
        public static int number_instance;

        /// <summary>
        /// Private constructor in order to create a unique instance of the game board. This method implements and creates the structure of the board.
        /// </summary>
        BoardSingleton() 
        {
            // TODO : implement the structure of the board here 
            // --> the game board is a table of cell, each cell corresponds to a property or a chance cell or a community chest cell or a tax cell or a jail cell or a neutral cell
            // --> define first the differents parameters in each object that can become a cell and then we can create the board.     

            // first we create a new tab with 40 elements that will represents the board game with 40 possibles positions
            boardGame = new ICell[40];

            //now we will define each element of the game board by creating the correspondinf objects
            boardGame[0] = new Neutral("Go Cell", 0, true);
            boardGame[1] = new Property("Mediterranean Avenue", 60,"Brown", 2, 1);
            boardGame[2] = new CommunityChest(2);
            boardGame[3] = new Property("Baltic Avenue", 60,"Brown", 2, 3);
            boardGame[4] = new Tax("Income Tax", 200, 4);
            boardGame[5] = new Property("Reading RailRoad", 200, "No color", 4, 5);
            boardGame[6] = new Property("Oriental Avenue", 100, "Light Blue", 3, 6);
            boardGame[7] = new Chance(7);
            boardGame[8] = new Property("Vermont Avenue", 100, "Light Blue", 3, 8);
            boardGame[9] = new Property("Connecticut Avenue", 120, "Light Blue", 3, 9);
            boardGame[10] = new Jail(10);
            boardGame[11] = new Property("St. Charles Place", 140, "Purple", 3, 11);
            boardGame[12] = new Property("Electirc Company", 150, "No Color", 2, 12);
            boardGame[13] = new Property("States Avenue", 140, "Purple", 3, 13);
            boardGame[14] = new Property("Virginia Avanue", 160, "Purple", 3, 14);
            boardGame[15] = new Property("Pennsylvania Railroad", 200, "No color", 4, 15);
            boardGame[16] = new Property("St. James Place", 180, "Orange", 3, 16);
            boardGame[17] = new CommunityChest(17);
            boardGame[18] = new Property("Tennesee Avenue", 180, "Orange", 3, 18);
            boardGame[19] = new Property("New York Avenue", 200, "Orange", 3, 19);
            boardGame[20] = new Neutral("Free Parking", 20, false);
            boardGame[21] = new Property("Kentucky Avenue", 220, "Red", 3, 21);
            boardGame[22] = new Chance(22);
            boardGame[23] = new Property("Indiana Avenue", 220, "Red", 3, 23);
            boardGame[24] = new Property("Illinois Avenue", 240, "Red", 3, 24);
            boardGame[25] = new Property("B. & O. Railroad", 200, "No color", 4, 25);
            boardGame[26] = new Property("Atlantic Avenue", 260, "Yellow", 3, 26);
            boardGame[27] = new Property("Ventnor Avenue", 260, "Yellow", 3, 27);
            boardGame[28] = new Property("Water Works", 150, "No color", 2, 28);
            boardGame[29] = new Property("Marvin Gardens", 280, "Yellow", 3, 29);
            boardGame[30] = null;
            boardGame[31] = new Property("Pacific Avenue", 300, "Green", 3, 31);
            boardGame[32] = new Property("North Carolina Avenue", 300, "Green", 3, 32);
            boardGame[33] = new CommunityChest(33);
            boardGame[34] = new Property("Pennsylvania Avenue", 320, "Green", 3, 34);
            boardGame[35] = new Property("Short Line", 200, "No color", 4, 35);
            boardGame[36] = new Chance(36);
            boardGame[37] = new Property("Park Place", 350, "Dark Blue", 2, 37);
            boardGame[38] = new Tax("Luxury Tax", 100, 38);
            boardGame[39] = new Property("Boardwalk", 400, "Dark Blue", 2, 39);

        }
        
        /// <summary>
        /// Method used to create a unique instance of the game board based on the singleton design pattern
        /// </summary>
        /// <returns></returns>
        public static BoardSingleton getInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BoardSingleton();
                        number_instance++; //to test if only one instance has been created
                    }
                    return instance;
                }
            }
        }

        public ICell[] BoardGame
        {
            get { return boardGame; }
            set { this.boardGame = value; }
        }

        //test on the unique instance  
        public override string ToString()
        {
            return "this is a singleton board number : " + number_instance;
        }

    }
}
