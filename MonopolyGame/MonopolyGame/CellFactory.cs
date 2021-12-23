using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    public class CellFactory : CellCreator
    {

        /// <summary>
        /// Constructor in order to create a cell depending on the given type
        /// </summary>
        /// <param name="type">Parameters used to set the type of the cell</param>
        /// <returns></returns>
        public override ICell CreateCell(CellType type)
        {
            switch(type)
            {
                case CellType.PROPERTY:
                    return new Property();
                    break;

                case CellType.CHANCE:
                    return new Chance();
                    break;

                case CellType.COMMUNITYCHEST:
                    return new CommunityChest();
                    break;

                case CellType.JAIL:
                    return new Jail();
                    break;

                case CellType.NEUTRAL:
                    return new Neutral();
                    break;

                case CellType.TAX:
                    return new Tax();
                    break;

                default:
                    throw new CellTypeException("Not possible to create a cell with this type");
            }
        }

    }
}
