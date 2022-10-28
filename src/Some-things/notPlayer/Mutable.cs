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
        Blank = -1, //Empty
        Throw,      //Enemy
        Ally,
        Bomb,
        Shield,
    }

    public Mutables what;
    public Vector2 target;
    public Vector2 direction;
    public Vector2 farness;
    public float speed;
    public bool inControl = false; //for handdpowers code
    public Vector2 velocity = new(1);
    public float cooldown;
    private float VelocityEffect;
    //public bool onCooldown = false;
    //private string _debugString;
    //public int _debugIndex;

    public Mutable(Vector2 loc, int radius, Color colour, float speed, float cooldown/* int whichOne, */, bool isActive = true) : base(loc, radius, colour, isActive)
    {
        this.speed = speed;
        this.cooldown = cooldown;
        //_debugIndex = whichOne;
        //_debugString = $"{whichOne}";
    }
    public void Follow(Vector2 that)
    {
        target = that;
        farness = loc - target;
        direction = Vector2.Normalize(farness);
        //loc += direction * -speed * Raylib.GetFrameTime() * velocity;
        if (velocity != new Vector2(1)) // If isnt normal velocity
        {
            if (velocity.X > 0.88f && velocity.X < 1.22f || velocity.Y > 0.88f && velocity.Y < 1.22f)
            {
                velocity = new Vector2(1);
            }
            if (VelocityEffect != 1)
            {
                VelocityEffect += Raylib.GetFrameTime() * .15f;
            }
            velocity = Vector2.Lerp(velocity, new Vector2(1), VelocityEffect);

            loc += -speed * Raylib.GetFrameTime() * velocity;
        }
        else
        {
            VelocityEffect = 0;
            loc += direction * -speed * Raylib.GetFrameTime() * velocity;
        }
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
    public abstract void Draw();
}