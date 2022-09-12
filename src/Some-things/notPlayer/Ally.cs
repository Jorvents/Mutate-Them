using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.Some_things.notPlayer
{
    public class Ally : Mutateble
    {
        public Enemy[] Mysabotagesebles { get; set; }
        Enemy Theclosest { get; set; }
        public Ally()
        {
            loc = new Vector2(100, 100);
            what = Mutatebles.Ally;
            speed = 5000;
            radius = 25;
            colour = Raylib_cs.Color.YELLOW;
        }
        public void Work()
        {

            Follow(WhoToFollow(Mysabotagesebles));
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

        public Vector2 WhoToFollow(Enemy[] choices)
        {
            Vector2 closest = new Vector2(9999,9999);
            foreach (Enemy choice in choices)
            {
                Vector2 curr = choice.loc;
                if (distanceTo(curr) < distanceTo(closest))
                {
                    closest = curr;
                    Theclosest = choice;
                }
            }
            /*
            for (int i = 0; i < choices.Length; i++)
            {
                Vector2 curr = choices[i].loc;
                if (distanceTo(curr) < distanceTo(closest))
                {
                    closest = curr;
                    if (choices[i] != null)
                    {
                        Theclosest = choices[i];
                    }
                }
            }
            */
            if (distanceTo(closest) > 7000)
            {
                return loc;
            } else
            {
                return closest;
            }
            //return new Vector2(0, 0);
        }
        public void Revive()
        {

        }
    }
}
