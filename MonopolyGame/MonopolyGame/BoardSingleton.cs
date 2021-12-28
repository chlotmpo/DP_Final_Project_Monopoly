using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public sealed class BoardSingleton
    {

        // ATTRIBUTES 

        private ICell[] boardGame;
        private static BoardSingleton instance = null;
        private static readonly object padlock = new object();
        public static int number_instance;
        

        // CONSTRUCTORS 

        /// <summary>
        /// Private constructor in order to create a unique instance of the game board. This method implements and creates the structure of the board.
        /// </summary>
        BoardSingleton()
        {    

            // first we create a new tab with 40 elements that will represents the board game with 40 possibles positions
            boardGame = new ICell[40];

            //now we will define each element of the game board by creating the correspondinf objects
            boardGame[0] = new Special("Go Cell", 0, true, false, false);
            boardGame[1] = new Property("Vine Street", 60,"Brown", 2, 1);
            boardGame[2] = new CommunityChest(2);
            boardGame[3] = new Property("Coventry Street", 60,"Brown", 2, 3);
            boardGame[4] = new Tax("Income Tax", 200, 4);
            boardGame[5] = new Property("Marylebone Station", 200, "No color", 4, 5);
            boardGame[6] = new Property("Leicester Square", 100, "Light Blue", 3, 6);
            boardGame[7] = new Chance(7);
            boardGame[8] = new Property("Bow Street", 100, "Light Blue", 3, 8);
            boardGame[9] = new Property("Whitechapel Road", 120, "Light Blue", 3, 9);
            boardGame[10] = new Jail(10);
            boardGame[11] = new Property("The Angel, Islington", 140, "Purple", 3, 11);
            boardGame[12] = new Property("Electric Company", 150, "No Color", 2, 12);
            boardGame[13] = new Property("Trafalgar Square", 140, "Purple", 3, 13);
            boardGame[14] = new Property("Northumrl'd Avenue", 160, "Purple", 3, 14);
            boardGame[15] = new Property("Fenchurch St. Station", 200, "No color", 4, 15);
            boardGame[16] = new Property("M'Borough Street", 180, "Orange", 3, 16);
            boardGame[17] = new CommunityChest(17);
            boardGame[18] = new Property("Fleet Street", 180, "Orange", 3, 18);
            boardGame[19] = new Property("Old Kent Road", 200, "Orange", 3, 19);
            boardGame[20] = new Special("Free Parking", 20, false, false, true);
            boardGame[21] = new Property("Whitehall", 220, "Red", 3, 21);
            boardGame[22] = new Chance(22);
            boardGame[23] = new Property("Pentonville Road", 220, "Red", 3, 23);
            boardGame[24] = new Property("Pall Mall", 240, "Red", 3, 24);
            boardGame[25] = new Property("Kings Cross Station", 200, "No color", 4, 25);
            boardGame[26] = new Property("Bond Street", 260, "Yellow", 3, 26);
            boardGame[27] = new Property("Strand", 260, "Yellow", 3, 27);
            boardGame[28] = new Property("Water Works", 150, "No color", 2, 28);
            boardGame[29] = new Property("Regent Street", 280, "Yellow", 3, 29);
            boardGame[30] = new Special("Go to Jail!", 30, false, true, false);
            boardGame[31] = new Property("Euston Road", 300, "Green", 3, 31);
            boardGame[32] = new Property("Piccadilly", 300, "Green", 3, 32);
            boardGame[33] = new CommunityChest(33);
            boardGame[34] = new Property("Oxford Street", 320, "Green", 3, 34);
            boardGame[35] = new Property("Liverpool St. Station", 200, "No color", 4, 35);
            boardGame[36] = new Chance(36);
            boardGame[37] = new Property("Park Lane", 350, "Dark Blue", 2, 37);
            boardGame[38] = new Tax("Luxury Tax", 100, 38);
            boardGame[39] = new Property("Mayfair", 400, "Dark Blue", 2, 39);

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

        // PROPERTIES
        public ICell[] BoardGame
        {
            get { return boardGame; }
            set { this.boardGame = value; }
        }


        // METHODS

    }
}
