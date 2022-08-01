using System;
using Raylib_cs;

namespace MutateThem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 480, "Hello World");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                Raylib.DrawText("Hello, world!", 12, 12, 20, Color.WHITE);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
