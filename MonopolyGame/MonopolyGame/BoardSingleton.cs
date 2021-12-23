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
