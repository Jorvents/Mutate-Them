using MutateThem.GUI;
using Raylib_cs;
using System.Numerics;

namespace MutateThem.Scenes
{
    class Dead
    {
        string deathmessage = "you dead";
        string wavemessage = "Final wave: ";
        int size = (int)(260 * Window.multyplier.Y);
        int downwards = (int)(200 * Window.multyplier.Y);

        int upwards = (int)(260 * Window.multyplier.Y);
        int wavesize = (int)(90 * Window.multyplier.Y);

        Button button;
        public bool again;

        public Dead()
        {
            button = new Button(new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2 + downwards), new Vector2(300, 140), "RETRY", 60);
        }

        public void JustRun()
        {
            Play();
            Work();
            Draw();
        }

        public void Play()
        {
            again = button.isPressed;
        }
        public void Work()
        {
            button.Work();
        }
        public void Draw()
        {
            Raylib.DrawText(wavemessage + Game.wave.ToString(), (Raylib.GetScreenWidth() / 2) - Raylib.MeasureText(wavemessage + Game.wave.ToString(), wavesize / 2), Raylib.GetScreenHeight() / 2 - upwards, wavesize, Window.agedblue);

            Raylib.DrawText(deathmessage, (Raylib.GetScreenWidth() / 2) - (Raylib.MeasureText(deathmessage, size) / 2), Raylib.GetScreenHeight() / 2 - (int)(size / 2.3f), size, Window.agedwhite);

            button.Draw();
        }
    }
}
