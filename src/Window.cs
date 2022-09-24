using System.Numerics;
using Raylib_cs;

namespace MutateThem;

class Window
{
    public static Vector2 WindowSize = new(1280, 720);
    
    public void Run()
    {
        Raylib.InitWindow((int) WindowSize.X, (int) WindowSize.Y, "Mutate them!");

        var icon = Raylib.LoadImage("Files/Sprites/Icon.png");

        Raylib.SetWindowIcon(icon);
        Raylib.SetTargetFPS(162);

        Game game = new();

        var start = Game.GetTimeMs();
        
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            game.JustRun();
            Raylib.DrawText($"{(Game.GetTimeMs() - start)/1000f}s", 500, 12, 32, Color.BLUE);
            Raylib.EndDrawing();
        }

        Raylib.UnloadImage(icon);
        Raylib.UnloadTexture(Game.player.playerHands);
        Raylib.CloseWindow();
    }
}