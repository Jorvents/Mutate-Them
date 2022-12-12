using System;
using System.Drawing;
using System.Numerics;
using Raylib_cs;
using Color = Raylib_cs.Color;

namespace MutateThem;

public abstract class Something //GameObject
{
    public Vector2 loc;
    public float radius;
    public Color colour;
    public bool isActive = false;

    public bool isDying; 
    public bool isDead; //=> !isActive; //dumb

    protected Something(Vector2 loc, int radius, Color colour, bool isDead = false)
    {
        this.loc = loc;
        this.radius = radius;
        this.colour = colour;
        this.isDead = isDead;

        Init();
    }
    public void Init()
    {
        radius = (int)(radius * Window.multyplier.Y);
    }
    public void Die()
    {
        isDying = true;
    }
    public void Dying()
    {
        if (colour.a - 800 * Raylib.GetFrameTime() * (Window.multyplier.Y / 2) > 0)
        {
            radius = radius + 66f * Raylib.GetFrameTime() * (Window.multyplier.Y / 2);
            colour.a = (byte)(colour.a - 901 * Raylib.GetFrameTime() * (Window.multyplier.Y / 2));
        } else
        {
            colour.a = 0;
            isDead = true;
        }
    }
    public float Angle(Vector2 first, int secondX, int secondY)
    {
        double angleD;
        angleD = Math.Atan2(first.Y - secondY, first.X - secondX);
        angleD = 180f / Math.PI * angleD;

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
}