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
    Enemy graberiaEnemy;
    Ally graberiaAlly;

    public HandPowers(Vector2 loc) : base(loc, 18, WHITE)
    {
        disctance = 88;
        //graberiaAlly = new Ally(new Vector2(6000,6000));
        //IsActive = true;
    }

    public void Work()
    {
        loc = rotateIn + stickTo;
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
        }
        
        if (!isActive && Holder == Holding.Ally && rightclicked)
        {
            isActive = true;
            Game.allies.Add(new Ally(loc));
        }

        if (!isActive && Holder == Holding.Throw && rightclicked) isActive = true;

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

    public void Draw()
    {
        Raylib.DrawText(Holder.ToString(), 15, 75, 30, WHITE);
        Raylib.DrawText(Game.allies.Count.ToString(), 15, 105, 30, WHITE);

        Raylib.DrawCircle((int) loc.X, (int) loc.Y, radius, colour);

        //DrawHolding(holding);
        if (isActive) return;
        
        switch ((int) Holder)
        {
            case 0:
                Raylib.DrawCircle((int) loc.X, (int) loc.Y, graberiaEnemy.radius, graberiaEnemy.colour);
                break;
            case 1:
                if (graberiaAlly != null)
                {
                    Raylib.DrawCircle((int) loc.X, (int) loc.Y, graberiaAlly.radius, graberiaAlly.colour);
                }

                Raylib.DrawCircle((int) loc.X, (int) loc.Y, 25, YELLOW);
                break;
        }
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