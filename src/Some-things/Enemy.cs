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
        public Vector2 target { get; set; }
        public Vector2 direction { get; set; }
        public Vector2 farness { get; set; }
        public Player MyEnemy { get; set; }
        public float speed { get; set; }
        //public Vector2[] vector2s { get; set; }
        public Enemy(/*Player player*/)
        {
            //ScatterThem(5);
            //MyEnemy = player;
            //player.loc[0] = target;
            //loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
            /*
            var rndm = new Random();
            loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
            */
            /*
            var rndm = new Random();
            loc =  new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
            */
            speed = 80;
            radius = 30;
            colour = Raylib_cs.Color.RED;
        }
        public void Work()
        {
            if (this.MyEnemy.IsPlaying)
            {
                target = this.MyEnemy.loc;
                farness = loc - target;
                direction = Vector2.Normalize(farness);
                loc += direction * -speed * Raylib.GetFrameTime();
                if (Raylib.CheckCollisionCircles(this.MyEnemy.loc, this.MyEnemy.radius, loc, this.radius))
                {
                    //loc = new Vector2(9999.9f, 9999.9f);
                    isDead = true;
                }
                /*
                for (int i = 0; i < count; i++)
                {
                    target = MyEnemy.loc;
                    farness = loc - target;
                    direction = Vector2.Normalize(farness);
                    loc += direction * -speed * Raylib.GetFrameTime();
                    if (Raylib.CheckCollisionCircles(MyEnemy.loc, MyEnemy.radius, loc, this.radius))
                    {
                        loc = new Vector2(9999.9f, 9999.9f);
                    }
                }
                */
            }
        }
    }
}

