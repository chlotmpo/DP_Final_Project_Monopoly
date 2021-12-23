using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public enum CellType { PROPERTY, CHANCE, COMMUNITYCHEST, JAIL, NEUTRAL, TAX}
    public abstract class CellCreator
    {
        /// <summary>
        /// Abstract method in order to create Cell depending on the given type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract ICell CreateCell(CellType type);

    }
}
