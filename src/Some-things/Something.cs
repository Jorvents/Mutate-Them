using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace MutateThem
{
    public class Something
    {
        public Vector2[] loc { get; set; }
        public int radius { get; set; }
        public Color colour { get; set; }

        public void Draw()
        {
            //loc.X += MoveX * Raylib.GetFrameTime();
            for (int i = 0; i < loc.Length; i++)
            {
                Raylib.DrawCircle((int)loc[i].X, (int)loc[i].Y, radius, colour);
            }
        }
        /*
        public void Update()
        {
            x += MoveX * Raylib.GetFrameTime();
            y += MoveY * Raylib.GetFrameTime();
        }
        */
    }
}
