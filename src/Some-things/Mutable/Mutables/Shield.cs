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
    public class Shield : Mutable
    {
        private static Color theme = new Color(60, 255, 200, 255);

        bool shieldDone = false;

        float size = 120 * Window.multyplier.Y;

        int thicness = (int)(4 * Window.multyplier.Y);

        float timeStamp;
        float timeLeft;
        readonly float timer = 3.6f;

        readonly float force = 80 * Window.multyplier.Y;

        public Shield(Vector2 spawn) : base(spawn, 28, theme, 0, 16) => what = Mutables.Shield;
        public override void Work()
        {
            if (isDying)
            {
                Dying();
                return;
            }
            isActive = true;

            if (shieldDone)
            {
                ability = false;
                if (timeLeft == 0)
                {
                    timeLeft = timer;
                }
                timeLeft = timeLeft - Raylib.GetFrameTime();
                float ratio = timer / timeLeft;
                byte important = (byte)(255 / ratio);
                colour.a = important;
                colour.g = important;
                int limit  = 195;

                if (colour.a < limit)
                {
                    colour.a = (byte)limit;
                }

                Game.enemies.ForEach(e =>
                {
                    if (Raylib.CheckCollisionCircles(e.loc, e.radius, Game.player.loc, size))
                    {
                        if (Raylib.CheckCollisionCircles(e.loc, e.radius, Game.player.loc, Game.player.radius + force))
                        {
                            e.SetVelocity(6);
                        } else
                        {
                            e.SetVelocity(2);
                        }
                    }
                    if (timeLeft <= 0)
                    {
                        Die();
                    }
                });
            }
            if (isDying)
            {
                Dying();
                return;
            }
            if (ability)
            {
                shieldDone = true;
                radius = -1;
                timeStamp = (Game.GetTimeMs() - Game.start) / 1000f;
            }

        }
        public override void Draw()
        {
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);

            if (!isActive) return;
             
            if (!shieldDone) return;



            //eRaylib.DrawText(timeLeft.ToString(), 15, 345, 30, Color.WHITE);

            for (var i = 0; i < thicness; i++)
            {
                Raylib.DrawCircleLines((int)Game.player.loc.X, (int)Game.player.loc.Y, size - i, colour);
            }

            //Raylib.DrawRectanglePro(wall, walldimensions / 2, wallrotation, colour);
        }
    }
}
