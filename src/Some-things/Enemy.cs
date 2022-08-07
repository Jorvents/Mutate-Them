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
        public Enemy[] enemies { get; set; }
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
                    target = MyEnemy.loc;
                    farness = enemies[i].loc - target;
                    direction = Vector2.Normalize(farness);
                    enemies[i].loc += direction * -speed * Raylib.GetFrameTime();
                    if (Raylib.CheckCollisionCircles(MyEnemy.loc, MyEnemy.radius, enemies[i].loc, this.radius))
                    {
                        enemies[i].isDead = true;
                    }
                }

            }
            //directionX = farness.X / farness.Y;
            //directionY = farness.Y / farness.X;
            //direction = new(farness.X, farness.X);
        }
        public void ScatterThem(int count)
        {
            //this.count = count;
            enemies = new Enemy[count];
            //enemies = new Enemy[this.count];
            //enemies.loc = new Vector2[this.count];

            var rndm = new Random();

            for (int i = 0; i < count; i++)
            {

                /*
                enemies[i] = new Enemy(MyEnemy);
                enemies[i].loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
                //loc[i] = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
                //enemies = new Enemy[i];
                /*
                enemies[i] ??= new Enemy(MyEnemy);
                enemies[i].loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
                */
            }
        }

    }
}
