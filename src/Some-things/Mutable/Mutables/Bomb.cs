using MutateThem.Scenes;
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
         * Explodes if touches a enemy
         * Only kills certain amount of enemies in circlew
        */
        readonly byte killstreak = 10;

        readonly short damege = (short)(150 * Window.multyplier.Y);

        public Bomb(Vector2 spawn) : base(spawn, 35, new Color(104, 127, 133, 255), 82, 15) => what = Mutables.Bomb;
        
        public override void Work()
        {
            if (isDying)
            {
                Dying();
                return;
            }
            if (inControl) return;
            var Theclosest = WhoTheClosest(Game.enemies);
            if (!isActive) return;
            if (Theclosest == null) return;
            Follow(Theclosest.loc);

            if (Raylib.CheckCollisionCircles(Theclosest.loc, Theclosest.radius, loc, radius))
            {
                Explode();
            }
        }
        public override void Draw()
        {
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
        }
        public void Explode()
        {
            List<Enemy> range = new();
            Game.enemies.ForEach(e =>
            {
                if (Raylib.CheckCollisionCircles(e.loc, e.radius, loc, damege))
                {
                    range.Add(e);
                }
            });
            if (range.Count == 1)
            {
                range[0].Die();
            }
            else if (range.Count < killstreak)
            {
                range.ForEach(e => e.Die());
            } else
            {
                for (int i = 0; i < killstreak; i++)
                {
                    Enemy theClosest = (Enemy)WhoTheClosest(range);
                    theClosest.Die();
                    range.Remove(theClosest);
                }
            }
            
            Die();
        }
    }
}
