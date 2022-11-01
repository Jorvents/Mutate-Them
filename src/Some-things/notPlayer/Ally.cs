using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MutateThem.Some_things.notPlayer;

public class Ally : Mutable // : Imuteable?
{
    //Enemy Theclosest { get; set; }

    //Make the colour and size static
    //NO
    //TOO LITLE INF0
    //new ALly()
    //YES
    public Ally(Vector2 spawn) : base(spawn, 25, Color.YELLOW, 88, 5) => what = Mutables.Ally;

    public override void Work()
    {
        if (inControl) return;
        var Theclosest = WhoToFollow(Game.enemies);
        if (!isActive) return;
        if (Theclosest == null) return;

        Follow(Theclosest.loc);
        //Theclosest.isTargeted

        if (Raylib.CheckCollisionCircles(Theclosest.loc, Theclosest.radius, loc, radius))
        {
            Theclosest.Die();
            Console.WriteLine("Ally hit " + Theclosest.loc);
        }
    }
    public override void Draw()
    {
        //if (!isActive) return;
        Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
    }
}