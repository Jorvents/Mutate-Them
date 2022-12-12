using MutateThem.GUI;
using Raylib_cs;
using System.Numerics;

namespace MutateThem.Scenes
{
    class QuitButton
    {
        float spacing = 80 * Window.multyplier.Y;
        Button button;

        public QuitButton(Rectangle box)
        {
            button = new Button(new Vector2(box.width / 2 + box.x, box.height + box.y - 53 * Window.multyplier.Y), new Vector2(200, 70), "QUIT", 30);
        }
        public QuitButton()
        {
            button = new Button(new Vector2(Raylib.GetScreenWidth() - spacing, Raylib.GetScreenHeight() - spacing), new Vector2(100, 70), "QUIT", 30);
        }
        public void JustRun()
        {
            Play();
            Work();
            Draw();
        }

        public void Play()
        {
            if (button.isPressed)
            {
                Window.quit = true;
            }
        }
        public void Work()
        {
            button.Work();
        }
        public void Draw()
        {
            button.Draw();
        }
    }
}
