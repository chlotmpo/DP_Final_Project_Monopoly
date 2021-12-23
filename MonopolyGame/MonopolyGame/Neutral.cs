using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Neutral : ICell
    {
        // TODO : define all the attributes that we need to correclty instantiate a neutral cell
        private int position;

        public Neutral() { }
        public Neutral(int position)
        {
            this.position = position;
        }

        public int Position
        {
            get { return position; }
            set { this.position = value; }
        }
    }
}
