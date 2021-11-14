using PixelEngine;
using PixelEngine.Object;
using PixelEngine.Scene;
using PixelEngine.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PixelEngine.UI;
using Random = PixelEngine.Random;
using Button = PixelEngine.UI.Button;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CellularAutomata;

namespace Tests
{
    //Main script

    public enum CellType
    {
        Sand,
        Stone,
        Acid,
        Water,
        Gas,
        Fire,
        Oil,
        Wood,
        Empty
    }
    class Game : Main
    {
        #region Setup
        public Game() : base(new Vector2(580, 535), "Sand Simulator", "Assets/Icon.ico") { }
        CellWorld world;
        CellType heldtype = CellType.Sand;
        bool run = false;
        //Runs on load
        public override void Load()
        {
            Background = Color.Gray;

          
            world = new CellWorld(100, 100);
            Global.UIComponents.Add(new Button(new Vector2(500, 0), GetStone, "Stone"));
            Global.UIComponents.Add(new Button(new Vector2(500, 22), GetSand, "Sand"));
            Global.UIComponents.Add(new Button(new Vector2(500, 44), GetAcid, "Acid"));
            Global.UIComponents.Add(new Button(new Vector2(500, 66), GetWater, "Water"));
            Global.UIComponents.Add(new Button(new Vector2(500, 88), GetGas, "Gas"));
            Global.UIComponents.Add(new Button(new Vector2(500, 110), GetFire, "Fire"));
            Global.UIComponents.Add(new Button(new Vector2(500, 132), GetOil, "Oil"));
            Global.UIComponents.Add(new Button(new Vector2(500, 154), GetWood, "Wood"));
        }
        #endregion
        //Main Game loop

        public void GetStone() => heldtype = CellType.Stone;
        public void GetSand() => heldtype = CellType.Sand;
        public void GetAcid() => heldtype = CellType.Acid;
        public void GetWater() => heldtype = CellType.Water;
        public void GetGas() => heldtype = CellType.Gas;
        public void GetFire() => heldtype = CellType.Fire;
        public void GetOil() => heldtype = CellType.Oil;
        public void GetWood() => heldtype = CellType.Wood;

        public override void Update()
        {
            if(Keyboard.MouseDown)
            {
                Vector2 pos = Keyboard.GetCusorPos();
                if (pos < new Vector2(500, 500))
                    world.world[(int)pos.x / 5, (int)pos.y / 5] = GetCell(heldtype);
            }
            if(Keyboard.IsKeyDown(Key.R))
                for (int x = world.width - 1; x >= 0; x--)
                    for (int y = world.height - 1; y >= 0; y--)
                        world.world[x, y] = new Cell(BaseCellType.Empty, -1);
            world.Step();
        }

        public Cell GetCell(CellType type)
        {
            switch (type)
            {
                case CellType.Sand:
                    return new Sand();
                case CellType.Water:
                    return new Water();
                case CellType.Stone:
                    return new Stone();
                case CellType.Acid:
                    return new Acid();
                case CellType.Gas:
                    return new Gas();
                case CellType.Fire:
                    return new Fire();
                case CellType.Oil:
                    return new Oil();
                case CellType.Wood:
                    return new Wood();
            }
            return null;
        }

        public override void Renderer(object sender, PaintEventArgs e)
        {

            //Setup
            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.Clear(Background);
            renderer.graphics = g;

            //Rendering
            if(world.sprite != null)
            renderer.DrawBitmap(Vector2.zero, new Vector2(500,500), new Bitmap(world.sprite));

            foreach (UIComponent component in Global.UIComponents.FindAll(isActive))
                renderer.DrawUIComponent(component);
        }
    }
}
