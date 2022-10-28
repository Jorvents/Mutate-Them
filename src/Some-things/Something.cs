using System;
using System.Numerics;
using Raylib_cs;

namespace MutateThem;

public abstract class Something
{
    public Vector2 loc;
    public int radius;
    public Color colour;
    public bool isActive;

    public bool IsDead => !isActive;

    protected Something(Vector2 loc, int radius, Color colour, bool isActive = true)
    {
        this.loc = loc;
        this.radius = radius;
        this.colour = colour;
        this.isActive = isActive;
    }

    public void Die()
    {
        isActive = false;
        //loc = new Vector2(9999, 9999);
    }
    public float Angle(Vector2 first, int secondX, int secondY)
    {
        double angleD;
        angleD = Math.Atan2(first.Y - secondY, first.X - secondX);
        angleD = 180f / Math.PI * angleD;

        //Math.Atan2;
        //Math.Tau;
        //angleD = -angleD;
        return (float)angleD;
    }
    public Vector2 toVector(float angle)
    {
        double angleD = angle / (180 / Math.PI);
        return new Vector2((float)Math.Cos(angleD), (float)Math.Sin(angleD));
    }
    /*
    public void Draw()
    {
        //loc.X += MoveX * Raylib.GetFrameTime();
        //Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
        if (isDead) return;
        Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
    }
    /*
    public void Update()
    {
        x += MoveX * Raylib.GetFrameTime();
        y += MoveY * Raylib.GetFrameTime();
    }
    */
}