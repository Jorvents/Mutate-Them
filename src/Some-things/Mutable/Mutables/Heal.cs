using MutateThem.Scenes;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.Some_things.notPlayer
{
    public class Heal : Mutable
    {
        readonly byte heals = 3;

        public Heal(Vector2 spawn) : base(spawn, 18, Color.GREEN, 3860, 25) => what = Mutables.Heal;

        public override void Work()
        {
            if (isDying)
            {
                Dying();
                return;
            }
            if (ability)
            {
                Follow(Game.health.centre);
                if (Raylib.CheckCollisionCircleRec(loc, radius, Game.health.border))
                {
                    Game.player.health = Game.player.health + heals;
                    if (Game.player.maxhealth < Game.player.health)
                    {
                        Game.player.health = Game.player.maxhealth;
                    }
                    Die();
                }
            }
        }
        public override void Draw()
        {
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
        }
    }
}
