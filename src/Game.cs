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
            Raylib.InitWindow(1280, 720, "Hello World");

            Raylib.SetTargetFPS(162);

            Player player = new Player();
            Enemy enemy = new Enemy(player);
            while (!Raylib.WindowShouldClose())
            {
                /*
                VrStereoConfig VRconfig = new VrStereoConfig();
                VRconfig.projection1.M23 = 10;
                VRconfig.projection2.M23 = 20;
                VRconfig.leftLensCenter.X = 30;
                VRconfig.rightLensCenter.X = 40;

                Raylib.BeginVrStereoMode(VRconfig);
                */
                player.Work();
                enemy.Work();
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_K))
                {
                    enemy.ScatterThem(15);
                }
                /*
                Raylib.DrawText(enemy.directionX.ToString(), 12, 10, 30, Color.WHITE);
                Raylib.DrawText(enemy.directionY.ToString(), 12, 40, 30, Color.WHITE);
                Raylib.DrawText(enemy.farness.X.ToString(), 12, Raylib.GetScreenHeight() - 70, 30, Color.WHITE);
                Raylib.DrawText(enemy.farness.Y.ToString(), 12, Raylib.GetScreenHeight() - 30, 30, Color.WHITE);
                */
                //Player player = new Player();
                enemy.Draw();
                player.Draw();
                //Raylib.DrawText(Raylib.GetFPS().ToString(), 12, 12, 20, Color.WHITE);
                //player.Draw();
                //Raylib.DrawText("Hello, world!", 12, 12, 20, Color.WHITE);
                //Raylib.EndVrStereoMode();
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
