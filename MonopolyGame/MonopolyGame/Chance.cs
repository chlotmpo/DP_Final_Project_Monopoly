using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Chance : ICell
    {
        #region Attributes
        // TODO : define all the attributes that we need to correclty instantiate a chance cell
        private int number; // defines the number of the card
        private string message; // represents the message in the card for the player 
        private int bonus; // represents a money bonus for the player if the card said so 
        private int debt; // represent an amount of moner that the player will have to pay if the card said so
        private bool free_jail; // represents the card that can save a player from jail
        private bool go_in_jail; // represents the card that can send the player to the jail
        private int position; // represents the position of where the chance cell is 
        #endregion

        #region Constructors 
        public Chance () { }
        public Chance(int position)
        {
            this.position = position;
            bonus = 0;
            debt = 0;
            free_jail = false;
            go_in_jail = false;
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
        public int Debt
        {
            get { return debt; }
            set { debt = value; }
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
        public int Chance_number()
        {
            // we create a random object (maybe create a random object in the game and pass it in the parameters)
            Random rdm = new Random();

            // now we want to have a random int between the values 1 and 10, to do so we use the following function associated to the random object
            int number = rdm.Next(1, 11);

            // we return this random int
            return number;
        }
        /// <summary>
        /// Method that will associate a message to the random chance number defined
        /// </summary>
        /// <returns></returns>
        public string Chance_message()
        {
            string msg = "";

            bonus = 0;
            debt = 0;

            switch (this.number)
            {
                case (1):
                    bonus = 200;
                    msg = "Advance to the Go Cell and collect $200.";
                    break;
                case (2):
                    free_jail = true;
                    msg = "Get out of Jail Free.";
                    break;
                case (3):
                    go_in_jail = true;
                    msg = "Go to jail. Go directly to Jail, do not pass the Go Cell, do not collect $200.";
                    break;
                case (4):
                    debt = 15;
                    msg = "Speeding fine 15$.";
                    break;
                case (5):
                    bonus = 50;
                    msg = "This is your anniversary. The bank offers you a special money amount of $50.";
                    break;
                case (6):
                    bonus = 300;
                    msg = "Your close friend robbed the bank without getting caught and you know about it. To buy your silence, he pays you $300.";
                    break;
                case (7):
                    bonus = 18;
                    msg = "It's your lucky day. When you walk around here, you find some money on the ground. Get $18.";
                    break;
                case (8):
                    msg = "This chance number is not going to bring you anything or ask you anything today. She just wishes you a good day.";
                    break;
                case (9):
                    debt = 60;
                    msg = "Today is a lucky day for the bank! For goodness's sake you pay her $60.";
                    break;
                case (10):
                    bonus = 76;
                    msg = "You won the lottery. Get $76";
                    break;

            }
            return msg;
        }
        /// <summary>
        /// Method that draw a chance card
        /// </summary>
        public void Draw_Chance()
        {
            number = Chance_number();
            message = Chance_message();
        }
        /// <summary>
        /// Method that give a description of this chance cell
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string content =  "Cell position : " + position + "\nChance n° : " + number + "\nMessage : " + message;
            if (bonus != 0) { content += "\nYou won $" + bonus; }
            else if (debt != 0) { content += "\nYou have to pay $" + debt + " to the bank"; }
            return content;
        }

        //public override string GetCellName(int position)  { return this.name; }

        #endregion
    }
}
