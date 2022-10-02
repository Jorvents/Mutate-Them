using MutateThem.Some_things.Me;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using MutateThem.Some_things.notPlayer;
using static MutateThem.Game.Keybindings;
using static Raylib_cs.KeyboardKey;

namespace MutateThem;

class Game
{
    public enum Keybindings
    {
        Press1,
        Press2,
        Press3,
        Scatter1,
        Scatter50,
        Scatter5k
    }

    public static Player player = new();

    public static List<Mutable> mutables = new(); 

    //Enemy enemy;
    public static List<Enemy> enemies;

    //static public Enemy[] enemiess { get; set; }
    public static List<Ally> allies;
    //static public Ally[] alliess { get; set; }

    //public Ally[] allies;
    //public Ally alli;
    public static int lastPressed3;

    // dictionary is a hashmap
    public static Dictionary<Keybindings, KeyboardKey> keybindings = new()
    {
        { Press1, KEY_ONE }, { Press2, KEY_TWO }, { Press3, KEY_THREE }, { Scatter1, KEY_K }, { Scatter50, KEY_O },
        { Scatter5k, KEY_L }
    };
    public DebugController statsController = new();
    public Game()
    {
        //Console.WriteLine(Directory.GetCurrentDirectory());
        //this.enemy = enemy;
        //alli = new Ally();
        allies = new List<Ally>();
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
        var angle = Angle(player.loc, Raylib.GetMouseX(), Raylib.GetMouseY());
        player.handRotation = angle + 135;
        var thisPower = player.handpowers;
        thisPower.rotateIn = toVector(angle - 180) * thisPower.disctance;

        player.Work();
        mutables.RemoveAll(m =>
        {
            m.Work();
            return m.IsDead;
        });
        enemies.RemoveAll(e => //TEMPORARY
        {
            //e.Work();
            return e.IsDead;
        });
        /*
        allies.RemoveAll(a =>
        {
            a.Work();
            return a.IsDead;
        });
        //*/
    }

    void Draw()
    {
        Raylib.DrawText(Raylib.GetFPS().ToString(), 15, 15, 30, Color.WHITE);
        //statsController.stats.
        //statsController.Draw();
        Raylib.DrawText(lastPressed3.ToString(), 15, 45, 30, Color.WHITE);
        Raylib.DrawText(mutables.Count.ToString(), 15, 135, 30, Color.WHITE);

        //Raylib.DrawLine((int)player.loc.X, (int)player.loc.Y, Raylib.GetMouseX(), Raylib.GetMouseY(), Color.YELLOW);
        mutables.ForEach(m => m.Draw());
        //enemies.ForEach(e => e.Draw());
        //allies.ForEach(a => a.Draw());
        player.Draw();
    }
    public void Reset() //Temporary for testing
    {
        lastPressed3 = 0;
        mutables.Clear();
        player.isActive = false;
        player.handpowers.isActive = true;
        mutables.Add(new Ally(new(100)));
        /*
        if (allies.Count == 0)
        {
            allies.Add(new Ally(new Vector2(100, 100)));
        }
        for (int i = 0; i < allies.Count; i++)
        {
            allies[i] = new Ally(new Vector2(100, 100));
            //ALL ON TOP
        }
        */
    }
    public static void ScatterThem(int count)
    {
        //count++;
        //enemies = new Enemy[count];
        enemies = new List<Enemy>();
        var rndm = new Random();

        for (var i = 0; i < count; i++)
        {
            //if (i == 0) return;
            //enemies[i].loc = new Vector();
            Vector2 loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
            Enemy adding = new Enemy(player, loc/*,i*/);
            adding.whichOne = i;
            enemies.Add(adding);
            mutables.Add(adding);
        }
    }

    public float Angle(Vector2 first, int secondX, int secondY)
    {
        double angleD;
        angleD = Math.Atan2(first.Y - secondY, first.X - secondX);
        angleD = 180f / Math.PI * angleD;

        //Math.Atan2;
        //Math.Tau;
        //angleD = -angleD;
        return (float) angleD;
    }

    public Vector2 toVector(float angle)
    {
        double angleD = angle / (180 / Math.PI);
        return new Vector2((float) Math.Cos(angleD), (float) Math.Sin(angleD));
    }

    

    //NOT USED METHODS
    public static long GetTimeMs() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    
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

    public static void AddAlly( /*Vector2 location*/)
    {
        /*
        int amountAllies = allies.Length;
        allies = new Ally[amountAllies++];
        allies[amountAllies] = new Ally();
        */
    }

    public bool Touches(Vector2 loc1, int radius1, Vector2 loc2, int radius2)
    {
        return Raylib.CheckCollisionCircles(loc1, radius1, loc2, radius2);
    }

    public float Hypotenus()
    {
        return 0.0f;
    }
}