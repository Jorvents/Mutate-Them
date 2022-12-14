using MutateThem.Scenes;
using MutateThem.Some_things.Me;
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
        Heal
    }
    public Mutables what; //ID

    public Vector2 direction;
    public float speed;
    public Vector2 velocity = new(1);
    private float VelocityEffect;

    public bool inControl = false; //for handdpowers code
    public float cooldown;

    Mutable Theclosest;
    public Vector2 Intication;

    public bool ability = false; //for ability mutables

    public Color ogColour;

    float multyplier = Window.multyplier.Y;

    public Mutable(Vector2 loc, int radius, Color colour, float speed, float cooldown/* int whichOne, */, bool isDead = false) : base(loc, radius, colour, isDead)
    {
        this.speed = speed;
        this.cooldown = cooldown;
        ogColour = colour;
        Init();
    }
    public void Init()
    {
        colour = MixUpColour(colour);
        speed = speed * multyplier;
    }
    public void Follow(Vector2 that)
    {
        Vector2 target = that;
        Vector2 farness = loc - target;

        direction = Vector2.Normalize(farness);

        if (velocity != new Vector2(1)) // If isnt normal velocity
        {
            if (VelocityEffect != 1)
            {
                VelocityEffect += Raylib.GetFrameTime() * .1f + (VelocityEffect / 60f);
                velocity = Vector2.Lerp(velocity, new Vector2(1), VelocityEffect);
            }
            loc += -speed * Raylib.GetFrameTime() * velocity * direction;
            if (velocity.X < 0.84f && velocity.X > 1.32f || velocity.Y < 0.84f && velocity.Y > 1.32f)
            {
                velocity = new Vector2(1);
            }
        }
        else
        {
            VelocityEffect = 0;
            loc += direction * -speed * Raylib.GetFrameTime() * velocity;
        }
    }
    public void SetVelocity(float amount)
    {
        VelocityEffect = 0f;
        velocity = new Vector2(-amount * (Window.multyplier.Y / 2));
    }
    public Mutable WhoTheClosest(List<Enemy> choices)
    {
        var aliveChoices = choices.Where(e => !e.isDying);
        if (aliveChoices.Any())
        {
            isActive = true;
            Theclosest = choices.Aggregate((e1, e2) => DistanceTo(e1.loc) < DistanceTo(e2.loc) ? e1 : e2);
        } else
        {
            Die();
        }

        return Theclosest;
    }
    public void Inticator(float limit)
    {
        if (Game.player.DistanceTo(Raylib.GetMousePosition()) < limit)
        {
            Intication = Raylib.GetMousePosition() - (Vector2.Normalize(Game.player.handpowers.rotateIn) * -2);
        }
        else
        {
            Intication = Vector2.Normalize(Game.player.handpowers.rotateIn) * limit + Game.player.loc;
        }
    }
    public Color MixUpColour(Color mix)
    {
        int range = 21;

        Random rand = new Random();

        int r = mix.r;
        int g = mix.g;
        int b = mix.b;

        r = rand.Next(mix.r - range, (mix.r + range));
        if (r < 0)
        {
            r = 0;
        }
        if (r > 255)
        {
            r = 255;
        }

        g = rand.Next(mix.g - range, (mix.g + range));
        if (g < 0)
        {
            g = 0;
        }
        if (g > 255)
        {
            g = 255;
        }

        b = rand.Next(mix.b - range, (mix.b + range));
        if (b < 0)
        {
            b = 0;
        }
        if (b > 255)
        {
            b = 255;
        }

        return new Color(r,g,b, 255);
    }
    public Vector2 Closest(List<Vector2> list)
    {
        return list.Aggregate((i1, i2) => DistanceTo(i1) < DistanceTo(i2) ? i1 : i2);
    }

    public abstract void Work();
    public abstract void Draw();
}