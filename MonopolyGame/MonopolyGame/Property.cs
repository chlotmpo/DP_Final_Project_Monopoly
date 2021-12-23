using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Property : ICell

    {
        // TODO : define all the attributes that we need to correclty instantiate a property cell
        private List<AbstractObserver> addEventObserver;
        private int position;

        public Property() { }
        public Property(int position) 
        { 
            this.position = position; 
        }

        public int Position
        {
            get { return position; }
        }
        public void notifyObserver()
        {
            // TODO implement here
        }
    }
}
