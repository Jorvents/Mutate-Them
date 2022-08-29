using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MutateThem.Some_things.Me;

namespace MutateThem.Some_things
{

    public class Enemy : Something
    {
        Vector2 target { get; set; }
        Vector2 direction { get; set; }
        Vector2 farness { get; set; }
        public Player MyEnemy { get; set; }
        float speed { get; set; }
        //public Vector2[] vector2s { get; set; }
        public Enemy()
        {
            speed = 80;
            radius = 30;
            colour = Raylib_cs.Color.RED;
            //IsActive = true;
        }
        public void Work()
        {
            if (MyEnemy.IsActive)
            {
                if (IsActive)
                {
                    target = MyEnemy.loc;
                    farness = loc - target;
                    direction = Vector2.Normalize(farness);
                    loc += direction * -speed * Raylib.GetFrameTime();
                    if (Raylib.CheckCollisionCircles(MyEnemy.loc, MyEnemy.radius, loc, radius))
                    {
                        //loc = new Vector2(9999.9f, 9999.9f);
                        IsActive = false;
                        //loc = new Vector2();
                    }
                }
            }
        }
        public void Draw()
        {
            if (!IsActive) return;
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
        }
    }
}

