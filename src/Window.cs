using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MutateThem.Some_things;
using Raylib_cs;

namespace MutateThem
{
    class Window
    {
        public void Run()
        {
            Raylib.InitWindow(1280, 720, "Hello World");

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
            Raylib.UnloadTexture(player.playerHands);

            Raylib.CloseWindow();
        }
    }
}
