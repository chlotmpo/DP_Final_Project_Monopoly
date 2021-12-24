using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            BoardSingleton board = BoardSingleton.getInstance;
            BoardSingleton board2 = BoardSingleton.getInstance;

            //Console.WriteLine(board.ToString());
            //Console.WriteLine(board2.ToString());

            Property prop1 = new Property("Rue de la paix", 600, "Blue", 2, 39);
            // Console.WriteLine(prop1.ToString());

            Chance chance1 = new Chance(3);
            Console.WriteLine(chance1.ToString());
            Console.WriteLine();

            CommunityChest com = new CommunityChest(7);
            //Console.WriteLine(com.ToString());

            Console.ReadKey();
        }
    }
}
