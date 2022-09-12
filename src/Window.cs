using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MutateThem.Some_things.Me;
using Raylib_cs;

namespace MutateThem
{
    class Window
    {
        public void Run()
        {

            Raylib.InitWindow(1280, 720, "Mutate them!");

            Image icon = Raylib.LoadImage("Files/Sprites/Icon.png");

            Raylib.SetWindowIcon(icon);

            Raylib.SetTargetFPS(162);

            Player player = new Player();

            Game game = new Game(player);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                game.justRun();
                Raylib.EndDrawing();

            }
            Raylib.UnloadImage(icon);
            Raylib.UnloadTexture(player.playerHands);

            Raylib.CloseWindow();
        }
    }
}
