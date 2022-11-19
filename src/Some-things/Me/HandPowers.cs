﻿using System.Linq;
using Raylib_cs;
using System.Numerics;
using MutateThem.Some_things.notPlayer;
using static Raylib_cs.Color;
using MutateThem.GUI;

namespace MutateThem.Some_things.Me;

public class HandPowers : Something //Mutating
{
    public enum Holding
    {
        Throw,
        Ally,
        Bomb,
        Teleport,
        Shield
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
    Mutable graberia; //Holding
    //public int idHolding;

    public HandPowers(Vector2 loc) : base(loc, 18, BLANK)
    {
        disctance = (int)(88 * Window.multyplier.Y);
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
            graberia.inControl = false;
            graberia.ability = true;
            if (Holder == 0) //If holding enemy
            {
                //graberia.GravityPush(-8.5f);
                graberia.SetVelocity(-22.5f);
            } else
            {
                graberia.SetVelocity(3.3f);
            }
            isActive = true;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            if ((int)Holder == Game.lastPressed3) return; //Im proud of that
            if (Selected.Cooldowns[Game.lastPressed3] != 0) return; // and that :D
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
                case 2:
                    graberia = new Bomb(loc);
                    break;
                case 3:
                    graberia = new Teleport(loc);
                    break;
                case 4:
                    graberia = new Shield(loc);
                    break;
            }
            graberia.inControl = true;
            Game.mutables.Add(graberia);
            if (graberia.what == 0)
            {
                Game.enemies.Add((Enemy)graberia);
            }
            Selected.AddCooldown((int)graberia.what);
        }
        if(graberia.isDead)
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
        //Raylib.DrawText(rotateIn.ToString(), 15, 225, 30, WHITE);
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