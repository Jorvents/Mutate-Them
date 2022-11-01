using System;
using System.Numerics;
using Raylib_cs;

namespace MutateThem;

public abstract class Something //GameObject
{
    public Vector2 loc;
    public int radius;
    public Color colour;
    public bool isActive = true;

    public bool isDead; //=> !isActive; //dumb

    protected Something(Vector2 loc, int radius, Color colour, bool isDead = false)
    {
        this.loc = loc;
        this.radius = radius;
        this.colour = colour;
        this.isDead = isDead;
        //this.isActive = isActive;
    }

    public void Die()
    {
        //isActive = false;
        isDead = true;
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
    public float DistanceTo(Vector2 vec)
    {
        double dx = loc.X - vec.X; //calculate the diffrence in x-coordinate
        double dy = loc.Y - vec.Y; //calculate the diffrence in y-coordinate
        return (float)Math.Sqrt(dx * dx + dy * dy); //use the distance formula to find the difference
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