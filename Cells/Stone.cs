using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata;

namespace Tests
{
    public class Stone : Cell
    {
        public Stone() : base(BaseCellType.Solid, -1, Color.DarkGray)
        {

        }
    }
}
