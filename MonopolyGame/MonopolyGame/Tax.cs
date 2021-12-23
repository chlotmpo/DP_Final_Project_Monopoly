using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Tax : ICell
    {
        // TODO : define all the attributes that we need to correclty instantiate a tax cell
        public double taxAmount;
        private int position;

        public Tax() { }
        public Tax(int position)
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
