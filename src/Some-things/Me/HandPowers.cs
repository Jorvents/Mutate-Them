using System.Linq;
using Raylib_cs;
using System.Numerics;
using MutateThem.Some_things.notPlayer;
using static Raylib_cs.Color;

namespace MutateThem.Some_things.Me;

public class HandPowers : Something //Mutating
{
    public enum Holding
    {
        Throw,
        Ally,
        Bomb,
        Shield,
        //Teleport,
        //Heal,
    }
    
    public Vector2 stickTo;
    public int disctance;

    public Vector2 rotateIn;

    //public Enemy[] grabbingEnemy { get; set; }
    //public Ally[] grabbingAlly { get; set; }
    //public Mutateble holding { get; set; }
    public bool leftclicked;

    public bool rightclicked;

    //public int choosen { get; set; }
    public Holding Holder;
    //Enemy graberiaEnemy;
    //Ally graberiaAlly;
    Mutable graberia;
    //public int idHolding;

    public HandPowers(Vector2 loc) : base(loc, 18, BLANK)
    {
        disctance = 88;
        //graberiaAlly = new Ally(new Vector2(6000,6000));
        //IsActive = true;
    }

    public void Work()
    {
        loc = rotateIn + stickTo;
        foreach (var t in Game.mutables.Where(t =>
                     Raylib.CheckCollisionCircles(t.loc, 3, loc, radius) && isActive && leftclicked))
        {
            isActive = false;
            //t.isActive = false;
            Holder = (Holding)t.what;
            //t.Die();
            t.inControl = true;
            //idHolding = Game.mutables.IndexOf(t);
            graberia = t;

            //Game.mutables.Remove(t);
        }

        if (isActive) return;

        graberia.loc = loc;

        if (rightclicked)
        {
            if (Holder == 0) //If holding enemy
            {
                graberia.velocity = graberia.direction + new Vector2(-8.5f);
            }
            isActive = true;
            graberia.inControl = false;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            if ((int)Holder == Game.lastPressed3) return; //Im proud of that
            Holder = (Holding)Game.lastPressed3;

            graberia.Die();
            switch ((int)Holder)
            {
                case 0:
                    graberia = new Enemy(Game.player, loc);
                    break;
                case 1:
                    graberia = new Ally(loc);
                    break;
            }
            Game.mutables.Add(graberia);
        }
        if(graberia.IsDead)
        {
            isActive = true;
        }
        //FROM HERE YOU CAN SEE THE WAR CRIME OF MY CODE THAT WAS TESTED AND TESTED AND TESTED

        /*
        if (!isActive && Holder == Holding.Throw && rightclicked)
        {
            isActive = true;
            graberia.inControl = false;

            //Game.enemies.Add(graberia);
            Game.allies.Add((Ally)graberia);
        }

        //graberia = new Ally(new(100));
        /*
        //#######################################################
        foreach (var t in Game.allies.Where(t =>
                     Raylib.CheckCollisionCircles(t.loc, 3, loc, radius) && isActive && leftclicked))
        {
            isActive = false;
            Holder = Holding.Ally;
            t.Die();
            graberiaAlly = t;
        }
        
        //###########################################################
        foreach (var t in Game.enemies.Where(t =>
                     Raylib.CheckCollisionCircles(t.loc, 3, loc, radius) && isActive && leftclicked))
        {
            isActive = false;
            Holder = Holding.Throw;
            t.Die();
            graberiaEnemy = t;
        }*/
        /*
        if (graberia != null && !isActive)
        {
            graberia.loc = loc;
        }
        if (!isActive && Holder == Holding.Ally && rightclicked)
        {
            isActive = true;
            Ally adding = new Ally(loc);
            Game.allies.Add(adding);
            Game.mutables.Add(adding);
        }

        if (!isActive && Holder == Holding.Throw && rightclicked)
        {
            isActive = true;
            graberia.inControl = false;

            //Game.enemies.Add(graberia);
            Game.mutables.Add(graberia);
        }
         */
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
                Holder = Holding.Shield;
                //BE AQUA
                break;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) Holder = (Holding) Game.lastPressed3;
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
    //this not a war crime, its a work of art
    public void Draw()
    {
        Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);

        Raylib.DrawText(Holder.ToString(), 15, 75, 30, WHITE);
        Raylib.DrawText(isActive.ToString(), 15, 250, 30, WHITE);
        /*
        if (Game.mutables.Any())
        {
            Raylib.DrawText(Game.mutables.First().velocity.ToString(), 15, 250, 30, WHITE);
        }
        //Raylib.DrawText(Game.allies.Count.ToString(), 15, 105, 30, WHITE);
        //Raylib.DrawText(idHolding.ToString(), 15, 165, 30, WHITE);

        //DrawHolding(holding);
        //if (isActive) return;
        //Raylib.DrawCircle((int)loc.X, (int)loc.Y, graberia.radius, graberia.colour);
        /*
        switch ((int) Holder)
        {
            case 0:
                Raylib.DrawCircle((int) loc.X, (int) loc.Y, graberia.radius, graberia.colour);
                break;
            case 1:
                /*
                if (graberiaAlly != null)
                {
                    Raylib.DrawCircle((int) loc.X, (int) loc.Y, graberiaAlly.radius, graberiaAlly.colour);
                }
                *//*
                Raylib.DrawCircle((int) loc.X, (int) loc.Y, 25, YELLOW);
                break;
        }
        */
    }

    public void DrawHolding(Mutable holding)
    {
        /*
        switch ((int)holding.what)
        {
            case
        }
        */
        Raylib.DrawCircle((int) holding.loc.X, (int) holding.loc.Y, holding.radius, holding.colour);
    }
}