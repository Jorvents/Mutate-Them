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
        float limit = 586f;
        //float min = 50f;
        bool tpdone = false;
        Color indicator = new Color(255, 255, 255, 210); // might make a indicator class out of something class and add it to mutables //SIZE //COLOUR //LOC
        Vector2 locTP;
        public Teleport(Vector2 spawn) : base(spawn, 22, Color.DARKPURPLE, 0, 4) => what = Mutables.Teleport;
        public override void Work()
        {
            //if (!isActive) return;
            if (tpdone) return;

            if (Game.player.DistanceTo(Raylib.GetMousePosition()) < limit)
            {
                locTP = Raylib.GetMousePosition();
                //Game.player.loc = Vector2.Normalize(Game.player.handpowers.rotateIn) * range + Game.player.loc;
            }
            else
            {
                locTP = Vector2.Normalize(Game.player.handpowers.rotateIn) * limit + Game.player.loc;
            }

            if (!ability) return;

            Game.player.loc = locTP;
            Die();

        }
        public override void Draw()
        {
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);

            if (inControl) return;

            Raylib.DrawCircle((int)locTP.X, (int)locTP.Y, 13, indicator); //indicator
        }
    }
}
