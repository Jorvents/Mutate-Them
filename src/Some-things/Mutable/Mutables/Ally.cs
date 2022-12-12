using MutateThem.Scenes;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MutateThem.Some_things.notPlayer;

public class Ally : Mutable
{
    public Ally(Vector2 spawn) : base(spawn, 25, Color.YELLOW, 98, 1) => what = Mutables.Ally;

    public override void Work()
    {
        if (isDying)
        {
            Dying();
            return;
        }
        if (inControl) return;
        var Theclosest = WhoTheClosest(Game.enemies);
        if (!isActive) return;
        if (Theclosest == null) return;

        Follow(Theclosest.loc);

        if (Raylib.CheckCollisionCircles(Theclosest.loc, Theclosest.radius, loc, radius))
        {
            Theclosest.Die();
            Console.WriteLine("Ally hit " + Theclosest.loc);
            Die();
        }
    }
    public override void Draw()
    {
        Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
    }
}