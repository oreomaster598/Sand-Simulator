using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata;

namespace Tests
{
    public class Water : Cell
    {
        Random rnd = new Random();
        public Water() : base(BaseCellType.Liquid, -1, Color.DarkBlue)
        {

        }

        public override void Update(CellWorld w, int x, int y)
        {

            bool l = w.isEmpty(x - 1, y);
            bool r = w.isEmpty(x + 1, y);
            //Check Down
            if (w.isEmpty(x, y + 1))
                w.MoveCell(x, y, x, y + 1);
            else if (w.isEmpty(x - 1, y + 1))
                w.MoveCell(x, y, x - 1, y + 1);
            //Check Right Down
            else if (w.isEmpty(x + 1, y + 1))
                w.MoveCell(x, y, x + 1, y + 1);
            //Check Left
            else if (l && !r)
                w.MoveCell(x, y, x - 1, y);
            //Check Right
            else if (r && !l)
                w.MoveCell(x, y, x + 1, y);
            else if (r && l)
            {
                bool b = rnd.Next(0, 1) == 1;
                if (b)
                    w.MoveCell(x, y, x - 1, y);
                else
                    w.MoveCell(x, y, x + 1, y);

            }
            //Check Left Down

        }
    }
}
