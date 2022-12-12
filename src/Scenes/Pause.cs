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
    class Pause
    {
        string pausemessage = "game paused";
        int size = (int)(40 * Window.multyplier.Y);
        float downwards = 10 * Window.multyplier.Y;

        public bool ispaused = false;
        public Vector2 boxsize = new Vector2(270, 340) * Window.multyplier.Y;
        Rectangle box;

        QuitButton quitButton;
        Button restartButton;
        Button resumeButton;

        public bool restart;

        public Pause()
        {
            box = new Rectangle(Raylib.GetScreenWidth() / 2 - boxsize.X / 2, Raylib.GetScreenHeight() / 2 - boxsize.Y / 2, boxsize.X, boxsize.Y);
            quitButton = new(box);
            restartButton = new Button(new Vector2(box.width / 2 + box.x, box.height + box.y - 147 * Window.multyplier.Y), new Vector2(200, 70), "RESTART", 30);
            resumeButton = new Button(new Vector2(box.width / 2 + box.x, box.height + box.y - 240 * Window.multyplier.Y), new Vector2(200, 70), "RESUME", 30);
        }

        public void Play()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            {
                ispaused = !ispaused;
            }

            restart = restartButton.isPressed;
            
            quitButton.Play();
        }
        public void Work()
        {
            if (!ispaused) return;

            quitButton.Work();
            restartButton.Work();
            resumeButton.Work();

            if (resumeButton.isPressed)
            {
                ispaused = false;
            }
        }
        public void Draw()
        {
            if (!ispaused) return;

            Raylib.DrawRectangle(0,0, Raylib.GetScreenWidth(), Raylib.GetRenderHeight(), Window.focus);
            Raylib.DrawRectangleRec(box, Window.backround);
            Raylib.DrawRectangleLinesEx(box, 8f, Window.agedwhite);

            Raylib.DrawText(pausemessage, (int)(box.x + box.width / 2 - (Raylib.MeasureText(pausemessage, size) / 2)), (int)(box.y + downwards), size, Window.agedblue);

            quitButton.Draw();
            restartButton.Draw();
            resumeButton.Draw();

        }
    }
}
