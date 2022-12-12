using System.Linq;
using Raylib_cs;
using System.Numerics;
using MutateThem.Some_things.notPlayer;
using Raylib_cs;
using MutateThem.Scenes;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.ComponentModel;
using static MutateThem.Some_things.notPlayer.Mutable;

namespace MutateThem.Some_things.Me;

public class HandPowers : Something //Mutating
{
    public enum Holding
    {
        Throw,
        Ally,
        Bomb,
        Teleport,
        Shield,
        //Teleport,
        Heal
    }
    
    public Vector2 stickTo;
    public int disctance;

    public Vector2 rotateIn;

    //public Enemy[] grabbingEnemy { get; set; }
    //public Ally[] grabbingAlly { get; set; }
    //public Mutateble holding { get; set; }
    //public bool leftclicked;

    //public bool rightclicked;

    //public int choosen { get; set; }
    public Holding Holder;
    //Enemy graberiaEnemy;
    //Ally graberiaAlly;
    public Mutable graberia; //Holding
                      //public int idHolding;
    readonly bool oldSystem = false;

    bool interuptrealease = false; //Makes it so that player cant take mutable and realese it at the same frame, witout it it couses a mutable just stand still and do nothing and wastes the cooldown

    public HandPowers(Vector2 loc) : base(loc, 18, Color.BLANK)
    {
        disctance = (int)(88 * Window.multyplier.Y);
        //graberiaAlly = new Ally(new Vector2(6000,6000));
        //IsActive = true;
    }

    public void Work()
    {
        loc = rotateIn + stickTo;
        foreach (var t in Game.mutables.Where(t =>
                     Raylib.CheckCollisionCircles(t.loc, 3, loc, radius) && isActive && !t.isDying && !t.ability && Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT)))
        {
            interuptrealease = true;

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

        if(!oldSystem)
        {
            if (graberia.what == Mutable.Mutables.Throw)
            {
                Holder = (Holding)(Game.lastPressed3 + 1);
            }

            if (Game.enemies.Count == 1 && Game.mutables.Count == 1)
            {
                graberia.Die();
                //Holder = (Holding)99;
                return;
            }
            else if (Game.enemies.Count == 0 && Game.mutables.Count == 0)
            {
                return;
            }

            if ((int)Holder != Game.lastPressed3)
            {
                Holder = (Holding)Game.lastPressed3;

                //graberia.isDead = true;

                if (Game.enemies.Count == 1 && Game.mutables.Count >= 1)
                {
                    if (graberia.what == Mutable.Mutables.Throw)
                    {
                        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
                        {
                            graberia.inControl = false;
                            graberia.ability = true;

                            graberia.SetVelocity(18.5f);

                            isActive = true;
                        }
                        return;
                    }
                }

                graberia.isDead = true;

                switch ((int)Holder)
                {
                    case 0:
                        graberia = new Ally(loc);
                        break;
                    case 1:
                        graberia = new Bomb(loc);
                        break;
                    case 2:
                        graberia = new Teleport(loc);
                        break;
                    case 3:
                        graberia = new Shield(loc);
                        break;
                    case 4:
                        graberia = new Heal(loc);
                        break;
                    default:
                        graberia = new Empty();
                        break;
                }
                graberia.inControl = true;
                Game.mutables.Add(graberia);

                if (graberia.what == 0)
                {
                    Game.enemies.Add((Enemy)graberia);
                }
            } //Im very proud of that
            

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                if (interuptrealease) return;
                if (Game.selected.Cooldowns[Game.lastPressed3] != 0) return; // and that :D C:

                if (graberia.what != Mutable.Mutables.Heal)
                {
                    graberia.SetVelocity(0.85f);
                } else
                {
                    graberia.SetVelocity(0.25f);
                }
                
                
                Game.selected.AddCooldown((int)graberia.what - 1);
                graberia.ability = true;
                graberia.inControl = false;
                isActive = true;
            }
        } 
        else
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                graberia.inControl = false;
                graberia.ability = true;
                if (Holder == 0) //If holding enemy
                {
                    //graberia.GravityPush(-8.5f);
                    graberia.SetVelocity(22.5f);
                }
                else
                {
                    graberia.SetVelocity(-3.3f);
                }
                isActive = true;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                if ((int)Holder == Game.lastPressed3) return; //Im proud of that
                if (Game.selected.Cooldowns[Game.lastPressed3] != 0) return; // and that :D
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
                    case 5:
                        graberia = new Heal(loc);
                        break;
                }
                graberia.inControl = true;
                Game.mutables.Add(graberia);
                if (graberia.what == 0)
                {
                    Game.enemies.Add((Enemy)graberia);
                }
                Game.selected.AddCooldown((int)graberia.what);
            }
        }

        interuptrealease = false;

        /*
        
        */
        if (graberia.isDying || graberia.isDead)
        {
            isActive = true;
        }
        //FROM HERE YOU CAN SEE THE WAR CRIME OF MY CODE THAT WAS TESTED AND TESTED AND TESTED

        /*
        if (!isActive && Holder == Holding.Throw && rightclicked)
        {
            isActive = true;
            graberia.inControl = false;                        eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
                                                               eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            //Game.enemies.Add(graberia);                      eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            Game.allies.Add((Ally)graberia);                   eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
        }                                                      eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee

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
        }
        */
        /*
        if (graberia != null && !isActive)                                                                 oooooooooooooooooooooooooooooooooooooooooooo
        {                                                                                                  oooooooooooooooooooooooooooooooooooooooooooo
            graberia.loc = loc;                                                                            oooooooooooooooooooooooooooooooooooooooooooo
        }                                                                                                  oooooooooooooooooooooooooooooooooooooooooooo
        if (!isActive && Holder == Holding.Ally && rightclicked)                                           oooooooooooooooooooooooooooooooooooooooooooo
        {                                                                                                  oooooooooooooooooooooooooooooooooooooooooooo
            isActive = true;                                                                               oooooooooooooooooooooooooooooooooooooooooooo
            Ally adding = new Ally(loc);                                                                   oooooooooooooooooooooooooooooooooooooooooooo
            Game.allies.Add(adding);                                                                       oooooooooooooooooooooooooooooooooooooooooooo
            Game.mutables.Add(adding);                                                                     oooooooooooooooooooooooooooooooooooooooooooo
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
        {                                                                         aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            case 0:                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                Holder = Holding.Throw;                                           aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                //BE LIKE THIS                                                    aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                break;                                                            aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            case 1:                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                Holder = Holding.Ally;                                            aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                //BE YELLOW                                                       aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                break;                                                            aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            case 2:                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                Holder = Holding.Bomb;                                            aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                //BE GREY                                                         aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                break;                                                            aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            case 3:                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
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

        Raylib.DrawText(Holder.ToString(), 15, 75, 30, Color.WHITE);
        //Raylib.DrawText(rotateIn.ToString(), 15, 225, 30, WHITE);
        Raylib.DrawText(isActive.ToString(), 15, 250, 30, Color.WHITE);
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