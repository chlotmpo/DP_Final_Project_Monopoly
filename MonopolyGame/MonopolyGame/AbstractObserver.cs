using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public abstract class AbstractObserver
    {
        /// <summary>
        /// Abstract method that will be used to update the observers of any change in the method implemented
        /// </summary>
        public abstract void Update(string property_name, int property_position, string name_owner);
    }
}
