using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.Some_things.notPlayer
{
    public class Bomb : Mutable
    {
        public Bomb(Vector2 spawn) : base(spawn, 35, Color.GRAY, 68, 15) => what = Mutables.Bomb;

        public override void Work()
        {
            Follow(new Vector2(100));
        }
        public override void Draw()
        {
            //if (!isActive) return;
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
        }
    }
}
