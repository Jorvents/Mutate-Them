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
        //public Enemy[] grabbingEnemy { get; set; }
        //public Ally[] grabbingAlly { get; set; }
        //public Mutateble holding { get; set; }
        public bool leftclicked { get; set; }
        public bool rightclicked { get; set; }
        //public int choosen { get; set; }
        public Holding Holder { get; set; }
        Enemy graberiaEnemy { get; set; }
        Ally graberiaAlly { get; set; }

        public HandPowers()
        {
            radius = 18;
            colour = Raylib_cs.Color.WHITE;
            disctance = 88;
            //graberiaAlly = new Ally(new Vector2(6000,6000));
            //IsActive = true;
        }
        public void Work()
        {
            loc = rotateIn + stickTo;
            for (int i = 0; i < Game.allies.Count; i++)
            {
                if (Raylib.CheckCollisionCircles(Game.allies[i].loc, 3, loc, radius) && IsActive && leftclicked)
                {
                    IsActive = false;
                    Game.allies[i].IsActive = false;
                    Holder = Holding.Ally;
                    graberiaAlly = Game.allies[i];
                }
            }
            if (!IsActive && Holder == Holding.Ally)
            {
                if (rightclicked)
                {
                    IsActive = true;
                    Game.allies.Add(new Ally(loc));
                }
            }
            for (int i = 0; i < Game.enemies.Count; i++)
            {
                if (Raylib.CheckCollisionCircles(Game.enemies[i].loc, 3, loc, radius) && IsActive && leftclicked)
                {
                    IsActive = false;
                    Holder = Holding.Throw;
                    graberiaEnemy = Game.enemies[i];
                    Game.enemies[i].Dead();
                }
            }
            if (!IsActive && Holder == Holding.Throw)
            {
                if (rightclicked)
                {
                    IsActive = true;
                }
            }
            /*
            switch ((int)Holder)
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
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                Holder = (Holding)Game.lastPressed3;
            }
            /*
            if ((int)Holder == Game.lastPressed3)
            {
                //has the current selected
            }
            else
            {

            }
            */
        }
        public void Draw()
        {
            Raylib.DrawText(Holder.ToString(), 15, 75, 30, Color.WHITE);
            Raylib.DrawText(Game.allies.Count.ToString(), 15, 105, 30, Color.WHITE);

            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);

            //DrawHolding(holding);
            if (!IsActive) 
            {
                switch((int)Holder)
                {
                    case 0:
                    Raylib.DrawCircle((int)loc.X, (int)loc.Y, graberiaEnemy.radius, graberiaEnemy.colour);
                    break;
                    case 1:
                    if (graberiaAlly != null)
                    {
                        Raylib.DrawCircle((int)loc.X, (int)loc.Y, graberiaAlly.radius, graberiaAlly.colour);
                    }
                    Raylib.DrawCircle((int)loc.X, (int)loc.Y, 25, Raylib_cs.Color.YELLOW);
                    break;
                }
            }
        }
        public void DrawHolding(Mutateble holding)
        {
            /*
            switch ((int)holding.what)
            {
                case
            }
            */
            Raylib.DrawCircle((int)holding.loc.X, (int)holding.loc.Y, holding.radius, holding.colour);
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
