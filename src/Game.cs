using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MutateThem.Some_things;
using Raylib_cs;

namespace MutateThem
{
    class Game
    {
        public void Run()
        {
            Raylib.InitWindow(800, 480, "Hello World");

            Raylib.SetTargetFPS(162);

            Player player = new Player();
            Enemy enemy = new Enemy(player);
            while (!Raylib.WindowShouldClose())
            {
                player.Work();
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                //Player player = new Player();
                enemy.Draw();
                player.Draw();
                //player.Draw();
                //Raylib.DrawText("Hello, world!", 12, 12, 20, Color.WHITE);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
