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
        Vector2 walldimensions = new Vector2(250, 80);

        Rectangle wall = new Rectangle();

        private static Color theme = new Color(60, 255, 200, 255);

        bool shieldDone = false;

        int limit = 360;

        float wallrotation;

        int health = 20;

        public Shield(Vector2 spawn) : base(spawn, 28, theme, 0, 5) => what = Mutables.Shield;
        public override void Work()
        {
            isActive = true;

            if (!shieldDone)
            {
                Inticator(limit);

                wall = new Rectangle(Place.X, Place.Y, walldimensions.X, walldimensions.Y);

                wallrotation = Game.player.handRotation - 45;
            } else
            {
                Game.enemies.ForEach(e =>
                {
                    if (Raylib.CheckCollisionCircleRec(e.loc, e.radius, wall))
                    {
                        e.Die();
                        health -= 1;
                    }
                    if (health <= 0)
                    {
                        Die();
                    }
                });
            }

            if (ability)
            {
                shieldDone = true;
                loc = Place;

            }
            /*
            if (inControl)
            {
                shieldDone = false;
                ability = false;
            }

            if (shieldDone) return;

            isActive = true;

            wall = new Rectangle(Place.X, Place.Y, walldimensions.X, walldimensions.Y);

            Inticator(limit);

            wallrotation = Game.player.handRotation - 45;

            if (!ability) return;

            shieldDone = true;
            */
            //radius = 0;

            //loc = Place;

            //shieldDone = true;

        }
        public override void Draw()
        {
            
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
             
            if (!isActive) return;

            Raylib.DrawRectanglePro(wall, walldimensions / 2, wallrotation, colour);
        }
    }
}
