using MutateThem.Some_things.Me;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using MutateThem.Some_things.notPlayer;
using static MutateThem.Game.Keybindings;
using static Raylib_cs.KeyboardKey;
using MutateThem.GUI;

namespace MutateThem;

class Game
{
    public enum Keybindings
    {
        Press0,
        Press1,
        Press2,
        Press3,
        Scatter1,
        Scatter50,
        Scatter5k
    }

    public static Player player = new();
    
    public static List<Mutable> mutables = new();

    public static List<Enemy> enemies;

    public static int wave;

    public static int lastPressed3;

    public static Selected selected = new();
    Health health = new();

    //public Button button = new();

    static bool quitting = false;

    public static long start = GetTimeMs();

    // dictionary is a hashmap
    public static Dictionary<Keybindings, KeyboardKey> keybindings = new()
    {
        { Press0, KEY_ONE }, { Press1, KEY_TWO }, { Press2, KEY_THREE }, { Press3, KEY_FOUR }, { Scatter1, KEY_K }, { Scatter50, KEY_O },
        { Scatter5k, KEY_L }
    };
    public DebugController statsController = new();
    public Game()
    {
        //Console.WriteLine(Directory.GetCurrentDirectory());
        //this.enemy = enemy;
        //alli = new Ally();
        //allies = new List<Ally>();
        //allies[0] = new Ally();
        //allies.Add(new Ally(new Vector2(100, 100)));
        Reset();
        ScatterThem(50);
        lastPressed3 = 0;
    }

    public void JustRun() // VERY IMPORTANT
    {
        Play();
        Work();
        Draw();
    }

    void Play()
    {
        player.handpowers.leftclicked = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT);
        player.handpowers.rightclicked = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT);

        // change keybinding example (for later)
        // keybindings[Press2] = KEY_B

        foreach (var (key, value) in keybindings)
        {
            if (Raylib.IsKeyPressed(value)) KeyPressed(key);
        }
    }

    void KeyPressed(Keybindings keybinding)
    {
        switch (keybinding)
        {
            case Press0:
                lastPressed3 = 0;
                break;
            case Press1:
                lastPressed3 = 1;
                break;
            case Press2:
                lastPressed3 = 2;
                break;
            case Press3:
                lastPressed3 = 3;
                break;
            case Scatter1:
                Reset();
                ScatterThem(1);
                break;
            case Scatter50:
                Reset();
                ScatterThem(50);
                break;
            case Scatter5k:
                Reset();
                ScatterThem(5000);
                break;
        }
    }

    void Work()
    {
        mutables.RemoveAll(m =>
        {
            m.Work();
            return m.isDead;
        });
        enemies.RemoveAll(e => //TEMPORARY
        {
            //e.Work();
            return e.isDead;
        });
        player.Work();
        selected.Work();
        health.Work();
    }

    void Draw()
    {
        if (quitting) return;
        Raylib.DrawFPS(15, 15);
        Raylib.DrawText(mutables.Count.ToString(), 15, 135, 30, Color.WHITE);
        //Raylib.DrawText(statues.Count.ToString(), 15, 345, 30, Color.WHITE);
        Raylib.DrawText($"{(GetTimeMs() - start) / 1000f}s", 200, 22, 32, Color.BLUE);
        mutables.ForEach(m => m.Draw());
        player.Draw();
        selected.Draw(); //UI
        health.Draw();   //UI
        Raylib.DrawText(wave.ToString(), Raylib.GetScreenWidth() / 2 - 50, 20, 100, Color.WHITE);
        //Raylib.DrawText(player.loc.ToString(), 15, 165, 30, Color.WHITE);
    }
    public void Reset() //Temporary for testing
    {
        lastPressed3 = 0;
        mutables.Clear();
        player.health = player.maxhealth;
        player.isActive = false;
        player.handpowers.isActive = true;
        Selected.Reset();
    }
    public static void ScatterThem(int count)
    {
        enemies = new List<Enemy>();
        var rndm = new Random();

        for (var i = 0; i < count; i++)
        {
            Vector2 loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
            Enemy adding = new Enemy(player, loc/*,i*/);
            adding.whichOne = i;
            enemies.Add(adding);
            mutables.Add(adding);
        }
    }
    public static void Quit()
    {
        quitting = true;
        Raylib.CloseWindow();

    }
    public static long GetTimeMs() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    //NOT USED METHODS
    public static bool Timer(int time) // NOT DONE
    {
        var currentTime = Environment.TickCount;
        var yesno = false;
        for (var i = 0; time > currentTime; i++)
        {
            return yesno;
        }

        return yesno;
    }
}