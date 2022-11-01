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
        Teleport,
        Shield,
    }
    public Mutables what; //ID

    private Vector2 target; 
    public Vector2 direction;
    private Vector2 farness;
    private float speed;
    public Vector2 velocity = new(1);
    private float VelocityEffect;

    public bool inControl = false; //for handdpowers code
    public float cooldown;

    Mutable Theclosest;

    public bool ability = false; //for ability mutables

    public Mutable(Vector2 loc, int radius, Color colour, float speed, float cooldown/* int whichOne, */, bool isDead = false) : base(loc, radius, colour, isDead)
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
    public Mutable WhoToFollow(List<Enemy> choices)
    {

        if (choices.Any())
        {
            isActive = true;
            Theclosest = choices.Aggregate((e1, e2) => DistanceTo(e1.loc) < DistanceTo(e2.loc) ? e1 : e2);
        } else
        {
            isActive = false;
        }

        return Theclosest;
    }

    public Vector2 Closest(List<Vector2> list)
    {
        return list.Aggregate((i1, i2) => DistanceTo(i1) < DistanceTo(i2) ? i1 : i2);
    }

    public abstract void Work();
    public abstract void Draw();
}