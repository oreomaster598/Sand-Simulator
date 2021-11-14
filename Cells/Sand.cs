using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata;

namespace Tests
{
    public class Sand : Cell
    {
        public Sand() : base(BaseCellType.Solid, -1, Color.Yellow)
        {

        }

        public override void Update(CellWorld w, int x, int y)
        {
            if (w.isEmpty(x, y + 1))
                w.MoveCell(x, y, x, y + 1);
            //Check Left Down
            else if (w.isEmpty(x - 1, y + 1))
                w.MoveCell(x, y, x - 1, y + 1);
            //Check Right Down
            else if (w.isEmpty(x + 1, y + 1))
                w.MoveCell(x, y, x + 1, y + 1);
        }
    }
}
