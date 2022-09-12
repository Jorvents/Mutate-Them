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
        public Ally()
        {
            loc = new Vector2(100, 100);
            what = Mutatebles.Ally;
            speed = 90;
            radius = 25;
            colour = Raylib_cs.Color.YELLOW;
        }
        public void Work()
        {
            Follow(WhoToFollow(Mysabotagesebles));
            /*
            if (Raylib.CheckCollisionCircles(Mysabotagesebles[1].loc, Mysabotagesebles[1].radius, loc, radius))
            {
                Mysabotagesebles[1].Dead();
                //Game.enemies;
            }
            */
        }

        public Vector2 WhoToFollow(Enemy[] choices)
        {
            Vector2 closest = choices[0].loc;
            for (int i = 1; i < choices.Length; i++)
            {
                Vector2 curr = choices[i].loc;
                if (distanceTo(curr) < distanceTo(closest))
                {
                    closest = curr;
                }
            }
            if (distanceTo(closest) > 7000)
            {
                return loc;
            } else
            {
                return closest;
            }
            //return new Vector2(0, 0);
        }
        public void Draw()
        {
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
        }
    }
}
