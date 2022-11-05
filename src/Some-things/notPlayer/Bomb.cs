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
        /*
         * Explodes if there is enough enemies in its radius
         * Explodes if touches a enemy no matter what
         * 
        */
        int damege = 163;
        public Bomb(Vector2 spawn) : base(spawn, 35, Color.GRAY, 68, 2) => what = Mutables.Bomb;
        
        public override void Work()
        {
            if (inControl) return;
            var Theclosest = WhoToFollow(Game.enemies);
            if (!isActive) return;
            if (Theclosest == null) return;
            Follow(Theclosest.loc);

            /*
            int inradius = 0;
            Game.enemies.ForEach(e =>
            {
                if (Raylib.CheckCollisionCircles(e.loc, e.radius, loc, damege))
                {
                    inradius++;
                }
                if (inradius > 10)
                {
                    Explode();
                }
            });
            */
            if (Raylib.CheckCollisionCircles(Theclosest.loc, Theclosest.radius, loc, radius))
            {
                Explode();
            }
            /*
            if (Raylib.CheckCollisionPointCircle(exploding, loc, radius))
            {
                Explode();
            }
            */
            //Game.enemies.fo
        }
        public override void Draw()
        {
            //if (!isActive) return;
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
        }
        public void Explode()
        {
            Game.enemies.ForEach(e =>
            {
                if (Raylib.CheckCollisionCircles(e.loc, e.radius, loc, damege))
                {
                    e.Die();
                }
            });
            Die();
        }
    }
}
