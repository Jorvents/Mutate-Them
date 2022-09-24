using Raylib_cs;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MutateThem.Some_things.notPlayer;

public class Ally : Mutable // : Imuteable?
{
    public static readonly Vector2 Furthest = new(9999);

    Enemy Theclosest { get; set; }

    public Ally(Vector2 spawn) : base(spawn, 25, Color.YELLOW, 85) => what = Mutables.Ally;

    public override void Work()
    {
        Follow(WhoToFollow(Game.enemies));
        if (Theclosest == null) return;

        if (Raylib.CheckCollisionCircles(Theclosest.loc, Theclosest.radius, loc, radius))
        {
            Theclosest.Die();
        }
    }

    public void Draw()
    {
        Raylib.DrawCircle((int) loc.X, (int) loc.Y, radius, colour);
    }

    public Vector2 WhoToFollow(List<Enemy> choices)
    {
        var closest = Furthest;

        if (choices.Any())
        {
            Theclosest = choices.Aggregate((e1, e2) => DistanceTo(e1.loc) < DistanceTo(e2.loc) ? e1 : e2);
        }

        if (Theclosest != null) closest = Theclosest.loc;

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