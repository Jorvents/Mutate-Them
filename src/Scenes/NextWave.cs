using MutateThem.GUI;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.Scenes
{
    class NextWave
    {
        string stopmessage = "Start New WAVE";
        string buttonname = "[SPACE]";
        int size = (int)(80 * Window.multyplier.Y);

        public bool ispaused = false;

        public NextWave()
        {

        }

        public void Play()
        {
            if (!ispaused) return;
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                ispaused = false;
            }
        }
        public void Work()
        {

        }
        public void Draw()
        {
            if (!ispaused) return;
            Raylib.DrawRectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetRenderHeight(), Window.focus);

            Vector2 loc = new Vector2(Raylib.GetScreenWidth() / 2 - (Raylib.MeasureText(stopmessage, size) / 2), Raylib.GetRenderHeight() / 2 - size / 2.3f);
            Raylib.DrawText(stopmessage, (int)loc.X, (int)loc.Y, size, Window.agedwhite);

            loc = new Vector2(Raylib.GetScreenWidth() / 2 - (Raylib.MeasureText(buttonname, size) / 2), Raylib.GetRenderHeight() / 2 - size / 2.3f);
            Raylib.DrawText(buttonname, (int)loc.X, (int)(loc.Y + 80 * Window.multyplier.Y), size + 10, Window.agedblue);
        }
    }
}
