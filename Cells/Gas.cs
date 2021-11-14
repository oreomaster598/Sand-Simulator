using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata;

namespace Tests
{
    public class Gas : Cell
    {
        public Gas() : base(BaseCellType.Gas, 500, Color.DarkSlateGray)
        {
            flammable = true;
        }

        public override void Update(CellWorld w, int x, int y)
        {
            color = Color.FromArgb(lifeleft/2, Color.DarkSlateGray);

            if (w.isEmpty(x, y - 1))
                w.MoveCell(x, y, x, y - 1);
            //Check Left Down
            else if (w.isEmpty(x - 1, y - 1))
                w.MoveCell(x, y, x - 1, y - 1);
            //Check Right Down
            else if (w.isEmpty(x + 1, y - 1))
                w.MoveCell(x, y, x + 1, y - 1);
        }
    }
}
