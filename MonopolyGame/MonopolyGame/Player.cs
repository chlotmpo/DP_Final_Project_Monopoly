using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Player : AbstractObserver
    {
        // TODO : define all the attributes that we need to correclty instantiate a player

        private string message; //attribute that correspond to the message that will be send to the player as an observer

        public Player()
        {
        }

        public string name;

        public bool inJail;

        public double cash;

        /// <summary>
        /// @return
        /// </summary>
        public int RollDices()
        {
            // TODO implement here
            return 0;
        }

        public void MoveToPosition()
        {
            // TODO implement here
        }

        /// <summary>
        /// Method used to show the message associated with any update
        /// </summary>
        public override void Update()
        {
            Console.WriteLine(message);
        }
    }
}
