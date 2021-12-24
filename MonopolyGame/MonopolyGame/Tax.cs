using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Tax : ICell
    {
        // ATTRIBUTES 
        // TODO : define all the attributes that we need to correclty instantiate a tax cell
        private double taxAmount;
        private string name;
        private int position;

        // CONSTRUCTORS
        public Tax() { }
        public Tax(string name, double taxAmount, int position)
        {
            this.name = name;
            this.taxAmount = taxAmount;
            this.position = position;
        }

        // PROPERTIES
        public double TaxAmount
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

        // METHODS
        /// <summary>
        /// Method that give a description and informations of the current tax cell
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Cell position : " + position + "\nYou are on a tex cell. That means that you will have to pay an amount of money to the bank.\nPay now $" + taxAmount + ".";
        }
    }
}
