using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellularAutomata;

namespace Tests
{
    public class Fire : Cell
    {
        public Fire() : base(BaseCellType.Fire, 20, Color.Orange)
        {

        }

        public override void Update(CellWorld w, int x, int y)
        {
            color = Darken(color, (float)lifeleft/20);
            if(lifeleft <= 15)
            {
                bool up = w.isEmpty(x, (y - 1).Clamp(0, w.height-1));
                bool down = w.isEmpty(x, (y + 1).Clamp(0, w.height - 1));
                bool left = w.isEmpty((x - 1).Clamp(0, w.width - 1), y);
                bool right = w.isEmpty((x + 1).Clamp(0, w.width - 1), y);

                if(!up)
                    if (w.world[x, (y - 1).Clamp(0, w.height - 1)].flammable)
                        w.ReplaceCell(x, (y - 1).Clamp(0, w.height - 1), new Fire());
                if (!down)
                    if (w.world[x, (y + 1).Clamp(0, w.height - 1)].flammable)
                        w.ReplaceCell(x, (y + 1).Clamp(0, w.height - 1), new Fire());
                if (!left)
                    if (w.world[(x - 1).Clamp(0, w.width - 1), y].flammable)
                        w.ReplaceCell((x - 1).Clamp(0, w.width - 1), y, new Fire());
                if (!right)
                    if (w.world[(x + 1).Clamp(0, w.width - 1), y].flammable)
                        w.ReplaceCell((x + 1).Clamp(0, w.width - 1), y, new Fire());
            }
            
        }
        public Color Darken(Color color, float percent)
        {
            float R = Color.Orange.R * percent;
            float G = Color.Orange.G * percent;
            float B = Color.Orange.B * percent;
            return Color.FromArgb(255, (int)R, (int)G, (int)B);
        }
    }
}
