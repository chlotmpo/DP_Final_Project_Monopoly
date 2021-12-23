using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Jail : ICell
    {
        // TODO : define all the attributes that we need to correclty instantiate a jail cell
        private int position;

        public Jail() { }
        public Jail(int position)
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
