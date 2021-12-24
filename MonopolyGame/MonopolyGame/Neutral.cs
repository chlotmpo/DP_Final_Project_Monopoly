using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Neutral : ICell
    {
        // ATTRIBUTES 
        // TODO : define all the attributes that we need to correclty instantiate a neutral cell

        private string name; // represents the name of this neutral cell
        private int position;
        private bool go_cell; // represents if the cell is the go cell or not 

        // CONSTRUCTORS 
        public Neutral() { }
        public Neutral(string name, int position, bool go_cell)
        {
            this.name = name;
            this.position = position;
            this.go_cell = go_cell;
        }

        // PROPERTIES
        public string Name
        {
            get { return name; }
        }
        public int Position
        {
            get { return position; }
        }
        public bool Go_cell
        {
            get { return go_cell; }
        }

        // METHODS 
        /// <summary>
        /// Method that give a description of the current neutral cell
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Cell position : " + position + "\nHere is the " + name + " cell.\nThis is a neutral cell, that means that you have nothing to do here, you can rest :).";
        }
    }
}
