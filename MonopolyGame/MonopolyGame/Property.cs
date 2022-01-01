using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class Property : ICell
    {
        #region Attributes
        // TODO : define all the attributes that we need to correclty instantiate a property cell
        private string name; //represents the name of the property
        private int price; //represents the price of the property to buy it the first time 
        private int debt; //represents the price that a player will must pay if he land on this property and if it is not free
        private bool is_free;
        private Player property_owner;
        private string label; //represent the category of the property, like the color in the real game, to evaluate if the player can put hous and hotel on it.
        private int number_family; //represent how many other property belongs to the same group (the ones who have the same color)
        private bool house;
        private bool hotel;
        private List<AbstractObserver> addEventObserver;
        private int position;
        #endregion

        #region Constructors
        public Property() { }
        public Property(string name, int price, int debt, string label, int number_family, int position)
        {
            this.name = name;
            this.price = price;
            this.debt = debt;
            is_free = true;
            property_owner = null;
            this.label = label;
            this.number_family = number_family;
            house = false;
            hotel = false;
            addEventObserver = new List<AbstractObserver>();
            this.position = position;
        }
        #endregion

        #region Properties of properties :)
        public string Name
        {
            get { return name; }
        }
        public int Price
        {
            get { return price; }
        }
        public int Debt
        {
            get { return debt; }
        }
        public bool Is_free
        {
            get { return is_free; }
            set { is_free = value; }
        }
        public Player Property_owner
        {
            get {return property_owner;}
            set { property_owner = value; }
        }
        public string Label
        {
            get { return label; }
        }
        public int Number_family
        {
            get { return number_family; }
        }
        public bool House
        {
            get { return house; }
            set { house = value; }
        }
        public bool Hotel
        {
            get { return hotel; }
            set { hotel = value; }
        }
        public List<AbstractObserver> AddEventObservers
        {
            get { return addEventObserver; }
            set { addEventObserver = value; }
        }
        public int Position
        {
            get { return position; }
            set { position = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that will notify all observers
        /// </summary>
        /// <param name="player_name"></param>
        public void notifyObserver(string player_name)
        {
            if(!is_free) //verify this condition, the property must be bought
            {
                foreach (AbstractObserver o in addEventObserver)
                {
                    Player p = (Player)o;
                    if (p.Name != player_name) o.Update( name, position, player_name);
                }
            }
        }


        public string ToString()
        {
            string content = "Cell position : " + position + "\nYou are on a property.\nProperty name : " + name + "\nColor : " + label + "\nPosition : " + position + "\nPrice : $" + price;
            if (is_free) content += "\nStatus of the property : AVAILABLE";
            else content += "\nStatus of the property : NOT AVAILABLE";
            return content;
        }

        public string DescriptionProperty()
        {
            return $"\n - Property Name : {name}  ({label})" ; 
            //TODO : add debt price when we will defined it + add house and hotel if there are one
        }

        //public override string GetCellName(int position)  { return this.name; }
        #endregion
    }
}
