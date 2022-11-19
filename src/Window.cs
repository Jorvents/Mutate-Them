using System.Numerics;
using Raylib_cs;
using System;

namespace MutateThem;

class Window
{
    public static Vector2 OgWindowSize = new(1280,720);

    public static Color backround = Color.BLACK;

    public static Vector2 multyplier = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()) / OgWindowSize;
    
    public void Run()
    {
        Raylib.InitWindow(Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), "Mutate them!");

        var icon = Raylib.LoadImage("Files/Sprites/Icon.png");

        Raylib.SetWindowIcon(icon);
        Raylib.SetTargetFPS(162);

        //Raylib.SetWindowState(ConfigFlags.FLAG_FULLSCREEN_MODE);

        Game game = new();

        //var start = Game.GetTimeMs();
        
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(backround);
            game.JustRun();
            //Raylib.DrawText($"{(Game.GetTimeMs() - start)/1000f}s", 500, 12, 32, Color.BLUE);
            Raylib.EndDrawing();
        }
        Raylib.UnloadImage(icon);
        Raylib.UnloadTexture(Game.player.playerHands);
        Raylib.UnloadTexture(Game.selected.selected);
        Raylib.UnloadTexture(Game.selected.unselected);
        Raylib.UnloadShader(Game.glow);
        Raylib.CloseWindow();
    }
}