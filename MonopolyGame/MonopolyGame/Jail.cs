using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Jail : ICell
    {
        #region Attributes
        // TODO : define all the attributes that we need to correclty instantiate a jail cell
        private int position;
        private bool is_occupied; // give information if there is currently somoene in jail or not
        #endregion

        #region Constructors
        public Jail() { }
        public Jail(int position)
        {
            this.position = position;
            is_occupied = false;
        }
        #endregion

        #region Properties 
        public bool Is_occupied
        {
            get { return is_occupied; }
            set { is_occupied = value; }
        }
        public int Position
        {
            get { return position; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that give current informations and description of the jail 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string content = "Cell position : " + position + "\nThis is the jail";
            if (is_occupied) content += "\nRigth now, one or more player(s) is/are in jail.";
            else content += "\nRight now, no one is in jail.";
            return content;
        }

        //public override string GetCellName(int position) { return "Jail"; }
        #endregion
    }
}
