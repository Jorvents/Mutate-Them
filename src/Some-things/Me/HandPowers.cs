using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.Some_things.Me
{
    public class HandPowers : Something
    {
        public Vector2 stickTo { get; set; }
        public int disctance { get; set; }
        public Vector2 rotateIn { get; set; }
        public Enemy[] grabbing { get; set; }
        public HandPowers()
        {
            radius = 13;
            colour = Raylib_cs.Color.WHITE;
            disctance = 110;
        }
        public void Work()
        {
            loc = rotateIn + stickTo;
            if (IsActive)
            {
                foreach (Enemy grabers in grabbing)
                {
                    if (Raylib.CheckCollisionCircles(grabers.loc, 1, loc, radius))
                    {
                        //IsActive = false;
                        grabers.loc = loc;
                    }
                }
            }
        }
        public void Draw()
        {
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
        }
    }
}
