using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Program
    {
        /// <summary>
        /// Method that defines the structure of the game 
        /// </summary>
        public static void Game()
        {
            // We define all the attributes that we will need in this game 
            List<Player> list_players = new List<Player>();
            BoardSingleton boardGame = BoardSingleton.getInstance;

            Console.WriteLine("Hello. You open the Monopoly Game.\nDo you want to play ? > (Y/N)");
            string rep = Console.ReadLine().ToUpper();
            if (rep == "Y") // if the players want to play
            {
                // Creation of the players 
                list_players = PlayersCreation();

                //Creation of the list of Observer for the proprieties (the observers are the players)
                CreateObserversList(boardGame.BoardGame, list_players);

                //Current situation of the players 
                Console.Clear();
                Console.WriteLine("Here are your current situation.");
                PlayerSituation(list_players);

                Console.WriteLine("\nPress enter to continue...");
                Console.ReadKey();

                //Beginning of the game
                Console.Clear();
                Console.WriteLine("LEEEET'S GOOOOOO ! The game is starting righ now !");


                int turnNumber = 1;


                while(true) // infinite loop (rajouter condition de sortie si un joueur gagne)
                {
                    for(int i = 0; i < list_players.Count; i ++)
                    {
                        Console.Clear();
                        Console.Write($"{list_players[i].Name}'s turn: \n" +
                                      $"Money: {list_players[i].Money}$ \n" +
                                      //$"Position: {boardGame.BoardGame[list_players[i].Current_position]}");
                                      $"Position: {list_players[i].Current_position}");


                        Plays(list_players[i], boardGame.BoardGame);
                        Console.ReadKey();
                    }
                    Console.Clear();
                    Console.WriteLine("\nEnd of turn " + turnNumber);
                    Console.WriteLine("Player's situation :");
                    PlayerSituation(list_players);
                    turnNumber++;
                    Console.ReadKey();
                }





            }
            else if (rep == "N") // if the players do not want to play
            {
                Console.WriteLine("See you later ! :)");
            }
            else Console.WriteLine("I don't understand your answer :(. Please close this page and run again the game if you want to play !");
        }

        /// <summary>
        /// Method that will create the list of the players in the game
        /// </summary>
        /// <returns></returns>
        public static List<Player> PlayersCreation()
        {
            List<Player> list_players = new List<Player>();

            Console.Clear();
            Console.WriteLine("Good! You will have a very good time !");
            int nb_players = 0;
            while (nb_players <= 0 || nb_players > 4) // will ask the question until a correct value is obtained
            {
                Console.WriteLine("Enter the number of players : > (2-4)");
                int.TryParse(Console.ReadLine(), out nb_players); // verify if the value is in the correct type
                Console.WriteLine();
            }
            Console.WriteLine("Great! Now it's time to choose the name of the players.");

            for (int i = 0; i <= nb_players - 1; i++)
            {
                Console.WriteLine();
                Console.WriteLine("What is the name of the player n°" + (i+1) + " ? >");
                string name = Console.ReadLine();
                Player player = new Player(name);
                list_players.Add(player);
                Console.WriteLine("Player " + name + " added !");
            }

            return list_players;
        }
        /// <summary>
        /// Method that will create a liste of observers (who are the players) for each property
        /// </summary>
        /// <param name="boardGame">The board game to have all the properties</param>
        /// <param name="list_players">The list of players that represents the observers</param>
        public static void CreateObserversList(ICell[] boardGame, List<Player> list_players)
        {
            for (int i = 0; i < boardGame.Length; i++)
            {
                Property p = new Property();
                if (boardGame[i].GetType() == p.GetType()) //if the current cell is a property
                {
                    p = (Property)boardGame[i]; //we collect this property
                    for (int y = 0; y <= list_players.Count - 1; y++) 
                    {
                        p.AddEventObservers.Add(list_players[y]); // we had all the players (they are the observers) in the observers list of the properties
                    }
                    boardGame[i] = p; // we set this updated property in the boardgame
                }
            }
        }

        /// <summary>
        /// Method that will be use to print the current information about the player
        /// </summary>
        /// <param name="list_player"></param>
        public static void PlayerSituation(List<Player> list_player)
        {
            for (int i = 0; i <= list_player.Count - 1; i++)
            {
                Console.WriteLine();

                //we change the color of the player description :
                if (i == 0) Console.ForegroundColor = ConsoleColor.Red;
                else if (i == 1) Console.ForegroundColor = ConsoleColor.Green;
                else if (i == 2) Console.ForegroundColor = ConsoleColor.Blue;
                else Console.ForegroundColor = ConsoleColor.DarkYellow;

                //we print the description of the player, to see his current situation
                Console.WriteLine(list_player[i].ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Method that will structure a round of the player, in which he will play the game
        /// </summary>
        /// <param name="doublesAllowed"></param>
        public static void Plays(Player player, ICell[] boardGame, int doublesAllowed = 2) // A player is only allowed to get 2 doubles in a row (if he hit 3 he goes to jail)
        {
            bool jail_free = false; // we will true if the player is freeing out of jail;
            bool third_try = true; // represents the valid status of the third try of the player if he made already 2 doubles in a row

            if (doublesAllowed >= 0)
            {
                // DICE - A turn always start by a roll of dice
                int[] dice = player.RollsDice(player.Rdm);
                Console.WriteLine("\nLet's roll the dice:");
                Console.WriteLine(printDice(dice[0]));
                Console.Write(printDice(dice[1]));

                if (doublesAllowed == 0 && dice[0] == dice[1]) third_try = false;

                if (third_try) // if the player doesn't made 3 doubles in a row
                {
                    if (dice[1] == dice[0] && !player.Is_in_jail)
                    {
                        Console.WriteLine("\nYou obtained a double. You can play again. Let's try again.\nBut watch out ! 3 doubles in a row and you'll go to jail.");
                        Console.WriteLine("Number of current double in a row :" + (3 - doublesAllowed));
                    }
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadKey();



                    // MOVE AROUND THE BOARD

                    if (!player.Is_in_jail) // If the player is not currently in jail
                    {
                        Console.WriteLine("You're moving " + (dice[0] + dice[1]) + " cells");
                        player.MoveToPosition(dice);
                    }

                    else // If the player is in jail
                    {
                        if (player.CanExitJail(dice))
                        {
                            Console.WriteLine(" Somehow you're free, runaway !");
                            player.Is_in_jail = false; // the player is not in jail anymore
                            player.Visit_only = true; // we set to him the sisit only status, because he is in the jail cell but now as a visitor
                            jail_free = true; // to note that the player is just free out of jail
                            Console.WriteLine("You're moving " + (dice[0] + dice[1]) + " cells");
                            player.MoveToPosition(dice); // if the player eligible to get out of jail then he can move forward. Else, he stays in jail for another turn
                        }
                    }

                    if (!player.Is_in_jail) // if the player is not in jail, he can decide to take action on the cell where he is
                    {
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadKey();
                        ActionOnCell(player, boardGame);
                    }
                }

                if (dice[0] == dice[1] && !jail_free) Plays(player,boardGame,doublesAllowed - 1);


            }
            else
            {
                Console.WriteLine("Oh no! You obtained 3 doubled dice in a row, you are going immediatly to jail!");
                player.Is_in_jail = true;
                player.Current_position = 10;
            }

        }

        /// <summary>
        /// Method that will print the dice in order to have a visual representation of the results
        /// </summary>
        /// <param name="diceNumber"></param>
        /// <returns></returns>
        public static string printDice(int diceNumber)
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
        /// Method that will collect the type of the cell, print the description of the cell and allows actions on it
        /// </summary>
        /// <param name="player">Represents the current player of the game</param>
        /// <param name="boardGame">Represents the boardGame of the game</param>
        public static void ActionOnCell(Player player,ICell[] boardGame)
        {
            int position = player.Current_position; //we collect the current position of the player

            Console.Clear();
            Console.WriteLine("You're on the position : " + player.Current_position);
            Console.WriteLine("This is the following cell : \n\n");

            // we create some instances to evaluate all the possible types of the cell
            Property p = new Property();
            Chance c = new Chance();
            CommunityChest co = new CommunityChest();
            Jail j = new Jail();
            Special s = new Special();
            Tax t = new Tax();

            if (boardGame[position].GetType() == p.GetType()) //if the cell is a property
            {
                Property prop = (Property)(boardGame[position]);
                Console.WriteLine((prop.ToString()));


                //Now it's time to ask if the player wants to buy the property or not 
                if (prop.Is_free)
                {
                    Console.WriteLine("\n\nThis property is free\nDo you want to buy it ? > (Y/N)");
                    string rep = Console.ReadLine().ToUpper();

                    if (rep == "Y") // the player wants to buy the property
                    {
                        int price = prop.Price;
                        if (player.EnoughMoneyToBuy(price)) // we verify if the player has enough money to buy it
                        {
                            Console.WriteLine("\nGreat News! You have enough money to buy it! Let's proceed the transaction to the bank.");
                            player.Money -= price; //the money of the player must be updated
                            player.Own_properties.Add(prop); //we add this property to the list of the player's properties
                            prop.Is_free = false; // we must update the property too, it is not free anymore
                            prop.Property_owner = player; // we inform the property of it's player owner
                            prop.notifyObserver(player.Name); // the property has just been bought. The observer must be notified.
                            boardGame[position] = prop; // we actualise this property in the game board.

                            
                        }
                        else Console.WriteLine("\n\nI'm sorry. You don't have enough money to buy it. Please come later.");
                    }
                }

                else
                {
                    if (player == prop.Property_owner) Console.WriteLine("\nThis is your property. You can rest peacefully :)");
                    else
                    {
                        Console.WriteLine("\n\nOh! The property is not available. That means that somebody bought it earlier. You will have to pay this player !\n Let's see how much it will cost you");
                        Console.ReadKey();
                        PayDebt(player, prop.Property_owner, prop);
                    }
                }

            }

            else if (boardGame[position].GetType() == c.GetType()) //if the cell is a chance cell
            {
                Chance chance = (Chance)(boardGame[position]);
                chance.Draw_Chance();
                Console.WriteLine((chance.ToString()));

                if (chance.Bonus != 0) //if the chance cards offers a money bonus to the player
                {
                    Console.WriteLine("\nYou receive $" + chance.Bonus);
                    player.Money += chance.Bonus;
                }

                else if (chance.Debt != 0) //if the chance cards force the player to pay something
                {
                    if (player.EnoughMoneyToBuy(chance.Debt)) //if the player has enough money
                    {
                        Console.WriteLine("\nYou pay $" + chance.Debt);
                        player.Money -= chance.Debt;
                    }

                    else player.Lose = true; // THE PLAYER HAS NOT ENOUGH MONEY ! HE LOSE THE GAME 
                }

                else if (chance.Go_in_jail) //the player must go to jail !
                {
                    Console.WriteLine("\nYou go to jail.");
                    player.Current_position = 10; //we update the position of the player
                    player.Is_in_jail = true; //we update the jail status of the player
                }

                else if (chance.Free_jail)
                {
                    Console.WriteLine("You win a joker card that will free you out of jail. Keep it preciously.");
                    player.Joker_exit_jail = true; //we update the attribute, the player own this joker card
                }

            }

            else if (boardGame[position].GetType() == co.GetType()) //if the cell is a community chest  cell
            {
                CommunityChest comu = (CommunityChest)(boardGame[position]);
                comu.Draw_CommunityChest();
                Console.WriteLine((comu.ToString()));


                if (comu.Bonus != 0) //if the community chest cards offers a money bonus to the player
                {
                    Console.WriteLine("\nYou receive $" + comu.Bonus);
                    player.Money += comu.Bonus;
                }

                else if (comu.Debt != 0) //if the community chest cards force the player to pay something
                {
                    if (player.EnoughMoneyToBuy(comu.Debt)) //if the player has enough money
                    {
                        Console.WriteLine("\nYou pay $" + comu.Debt);
                        player.Money -= comu.Debt;
                    }

                    else player.Lose = true; // THE PLAYER HAS NOT ENOUGH MONEY ! HE LOSE THE GAME 
                }

                else if (comu.Go_in_jail) //the player must go to jail !
                {
                    Console.WriteLine("\nYou go to jail.");
                    player.Current_position = 10; //we update the position of the player
                    player.Is_in_jail = true; //we update the jail status of the player
                }

                else if (comu.Free_jail)
                {
                    Console.WriteLine("You win a joker card that will free you out of jail. Keep it preciously.");
                    player.Joker_exit_jail = true; //we update the attribute, the player own this joker card
                }
            }

            else if (boardGame[position].GetType() == j.GetType()) //if the cell is the jail cell
            {
                Jail jail = (Jail)(boardGame[position]);
                Console.WriteLine((jail.ToString()));
            }

            else if (boardGame[position].GetType() == s.GetType()) //if the cell is a special cell
            {
                Special special = (Special)(boardGame[position]);
                Console.WriteLine((special.ToString()));


                if (special.Go_cell) //if the player is on the go cell, the money bonus id doubled
                {
                    player.Money += 400;
                    Console.WriteLine("You're lucky! You are on the go cell, so you receive a special bonus of $400");
                }
            }

            else if (boardGame[position].GetType() == t.GetType()) //if the cell is a tax cell
            {
                Tax tax = (Tax)(boardGame[position]);
                Console.WriteLine((tax.ToString()));
                player.Money -= tax.TaxAmount; //the player has to pay the tax amount write on the cell. So he loses money
                Console.WriteLine("\n\nYou pay $" + tax.TaxAmount);
            }
        }

        /// <summary>
        /// Method that will make the player pay if they land on property that don't belong to them
        /// </summary>
        /// <param name="player">The current player</param>
        /// <param name="boardGame">The current property where the player is</param>
        public static void PayDebt(Player current_player, Player player_owner, Property property)
        {
            int price = property.Debt; // the price that the player will have to pay

            //first we must verified if the player has enough money to pay
            if(current_player.EnoughMoneyToBuy(price))
            {
                if(!property.Hotel && !property.House) //if the property does not have any house or hotel
                {
                    if(player_owner.FamilyComplete(property)) //if the player owner possess all the properties of the same family the debt double!!
                    {
                        if (current_player.EnoughMoneyToBuy(price)) //this condition must be reverified
                        {
                            current_player.Money -= price * 2; //the current player lose money
                            player_owner.Money += price * 2;
                            Console.WriteLine(player_owner.Name + " has all the properties of this family ! (" + property.Label + ") The debt is doubled.\n" + current_player.Name + " you pay $" + price * 2 + "\n" + player_owner.Name + " you receive this amount of money");
                        }
                        else
                        {
                            Console.WriteLine("Oh no! The player " + current_player.Name + " doesn't have enough money to pay.\n" + current_player.Name + ", you are ruined! You lose the game!");
                            current_player.Lose = true; //we set this attribute to true to signify that the player losed
                        }

                    }

                    else // the player owner does not possess all the properties of the same family
                    {
                        current_player.Money -= price;
                        player_owner.Money += price;
                        Console.WriteLine(current_player.Name + " you pay $" + price + "\n" + player_owner.Name + " you recieve this amount of money");
                    }
                }
            }
            else
            {
                Console.WriteLine("Oh no! The player " + current_player.Name + " doesn't have enough money to pay.\n" + current_player.Name + ", you are ruined! You lose the game!");
                current_player.Lose = true; //we set this attribute to true to signify that the player losed
            }
        }

        static void Main(string[] args)
        {
            Game();
            Console.ReadKey();
        }
    }
}
