using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.Some_things.notPlayer
{
    public class Mutateble : Something
    {
        public Mutatebles what { get; set; }
        public Vector2 target { get; set; }
        public Vector2 direction { get; set; }
        public Vector2 farness { get; set; }
        public float speed { get; set; }
        public Mutateble()
        {
            /*
            switch ((int)what)
            {
                case 0:
                    Holder = Holding.Throw;
                    //BE LIKE THIS
                    break;
                case 1:
                    Holder = Holding.Ally;
                    //BE YELLOW
                    break;
                case 2:
                    Holder = Holding.Bomb;
                    //BE GREY
                    break;
                case 3:
                    Holder = Holding.Sheild;
                    //BE AQUA
                    break;
            }
            */
            speed = 100;
        }
        public void Follow(Vector2 that)
        {
            target = that;
            farness = loc - target;
            direction = Vector2.Normalize(farness);
            loc += direction * -speed * Raylib.GetFrameTime();
        }
        public Vector2 closest(Vector2 target, List<Vector2> list)
        {
            Vector2 closest = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                Vector2 curr = list[i];
                if (distanceTo(curr) < distanceTo(closest))
                {
                    closest = curr;
                }
            }
            return closest;
        }
        public float distanceTo(Vector2 vec)
        {
            double dx = loc.X - vec.X;               //calculate the diffrence in x-coordinate
            double dy = loc.Y - vec.Y;               //calculate the diffrence in y-coordinate
            return (float)Math.Sqrt(dx * dx + dy * dy);     //use the distance formula to find the difference
        }
        public enum Mutatebles
        {
            Throw = 0,
            Ally = 1,
            Bomb = 2,
            Sheild = 3,
        }
    }
}
