using MutateThem.Scenes;
using MutateThem.Some_things.Me;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.Some_things.notPlayer
{
    public class Teleport : Mutable
    {
        float limit = 586 * Window.multyplier.Y;
        
        Color indicator = new Color(255, 255, 255, 210); // might make a indicator class out of something class and add it to mutables //SIZE //COLOUR //LOC

        public Teleport(Vector2 spawn) : base(spawn, 22, Color.DARKPURPLE, 0, 12) => what = Mutables.Teleport;
        public override void Work()
        {
            if (isDying)
            {
                Dying();
                return;
            }

            Inticator(limit);

            if (!ability) return;

            Game.player.loc = Intication;
            Die();
        }
        public override void Draw()
        {
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);

            if (isDying) return;

            if (Intication == new Vector2(0)) return;
            Raylib.DrawCircle((int)Intication.X, (int)Intication.Y, 13, indicator); //indicator
        }
    }
}
