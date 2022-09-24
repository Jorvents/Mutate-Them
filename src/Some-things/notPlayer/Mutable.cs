using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MutateThem.Some_things.notPlayer;

public abstract class Mutable : Something
{
    public enum Mutables
    {
        Throw,
        Ally,
        Bomb,
        Shield,
    }

    public Mutables what;
    public Vector2 target;
    public Vector2 direction;
    public Vector2 farness;
    public float speed;

    public Mutable(Vector2 loc, int radius, Color colour, float speed = 100, bool isActive = true) : base(loc, radius, colour, isActive)
    {
        this.speed = speed;
    }

    public void Follow(Vector2 that)
    {
        target = that;
        farness = loc - target;
        direction = Vector2.Normalize(farness);
        loc += direction * -speed * Raylib.GetFrameTime();
    }

    public Vector2 Closest(List<Vector2> list)
    {
        return list.Aggregate((i1, i2) => DistanceTo(i1) < DistanceTo(i2) ? i1 : i2);
    }

    public float DistanceTo(Vector2 vec)
    {
        double dx = loc.X - vec.X; //calculate the diffrence in x-coordinate
        double dy = loc.Y - vec.Y; //calculate the diffrence in y-coordinate
        return (float) Math.Sqrt(dx * dx + dy * dy); //use the distance formula to find the difference
    }

    public abstract void Work();
}