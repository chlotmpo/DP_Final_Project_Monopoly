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

        Random rdm = new Random();
        #endregion

        #region Constructors
        public Player(string name)
        {
            this.name = name.ToUpper();
            current_position = 0;
            money = 1500;
            owned_properties = new List<Property>();
            is_in_jail = false;
            fails_to_exit_jail = 0;
            visit_only = false;
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

            // creating the tab that contain the results of the two rolled dice
            int[] result_dice = new int[] { dice1, dice2 };

            // we return the result
            return result_dice;
        }

        /// <summary>
        /// Method that will move the player forward from his current position with a number defined before with the rolling dice
        /// </summary>
        /// <param name="dice"> The set of 2 dice </param>
        public void MoveToPosition(int[] dice)
        {
            int move_number = dice[0] + dice[1];
            int actual_position = this.current_position;

            // We make sure the current_position added to the move number won't go further 39 (the board length)
            this.current_position = (this.current_position + move_number) % 39;

            if (this.current_position == 10) this.visit_only = true; // if the player lands on Jail cell (cell number 10)

            if (this.current_position == 30) // if the player lands on Go To Jail cell (cell number 30)
            {
                this.current_position = 10; // move player to Jail
                this.is_in_jail = true; // In Jail status is changed
            }
            else
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
        public bool CanExitJail(int[] dice)
        {
            bool exit_jail = false;

            if (dice[0] == dice[1]) // The player hit a set of doubles
            {
                exit_jail = true; // The player can exit of jail
                this.fails_to_exit_jail = 0;
            }
            else
            {
                if (this.fails_to_exit_jail == 2) // The player failed to roll both dice with the same value for three times in a row (i.e. his previous two turns after moving to jail and his current turn).
                {
                    exit_jail = true; // He is out of jail
                    this.fails_to_exit_jail = 0;
                }
                else // if(this.fails_to_exit_jail < 2)
                {
                    exit_jail = false;
                    this.fails_to_exit_jail += 1; // The player stays in jail for another turn
                }
            }

            return exit_jail;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doublesAllowed"></param>
        public void Plays(int doublesAllowed = 2) // A player is only allowed to get 2 doubles in a row (if he hit 3 he goes to jail)
        {
            if (doublesAllowed > 0)
            {
                // DICE - A turn always start by a roll of dice
                int[] dice = RollsDice(this.rdm);
                Console.WriteLine("\nLet's roll the dice:");
                Console.WriteLine(printDice(dice[0]));
                Console.Write(printDice(dice[1]));



                // MOVE AROUND THE BOARD

                if (!this.is_in_jail) // If the player is not currently in jail
                {
                    MoveToPosition(dice);
                }
                else // If the player is in jail
                {
                    if (CanExitJail(dice))
                    {
                        Console.WriteLine(" Somehow you're free, runaway !");
                        MoveToPosition(dice); // if the player eligible to get out of jail then he can move forward. Else, he stays in jail for another turn

                    }
                }

                // ACTION ON CELL - Once arrived at his new position on the board, if he didn't end up in jail he can act with the cell under his feet.
                if (!this.is_in_jail)
                {
                    Console.WriteLine("Action On Cell");
                }

                if (dice[0] == dice[1]) Plays(doublesAllowed - 1);
            }
            else
            {
                this.is_in_jail = true;
                this.current_position = 10;
            }
        }

        public string printDice(int diceNumber)
        {
            string one = " ----- \n" + 
                         "|     |\n" +
                         "|  o  |\n" +
                         "|     |\n" +
                         " ----- \n";

            string two = " ----- \n" +
                         "|   o |\n" +
                         "|     |\n" +
                         "| o   |\n" +
                         " ----- \n";

            string three = " ----- \n" +
                           "| o   |\n" +
                           "|  o  |\n" +
                           "|   o |\n" +
                           " ----- \n";

            string four = " ----- \n" +
                          "| o o |\n" +
                          "|     |\n" +
                          "| o o |\n" +
                          " ----- \n";

            string five = " ----- \n" +
                          "| o o |\n" +
                          "|  o  |\n" +
                          "| o o |\n" +
                          " ----- \n";

            string six = " ----- \n" +
                         "| o o |\n" +
                         "| o o |\n" +
                         "| o o |\n" +
                         " ----- \n";
            
            string[] dice = new string[] { one, two, three, four, five, six };

            return dice[diceNumber - 1];
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
        #endregion
    }
}
