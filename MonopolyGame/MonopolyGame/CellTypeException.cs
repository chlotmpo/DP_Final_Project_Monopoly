using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class CellTypeException : Exception
    {
        private string message;
        public CellTypeException(string msg)
        {
            message = msg;
        }
    }
}
