using MutateThem.Scenes;
using MutateThem.Some_things.notPlayer;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.GUI
{
    class EnemyCountre
    {
        float rightwards = 20 * Window.multyplier.Y;
        float downwards = 20 * Window.multyplier.Y;
        int size = 80;
        int spacing = 30;

        public void Draw()
        {
            Vector2 loc = new Vector2(rightwards, downwards);
            string text = Game.enemies.Count.ToString() + " x";

            Raylib.DrawTextEx(Raylib.GetFontDefault(), text, loc, size, 2, Window.agedblue);

            Mutable draw = Game.mutablescontroller.info[0];
            Vector2 iconloc = new Vector2(Raylib.MeasureText(text, size) + rightwards + (spacing * Window.multyplier.Y), downwards + size / 2.3f);

            Raylib.DrawCircle((int)iconloc.X, (int)iconloc.Y, draw.radius, draw.ogColour);
        }
    }
}
