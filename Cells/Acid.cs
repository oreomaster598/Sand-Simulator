using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata;

namespace Tests
{
    public class Acid : Cell
    {
        Random rnd = new Random();
        int tick = 0;

        public Acid() : base(BaseCellType.Liquid, -1, Color.Green)
        {
            flammable = true;
        }

        public override void Update(CellWorld w, int x, int y)
        {
            tick++;
            bool up = w.isEmpty(x, y - 1);
            bool down = w.isEmpty(x, y + 1);
            bool left = w.isEmpty(x - 1, y);
            bool right = w.isEmpty(x + 1, y);


            bool l = w.isEmpty(x - 1, y);
            bool r = w.isEmpty(x + 1, y);
            //Check Down
            if (w.isEmpty(x, y + 1))
                w.MoveCell(x, y, x, y + 1);
            //Check Left Down
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

            if(tick == 20)
            {
                

                if (!down)
                    w.ReplaceCell(x, y + 1, new Gas(), BaseCellType.Liquid, BaseCellType.Fire);
                if (!up)
                    w.ReplaceCell(x, y - 1, new Gas(), BaseCellType.Liquid, BaseCellType.Fire);
                if (!left)
                    w.ReplaceCell((x - 1).Clamp(0, w.width - 1), y, new Gas(), BaseCellType.Liquid, BaseCellType.Fire);
                if (!right)
                    w.ReplaceCell((x + 1).Clamp(0, w.width - 1), y, new Gas(), BaseCellType.Liquid, BaseCellType.Fire);
                tick = 0;
            }
            
        }
    }
}
