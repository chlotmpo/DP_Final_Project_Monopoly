using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Tax : ICell
    {
        #region Attributes 
        // TODO : define all the attributes that we need to correclty instantiate a tax cell
        private int taxAmount;
        private string name;
        private int position;
        #endregion

        #region Constructors
        public Tax() { }
        public Tax(string name, int taxAmount, int position)
        {
            this.name = name;
            this.taxAmount = taxAmount;
            this.position = position;
        }
        #endregion

        #region Properties
        public int TaxAmount
        {
            get { return taxAmount; }
        }
        public string Name
        {
            get { return name; }
        }
        public int Position
        {
            get { return position; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that give a description and informations of the current tax cell
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Cell position : " + position + "\nYou are on a tax cell. That means that you will have to pay an amount of money to the bank.\nPay now $" + taxAmount + ".";
        }
        #endregion
    }
}
