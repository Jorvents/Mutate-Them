using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.Some_things.notPlayer
{
    public class Ally : Mutateble // : Imuteable?
    {
        Enemy Theclosest { get; set; }
        public Ally(Vector2 spawn)
        {
            loc = spawn;
            what = Mutatebles.Ally;
            speed = 85;
            radius = 25;
            colour = Raylib_cs.Color.YELLOW;
        }
        public void Work()
        {
            Follow(WhoToFollow(Game.enemies));
            if (Theclosest == null) return;
            if (Raylib.CheckCollisionCircles(Theclosest.loc, Theclosest.radius, loc, radius))
            {
                Theclosest.Dead();
                //Game.enemies;
            }
        }
        public void Draw()
        {
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
        }

        public Vector2 WhoToFollow(List<Enemy> choices)
        {
            Vector2 closest = new Vector2(9999,9999);
            if (choices.Count != 0)
            {
                Theclosest = choices.Aggregate((e1, e2) => distanceTo(e1.loc) < distanceTo(e2.loc) ? e1 : e2);
            }
            if (Theclosest != null)
            {
                closest = Theclosest.loc;
            }
            /*
            foreach (Enemy choice in choices)
            {
                Vector2 curr = choice.loc;
                if (distanceTo(curr) < distanceTo(closest))
                {
                    closest = curr;
                    Theclosest = choice;
                }
            }
            */
            if (distanceTo(closest) > 7000)
            {
                IsActive = false;
                return loc;
            } else
            {
                return closest;
            }

        }
        public void Revive()
        {

        }
    }
}
