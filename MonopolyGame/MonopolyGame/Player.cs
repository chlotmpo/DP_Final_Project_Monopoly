using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Player : AbstractObserver
    {
        #region Attributes
        private string name; // represents the name of the player 
        private int current_position; // represents the current position of the player in the game 
        private double money; // represents the amount of available money of the player 
        private List<Property> owned_properties; // represents the list of all the properties owned by the player
        private bool is_in_jail; // represents the status of the player if he is in jail
        private int fails_to_exit_jail; // represents the number of unsuccessful attempts to exit jail (max = 3 attemps)
        private bool visit_only; // represents the status of the player if he is on visit only in the jail cell
        private string message; // attribute that correspond to the message that will be send to the player as an observer
        private bool lose; // will be true is the player lose
        private bool joker_exit_jail; //represents a card that allow the player to be free of jail. Can be delivered by a chance or community chest cell

        Random rdm = new Random();
        #endregion

        #region Constructors
        public Player() { }
        public Player(string name)
        {
            this.name = name.ToUpper();
            current_position = 0;
            money = 500;
            owned_properties = new List<Property>();
            is_in_jail = false;
            fails_to_exit_jail = 0;
            visit_only = false;
            lose = false;
            joker_exit_jail = false;
        }
        #endregion

        #region Properties
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
        public int Fails_to_exit_jail
        {
            get { return fails_to_exit_jail; }
            set { fails_to_exit_jail = value; }
        }
        public bool Visit_only
        {
            get { return visit_only; }
            set { visit_only = value; }
        }
        public bool Lose
        {
            get { return lose; }
            set { lose = value; }
        }
        public bool Joker_exit_jail
        {
            get { return joker_exit_jail; }
            set { joker_exit_jail = value; }
        }
        public Random Rdm
        {
            get { return rdm; }
        }
        #endregion

        #region Methods 
        /// <summary>
        /// Method that will return the result of the 2 dice rolling by the player
        /// </summary>
        /// <returns></returns>
        public int[] RollsDice(Random rdm)
        {
            // we use a random object in order to have a random number between 1 and 6 include
            int dice1 = rdm.Next(1, 7);
            int dice2 = rdm.Next(1, 7);

            //int dice1 = 1;
            //int dice2 = 1;

            // creating the tab that contain the results of the two rolled dice
            int[] result_dice = new int[] { dice1, dice2 };

            // we return the result
            return result_dice;
        }

        /// <summary>
        /// Method that will move the player forward from his current position with a number defined before with the rolling dice
        /// </summary>
        /// <param name="dice"> The set of 2 dice </param>
        public void MoveToPosition(int[] dice, ICell[] boardGame)
        {
            visit_only = false;

            int move_number = dice[0] + dice[1];
            int actual_position = this.current_position;

            // We make sure the current_position added to the move number won't go further 39 (the board length)
            this.current_position = (this.current_position + move_number) % 39;

            if (this.current_position == 10) this.visit_only = true; // if the player lands on Jail cell (cell number 10)


            if (this.current_position == 30) // if the player lands on Go To Jail cell (cell number 30)
            {
                Console.WriteLine("Oh no! You land on the cell 'Go to Jail!'. I'm sorry but you have to go directly in jail buddy");
                this.current_position = 10; // move player to Jail
                this.is_in_jail = true; // In Jail status is changed
                Jail j = (Jail)boardGame[10];
                j.List_player_in_jail.Add(this.name); //we add the name of this player in the list of the players currently in jail.
                boardGame[10] = j; //the status of the jail is actualized
            }
            else // if he didn't end up in jail, then he can collect the bonus
            {
                if (current_position < actual_position) // This means that the player has begun a new turn on the board
                {
                    money += 200; //if the player has passed or is on the go cell. He will therefore receive a money bonus. 
                    if (this.current_position == 0) money += 200; // and if the player lands precisely ON the go cell, the bonus is doubled
                }
            }

        }



        /// <summary>
        /// This method establish if the player can exit jail or not
        /// </summary>
        /// <param name="dice"> set of dice rolled by the player </param>
        /// <returns> true if the player can exit jail </returns>
        public bool CanExitJail(int[] dice, ICell[] boardGame)
        {
            bool exit_jail = false;
            Console.WriteLine("You're in jail. Number of turn : " + (fails_to_exit_jail + 1));

            if (joker_exit_jail) //if the player had a joker card, he can go out of jail
            {
                exit_jail = true;
                joker_exit_jail = false; // the card is no longer available
            }
            else if (dice[0] == dice[1]) // The player hit a set of doubles
            {
                Console.WriteLine("Wow! This double allows you to be free!");
                exit_jail = true; // The player can exit of jail
                this.fails_to_exit_jail = 0;
            }
            else
            {
                if (this.fails_to_exit_jail == 2) // The player failed to roll both dice with the same value for three times in a row (i.e. his previous two turns after moving to jail and his current turn).
                {
                    Console.WriteLine("You wait 3 turns, that's enough :)");
                    exit_jail = true; // He is out of jail
                    this.fails_to_exit_jail = 0;
                }
                else // if(this.fails_to_exit_jail < 2)
                {
                    Console.WriteLine("Not this time ! :( This is not a double!");
                    exit_jail = false;
                    this.fails_to_exit_jail += 1; // The player stays in jail for another turn
                }
            }

            if(exit_jail) //if the player can go out of jail
            {
                Jail j = (Jail)boardGame[10];
                j.List_player_in_jail.Remove(this.name); //we remove this player n the list of the player currently in jail
                boardGame[10] = j;
            }

            return exit_jail;
        }

        /// <summary>
        /// Method that will verify if a player has enough money to buy something
        /// </summary>
        /// <param name="price">Price that we will compare with the money of the player</param>
        /// <returns></returns>
        public bool EnoughMoneyToBuy(int price)
        {
            bool enough = false;
            if (price <= money) enough = true;
            return enough;
        }

        /// <summary>
        /// Method that will determine if the player possess all the property of the same family or not
        /// </summary>
        /// <param name="property">The current property</param>
        /// <returns></returns>
        public bool FamilyComplete(Property property)
        {
            bool family_complete = false;

            //we first collect the label of the observed property and the number of member of it's family
            string name = property.Name;
            string label = property.Label;
            int nb_family = property.Number_family;

            int counter = 1;

            for (int i = 0; i < owned_properties.Count; i++)
            {
                //we count the number of properties of the same family the player own
                if (owned_properties[i].Label == label && owned_properties[i].Name != name) counter++;
            }

            if (counter == nb_family) family_complete = true;
            return family_complete;
        }

        /// <summary>
        /// Method that count the number of Railroads property owned by the actual player
        /// </summary>
        /// <returns> Number of railroads </returns>
        public int NumberOfRailroads()
        {
            int counter = 0;
            owned_properties.ForEach(delegate (Property p) { if (p.Label == "Railroad") counter++; });
            return counter;
        }

        /// <summary>
        /// Method used to show the message associated with any update
        /// </summary>
        public override void Update(string property_name, int property_position, string name_owner)
        {
            message = "\n\nMessage for the observer (player) : " + name + "\n";
            message += name_owner + " has juste bought the property : " + property_name + "! It is at the position : " + property_position;
            message += "\nBe aware! You will have to pay this player if you land on this cell!";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Method that give all the informations about the current player
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string content = "Player : " + name + "\nYou are in the position " + current_position + " in the game board.\nYou have $" + money;
            if (owned_properties.Count != 0)
            {
                content += "\nYou own the following properties : ";
                for (int i = 0; i <= owned_properties.Count -1; i++)
                {
                    content += owned_properties[i].DescriptionProperty();
                }
            }
            else content += "\nYou own 0 property right now.";
            if (is_in_jail) content += "\nWARNING : YOU ARE IN JAIL !!";
            if (visit_only) content += "\nYou are actually in the jail for a visit.";
            return content;
        }
        #endregion
    }
}
