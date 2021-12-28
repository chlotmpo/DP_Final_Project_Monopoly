using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Player : AbstractObserver
    {
        // ATTRIBUTES 

        // TODO : define all the attributes that we need to correclty instantiate a player

        private string name; // represents the name of the player 
        private int current_position; // represents the current position of the player in the game 
        private double money; // represents the amount of available money of the player 
        private List<Property> owned_properties; // represents the list of all the properties owned by the player
        private bool is_in_jail; // represents the status of the player if he is in jail
        private bool visit_only; // represents the status of the player if he is on visit only in the jail cell
        private string message; // attribute that correspond to the message that will be send to the player as an observer


        // CONSTRUCTOR

        public Player(string name)
        {
            this.name = name;
            current_position = 0;
            money = 1500;
            owned_properties = new List<Property>();
            is_in_jail = false;
            visit_only = false;
        }

        // PROPERTIES 

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Current_position
        {
            get { return current_position; }
            set { current_position = value; }
        }
        public double Money
        {
            get { return money; }
            set { money = value; }
        }
        public List<Property> Own_properties
        {
            get { return owned_properties; }
            set { owned_properties = value; }
        }
        public bool Is_in_jail
        {
            get { return is_in_jail; }
            set { is_in_jail = value; }
        }
        public bool Visit_only
        {
            get { return visit_only; }
            set { visit_only = value; }
        }

        // METHODS 

        /// <summary>
        /// Method that will return the result of the 2 dices rolling by the player
        /// </summary>
        /// <returns></returns>
        public int[] RollDices()
        {
            // creating the tab that will contain the results of the two rolled dices
            int[] result_dices = new int[2];

            // we generate a random object in order to have a random number between 1 and 6 include
            Random rdm = new Random();
            int dice1 = rdm.Next(1, 7);
            result_dices[0] = dice1;
            int dice2 = rdm.Next(1, 7);
            result_dices[1] = dice2;

            // we return the result
            return result_dices;

        }

        /// <summary>
        /// Metod that will move the player forward from his current position with a number defined before with the rolling dices
        /// </summary>
        /// <param name="new_position">Represents the integer that contains the value of how many cell the player should go</param>
        public void MoveToPosition(int move_number)
        {
            // first of we will verify that the current_position added to the move number don't go further 40. If yes then the current position will be the following : 
            if (this.current_position + move_number <= 40) this.current_position = current_position + move_number;

            //if not, that meand that the player will go a new trip around the board starting in the go cell. His current_position will be the following : 
            else
            {
                this.current_position = current_position + move_number - 40;

                //the player has passed or is on the go cell. He will therefore receive a money bonus. 
                if (this.current_position == 0) money += 400; // if the player is ON the go cell, the bonus is doubled
                else money += 200;
            }
        }

        /// <summary>
        /// Method used to show the message associated with any update
        /// </summary>
        public override void Update()
        {
            Console.WriteLine(message);
        }

        public override string ToString()
        {
            string content = "Player : " + name + "\nYou are in the position " + current_position + " in the game board.\nYou have $" + money;
            if (owned_properties.Count != 0)
            {
                content += "\nYou own the following properties : ";
                for (int i = 0; i <= owned_properties.Count; i++)
                {
                    Console.WriteLine(" - " + owned_properties[i].DescriptionProperty());
                }
            }
            else content += "\nYou own 0 property right now.";
            if (is_in_jail) content += "\nWARNING : YOU ARE IN JAIL !!";
            if (visit_only) content += "\nYou are actually in the jail for a visit.";
            return content;
        }
    }
}
