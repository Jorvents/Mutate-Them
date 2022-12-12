using System.Numerics;
using Raylib_cs;
using MutateThem.Some_things.Me;

namespace MutateThem.Some_things.notPlayer;

public class Enemy : Mutable
{
    public Player myEnemy;

    public bool isTargeted = false;

    public Enemy(Player player, Vector2 loc) : base(loc, 30, new Color(241, 28, 49, 255), 72, 0/* _debugString.parseInt(),*/)
    {
        what = Mutables.Throw;
        myEnemy = player;
    }

    public override void Work()
    {
        if (isDying)
        {
            Dying();
            return;
        }
        if (!myEnemy.isActive || inControl) return;

        
        Follow(myEnemy.loc);
        if (Raylib.CheckCollisionCircles(myEnemy.loc, myEnemy.radius, loc, radius))
        {
            Die();
            myEnemy.Damage(1);
        };
    }

    public override void Draw()
    {
        Raylib.DrawCircle((int) loc.X, (int) loc.Y, radius, colour);
    }
}