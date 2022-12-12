using System.Numerics;
using Raylib_cs;
using MutateThem.Scenes;

namespace MutateThem;

class Window
{
    public string name = "Mutate them!";

    public static Color backround = new Color(24, 24, 15, 255);

    public static Color agedwhite = new Color(255, 247, 224, 255);
    public static Color agedblue = new Color(224, 239, 255, 255);

    public static Color focus = new Color(0,0,0,100);

    public static Vector2 OgWindowSize = new(1280, 720);

    public static Vector2 multyplier = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()) / OgWindowSize;

    public static bool quit;

    public void Run()
    {
        Raylib.InitWindow(Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), name);

        var icon = Raylib.LoadImage("Files/Sprites/Icon.png");

        Raylib.SetWindowIcon(icon);
        Raylib.SetTargetFPS(Raylib.GetMonitorRefreshRate(Raylib.GetCurrentMonitor()));

        Raylib.SetExitKey(KeyboardKey.KEY_NULL);

        SceneController controller = new SceneController(name);

        while (!quit)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(backround);
            controller.JustPlay();
            Raylib.EndDrawing();
        }

        Raylib.UnloadImage(icon);
        Raylib.UnloadTexture(controller.backround);
        Raylib.UnloadTexture(Game.player.playerHands);
        Raylib.UnloadTexture(Game.selected.selected);
        Raylib.UnloadTexture(Game.selected.unselected);
        Raylib.UnloadShader(Game.glow);

        Raylib.CloseWindow();
    }
}