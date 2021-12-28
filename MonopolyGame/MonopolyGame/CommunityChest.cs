using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class CommunityChest : ICell
    {
        #region Attributes
        // TODO : define all the attributes that we need to correclty instantiate a community chest cell
        private int number; // defines the number of the card
        private string message; // represents the message in the card for the player 
        private int bonus; // represents a money bonus for the player if the card said so 
        private int debt; // represent an amount of moner that the player will have to pay if the card said so
        private bool free_jail; // represents the card that can save a player from jail
        private bool go_in_jail; // represents the card that can send the player to the jail
        private int position; // represents the position of where the community chest cell is 
        #endregion 

        #region Constructors  
        public CommunityChest() { }
        public CommunityChest(int position)
        {
            this.position = position;
            bonus = 0;
            debt = 0;
            free_jail = false;
            go_in_jail = false;
            number = Community_Chest_number();
            message = Community_Chest_message();
        }
        #endregion


        #region Properties 
        public int Number
        {
            get { return number; }
        }
        public string Message
        {
            get { return message; }
        }
        public int Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }
        public bool Free_jail
        {
            get { return free_jail; }
            set { free_jail = value; }
        }
        public bool Go_in_jail
        {
            get { return go_in_jail; }
            set { go_in_jail = value; }
        }
        public int Position
        {
            get { return position; }
            set { this.position = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that will generate a random int between 1 and 10
        /// </summary>
        /// <returns></returns>
        public int Community_Chest_number()
        {
            // we create a random object (maybe create a random object in the game and pass it in the parameters)
            Random rdm2 = new Random();

            // now we want to have a random int between the values 1 and 10, to do so we use the following function associated to the random object
            int number = rdm2.Next(1, 11);

            // we return this random int
            return number;
        }

        /// <summary>
        /// Method that will associate a message to the random chance number defined
        /// </summary>
        /// <returns></returns>
        public string Community_Chest_message()
        {
            string msg = "";
            switch (this.number)
            {
                case (1):
                    bonus = 200;
                    msg = "Advance to the Go Cell and collect $200.";
                    break;
                case (2):
                    bonus = 200;
                    msg = "Bank error in your favor";
                    break;
                case (3):
                    debt = 50;
                    msg = "Doctor's fee. Pay $50";
                    break;
                case (4):
                    bonus = 50;
                    msg = "From sale of stock you get $50";
                    break;
                case (5):
                    free_jail = true;
                    msg = "Get out of jail free";
                    break;
                case (6):
                    go_in_jail = true;
                    msg = "Go to Jail. Go directly to jail, do not pass Go, do not collect $200";
                    break;
                case (7):
                    bonus = 100;
                    msg = "Holiday fund matures. Receive $100";
                    break;
                case (8):
                    debt = 100;
                    msg = "Pay hospital fees of $100";
                    break;
                case (9):
                    debt = 50;
                    msg = "Pay school fees of $50";
                    break;
                case (10):
                    bonus = 10;
                    msg = "You have won second prize in a beauty contest. Collect $10";
                    break;

            }
            return msg;
        }

        /// <summary>
        /// Method that give a description of this community chest cell
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string content = "Cell position : " + position + "\nCommunity Chest n° : " + number + "\nMessage : " + message;
            if (bonus != 0) { content += "\nYou won $" + bonus; }
            else if (debt != 0) { content += "\nYou have to pay $" + debt + " to the bank"; }
            return content;
        }

        //public override string GetCellName(int position) { return $"CommunityChest ({position})"; }
        #endregion
    }
}
