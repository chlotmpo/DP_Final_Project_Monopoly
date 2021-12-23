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

            Console.WriteLine(board.ToString());
            Console.WriteLine(board2.ToString());

            Console.ReadKey();
        }
    }
}
