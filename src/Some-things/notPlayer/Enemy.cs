using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MutateThem.Some_things.Me;

namespace MutateThem.Some_things.notPlayer
{

    public class Enemy : Mutateble
    {
        public Player MyEnemy { get; set; }
        public bool isDead { get; set; }
        public int whichOne { get; set; }

        //public Vector2[] vector2s { get; set; }
        public Enemy()
        {
            what = Mutatebles.Throw;
            speed = 80;
            radius = 30;
            colour = Raylib_cs.Color.RED;
            isDead = false;
            //IsActive = true;
        }
        public void Work()
        {
            if (MyEnemy.IsActive && IsActive)
            {
                target = MyEnemy.loc;
                Follow(target);
                if (Raylib.CheckCollisionCircles(MyEnemy.loc, MyEnemy.radius, loc, radius))
                {
                    Dead();
                    //Game.enemies;
                }
            }
        }
        public void Draw()
        {
            if (!IsActive) return;
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
            Raylib.DrawText(whichOne.ToString(), (int)loc.X - 10, (int)loc.Y - 10, 30, Color.WHITE);
        }
        public void Dead()
        {
            IsActive = false;
            isDead = true;
            //loc = new Vector2(9999.9f, 9999.9f);

        }
    }
}

