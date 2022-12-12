using MutateThem.Some_things.Me;
using Raylib_cs;
using System.Numerics;

namespace MutateThem.Scenes
{
    class SceneController
    {
        string title;

        public Start start;

        Game game = new();
        Dead dead = new();
        QuitButton quitButton = new();
        Pause pause = new();
        NextWave nextwave = new();

        public Texture2D backround;
        Vector2 multyplier = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()) / new Vector2(1920, 1080);
        Color wallcolour = Color.WHITE;

        public enum Scene
        {
            Start,
            Game,
            Dead
        }
        public static Scene scene;

        public SceneController(string title)
        {
            //scene = Scene.Game;
            this.title = title;
            start = new Start(title);
            backround = Raylib.LoadTexture("Files/Sprites/backround.png");
        }

        public void JustPlay()
        {
            if (Raylib.IsWindowFocused()) //BORDELESS WINDOW??
            {
                Raylib.SetWindowState(ConfigFlags.FLAG_FULLSCREEN_MODE);
            }
            else if (Raylib.IsWindowFullscreen())
            {
                Raylib.ToggleFullscreen();
                if (scene == Scene.Game)
                {
                    pause.ispaused = true;
                }
            }

            if (start.gamestared)
            {
                scene = Scene.Game;
            }

            if (Game.player.isDead)
            {
                scene = Scene.Dead;
            }
            
            if (dead.again && scene == Scene.Dead)
            {
                dead.again = false;
                game = new();
                scene = Scene.Start;
            }

            if (pause.restart && scene == Scene.Game)
            {
                pause.ispaused = false;
                game = new();
                //scene = Scene.Start;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                nextwave.ispaused = false;
            }

            Raylib.DrawTextureEx(backround, new Vector2(), 0f, multyplier.Y, wallcolour);

            Play();
            Work();
            Draw();

        }

        void Play()
        {
            switch (scene)
            {
                case (Scene)0:
                    start.Play();
                    break;

                case (Scene)1:
                    pause.Play();
                    if (pause.ispaused && !Game.player.isDying)
                    {
                        break;
                    }
                    game.Play();
                    break;

                case (Scene)2:
                    dead.Play();
                    break;
            }

            nextwave.Play();
        }
        void Work()
        {
            switch (scene)
            {
                case (Scene)0:
                    start.Work();
                    break;

                case (Scene)1:
                    if (pause.ispaused && !Game.player.isDying || game.nextwave || nextwave.ispaused)
                    {
                        if (game.nextwave)
                        {
                            nextwave.ispaused = true;
                        }
                        game.nextwave = false;
                        if (nextwave.ispaused && !pause.ispaused)
                        {
                            Game.player.handRotation = Game.player.Angle(Game.player.loc, Raylib.GetMouseX(), Raylib.GetMouseY()) + 135.5f;
                            Game.player.isActive = false;
                        }
                        break;
                    } 
                    if (Game.player.isDying && pause.ispaused)
                    {
                        pause.ispaused = false;
                    }
                    game.Work();
                    break;

                case (Scene)2:
                    dead.Work();
                    break;
            }

            nextwave.Work();
            pause.Work();
        }
        void Draw()
        {
            switch (scene)
            {
                case (Scene)0:
                    start.Draw();
                    break;

                case (Scene)1:
                    game.Draw();
                    break;

                case (Scene)2:
                    dead.Draw();
                    break;
            }

            nextwave.Draw();
            pause.Draw();
        }
    }
}
