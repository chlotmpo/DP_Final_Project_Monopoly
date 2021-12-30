using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Special : ICell
    {
        #region Attributes
        // TODO : define all the attributes that we need to correclty instantiate a special cell
        private string name; // represents the name of this special cell
        private int position;
        private bool go_cell; // represents if the cell is the go cell or not 
        private bool go_to_jail; // represents if the cell is the cell go to jail or not
        private bool free_parking; // represents if the cell is the cell free parking or not
        #endregion

        #region Constructors
        public Special() { }
        public Special(string name, int position, bool go_cell, bool go_to_jail, bool free_parking)
        {
            this.name = name;
            this.position = position;
            this.go_cell = go_cell;
            this.go_to_jail = go_to_jail;
            this.free_parking = free_parking;
        }
        #endregion

        #region Properties
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
        public bool Go_to_jail
        {
            get { return go_to_jail; }
        }
        public bool Free_parking
        {
            get { return free_parking; }
        }
        #endregion

        #region Methods 
        /// <summary>
        /// Method that give a description of the current neutral cell
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string content = "Cell position : " + position + "\nHere is the " + name + " cell.\nThis is a special cell. Let's see what will do this one :)";
            if (go_cell) return content += "\n\nEach time you pass this cell you will receive $200.";
            else if (go_to_jail) return content += "\nOh no! This is the cell 'Go to jail'. I'm sorry but you have to go directly in prison ! Be patient it will be okay :).";
            else if (free_parking) return content += "\nThis is the free parking cell. You have nothing to do here, you can rest peacfully :).";
            else return content;
        }
        #endregion
    }
}
