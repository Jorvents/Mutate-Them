using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MutateThem.Some_things.notPlayer;

public class Ally : Mutable // : Imuteable?
{
    public static readonly Vector2 Furthest = new(9999);

    Enemy Theclosest { get; set; }

    //Make the colour and size static
    //NO
    //TOO LITLE INF0
    //new ALly()
    //YES
    public Ally(Vector2 spawn) : base(spawn, 25, Color.YELLOW, 85) => what = Mutables.Ally;

    public override void Work()
    {
        if (!isActive || inControl) return;
        Follow(WhoToFollow(Game.enemies));
        //Theclosest.isTargeted 
        if (Theclosest == null) return;

        if (Raylib.CheckCollisionCircles(Theclosest.loc, Theclosest.radius, loc, radius))
        {
            Theclosest.Die();
            Console.WriteLine("Ally hit" + Theclosest.loc);
        }
    }

    public override void Draw()
    {
        //if (!isActive) return;
        Raylib.DrawCircle((int) loc.X, (int) loc.Y, radius, colour);
    }

    public Vector2 WhoToFollow(List<Enemy> choices)
    {

        var closest = Furthest;

        if (choices.Any())
        {
            //
            //choices.Where(m => what == Mutables.Throw);
            Theclosest = choices.Aggregate((e1, e2) => DistanceTo(e1.loc) < DistanceTo(e2.loc) ? e1 : e2);
            /*
            if (Theclosest.isActive)
            {
                Theclosest = null;
            }
            */
        } else
        {
            Die();
        }

        //if (Theclosest == null) closest = loc;
        if (Theclosest != null) closest = Theclosest.loc;
        //Theclosest.isTargeted = true;

        /*
        foreach (Enemy choice in choices)
        {
            Vector2 curr = choice.loc;
            if (distanceTo(curr) < distanceTo(closest))
            {
                closest = curr;
                Theclosest = choice;
            }
        }
        */
        if (DistanceTo(closest) <= 7000) return closest;

        isActive = false;
        return loc;
    }

    public void Revive()
    {
    }
}