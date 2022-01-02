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
        private List<string> list_player_in_jail; // represents the list of names of the player that are in jail 
        #endregion

        #region Constructors
        public Jail() { }
        public Jail(int position)
        {
            this.position = position;
            list_player_in_jail = new List<string>();
        }
        #endregion

        #region Properties 
        public int Position
        {
            get { return position; }
        }
        public List<string> List_player_in_jail
        {
            get { return list_player_in_jail; }
            set { list_player_in_jail = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that give current informations and description of the jail 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string content = "Cell position : " + position + "\nThis is the jail\n";
            if (list_player_in_jail.Count == 0) content += "\nRigth now, no one is in jail.";
            else if(list_player_in_jail.Count > 0) //some players are currently in jail 
            {
                foreach (string player_name in list_player_in_jail)
                {
                    content += player_name + " is actually in jail.\n";
                }


            }
            return content;
        }

        //public override string GetCellName(int position) { return "Jail"; }
        #endregion
    }
}
