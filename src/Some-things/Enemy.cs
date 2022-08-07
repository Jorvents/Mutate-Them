using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace MutateThem.Some_things
{

    public class Enemy : Something
    {
        public int count { get; set; }
        public Vector2 target { get; set;}
        public Vector2 direction { get; set; }
        public Vector2 farness { get; set; }
        public Player MyEnemy { get; set; }
        public float speed { get; set; }
        //public Vector2[] vector2s { get; set; }
        public Enemy(Player player)
        {
            ScatterThem(5);
            MyEnemy = player;
            //player.loc[0] = target;
            //loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
            speed = 80;
            radius = 30;
            colour = Raylib_cs.Color.RED;
        }
        public void Work()
        {
            if (MyEnemy.IsPlaying)
            {
                for (int i = 0; i < count; i++)
                {
                    target = MyEnemy.loc[0];
                    farness = loc[i] - target;
                    direction = Vector2.Normalize(farness);
                    loc[i] += direction * -speed * Raylib.GetFrameTime();
                    if (Raylib.CheckCollisionCircles(MyEnemy.loc[0], MyEnemy.radius, loc[i], this.radius))
                    {
                        loc[i] = new(9999.0f, 9999.0f);
                    }
                }

            }
            //directionX = farness.X / farness.Y;
            //directionY = farness.Y / farness.X;
            //direction = new(farness.X, farness.X);
        }
        public void ScatterThem(int count)
        {
            this.count = count;
            loc = new Vector2[this.count];

            var rndm = new Random();

            for (int i = 0; i < count; i++)
            {
                loc[i] = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
            }
        }

    }
}
