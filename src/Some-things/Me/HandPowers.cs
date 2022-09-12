using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MutateThem.Some_things.notPlayer;

namespace MutateThem.Some_things.Me
{
    public class HandPowers : Something
    {
        public Vector2 stickTo { get; set; }
        public int disctance { get; set; }
        public Vector2 rotateIn { get; set; }
        public Enemy[] grabbing { get; set; }
        public bool leftclicked { get; set; }
        public bool rightclicked { get; set; }
        public int choosen { get; set; }
        public Holding Holder { get; set; }
        Enemy graberia { get; set; }
        public HandPowers()
        {
            radius = 18;
            colour = Raylib_cs.Color.WHITE;
            disctance = 88;
            //IsActive = true;
        }
        public void Work()
        {
            loc = rotateIn + stickTo;
            foreach (Enemy grabers in grabbing)
            {
                graberia = grabers;
                if (!IsActive)
                {
                    //DrawGrab(grabers);
                    if (rightclicked)
                    {
                        IsActive = true;
                    }
                    /*
                    int WhatHolding = (int)grabers.what;
                    switch (WhatHolding)
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
                    if ((int)Holder == choosen)
                    {
                        //has the current selected
                    } else
                    {

                    }
                    */
                }
                if (Raylib.CheckCollisionCircles(grabers.loc, 3, loc, radius) && IsActive && leftclicked)
                {
                    IsActive = false;
                    grabers.Dead();
                    //grabers.isDead = false;
                    /*
                    Random rand = new Random();
                    grabers.radius = rand.Next(20,40);
                    switch (rand.Next(1, 4))
                    {
                        case 1:
                            grabers.colour = Color.VIOLET;
                            break;
                        case 2:
                            grabers.colour = Color.YELLOW;
                            break;
                        case 3:
                            grabers.colour = Color.GREEN;
                            break;
                    }
                    */
                }
            }
        }
        public void Draw()
        {
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
            if (!IsActive) 
            {
                Raylib.DrawCircle((int)loc.X, (int)loc.Y, graberia.radius, graberia.colour);
            }
        }
        public enum Holding
        {
            Throw = 0,
            Ally = 1,
            Bomb = 2,
            Sheild = 3,
        }
    }
}
