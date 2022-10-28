using System.Numerics;
using Raylib_cs;
using MutateThem.Some_things.Me;

namespace MutateThem.Some_things.notPlayer;

public class Enemy : Mutable
{
    public Player myEnemy;

    //private string _debugString;

    public bool isTargeted = false;
    public int whichOne { get; set; }

    //public Vector2[] vector2s { get; set; }
    public Enemy(Player player, Vector2 loc, /*int whichOne,*/ bool isAlive = true) : base(loc, 30, Color.RED, 80, 20,/* _debugString.parseInt(),*/ isAlive)
    {
        what = Mutables.Throw;
        myEnemy = player;
        //_debugString = $"{whichOne}";
    }

    public override void Work()
    {
        if (!myEnemy.isActive || /*!isActive ||*/ inControl) return;

        target = myEnemy.loc;
        Follow(target);
        if (Raylib.CheckCollisionCircles(myEnemy.loc, myEnemy.radius, loc, radius))
        {
            Die();
            myEnemy.Damage(1);
        };
    }

    public override void Draw()
    {
        //if (!isActive) return;

        Raylib.DrawCircle((int) loc.X, (int) loc.Y, radius, colour);
        //Raylib.DrawText(_debugString, (int) loc.X - 10, (int) loc.Y - 10, 30, Color.WHITE);
        Raylib.DrawText(whichOne.ToString(), (int)loc.X - 10, (int)loc.Y - 10, 30, Color.WHITE);
    }
}