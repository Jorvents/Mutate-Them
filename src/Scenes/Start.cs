using MutateThem.GUI;
using Raylib_cs;
using System;
using System.Numerics;

namespace MutateThem.Scenes
{
    class Start
    {
        string title;
        float size = 140 * Window.multyplier.Y;
        float spacing = 10;
        float rotation = 0;
        int downwards = 210;
        float rightwards = 50 * Window.multyplier.Y;

        Button button = new Button(new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2 + (160 * Window.multyplier.Y)), new Vector2(450, 180), "PLAY", 130);

        public bool gamestared;
        public Start(string title)
        {
            this.title = title;
        }
        public void JustRun()
        {
            Play();
            Work();
            Draw();
        }

        public void Play()
        {
            gamestared = button.isPressed;
        }
        public void Work()
        {
            button.Work();
        }
        public void Draw()
        {
            Raylib.DrawTextPro(Raylib.GetFontDefault(), title, new Vector2(Raylib.GetScreenWidth() / 2 + rightwards, downwards * Window.multyplier.Y), new Vector2(Raylib.MeasureText(title, (int)size) / 2, size / 2), rotation, size, spacing, Window.agedblue);
            button.Draw();
        }
    }
}
