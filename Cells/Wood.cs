using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata;

namespace Tests
{
    public class Wood : Cell
    {
        public Wood() : base(BaseCellType.Solid, -1, Color.FromArgb(255, 102, 76, 48))
        {
            flammable = true;
        }
    }
}
