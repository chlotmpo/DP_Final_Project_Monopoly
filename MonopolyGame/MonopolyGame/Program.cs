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

            Console.WriteLine("Hello. You open the Monopoly Game.\nDo you want to play ? > (Yes or No)");
            string rep = Console.ReadLine().ToUpper();
            if (rep == "YES") // if the players want to play
            {
                // Creation of the players 
                list_players = PlayersCreation();

                //Current situation of the players 
                Console.Clear();
                Console.WriteLine("Here are your current situation.");
                PlayerSituation(list_players);

                Console.WriteLine("\nPress any button to continue...");
                string button = Console.ReadLine();

                //Beginning of the game
                Console.Clear();
                Console.WriteLine("LEEEET'S GOOOOOO ! The game is starting righ now !");
            }
            else if (rep == "NO") // if the players do not want to play
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
        /// Method that will be use to print the current information about the player
        /// </summary>
        /// <param name="list_player"></param>
        public static void PlayerSituation(List<Player> list_player)
        {
            for (int i = 0; i <= list_player.Count - 1; i++)
            {
                Console.WriteLine();
                Console.WriteLine(list_player[i].ToString());
            }
        }


        static void Main(string[] args)
        {
            Game();

            Console.ReadKey();
        }
    }
}
