using MutateThem.Some_things.Me;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using MutateThem.Some_things.notPlayer;
using static MutateThem.Game.Keybindings;
using static Raylib_cs.KeyboardKey;
using MutateThem.GUI;
using System.ComponentModel;
using System.Runtime;

namespace MutateThem;

class Game
{
    public enum Keybindings
    {
        Press0,
        Press1,
        Press2,
        Press3,
        Press4,
        Scatter1,
        Scatter50,
        Scatter5k,
        ResetWave,
        ToggleShader
    }

    public static Player player = new();

    Vector2 playerhealth = new(20,20000);

    int normalhealth;
    
    public static List<Mutable> mutables = new();

    public static List<Enemy> enemies;

    public static int wave;

    public static Rectangle[] borders = new Rectangle[4];

    public static int lastPressed3;

    public static Selected selected = new();
    Health health = new();

    //public Button button = new();

    static bool quitting = false;

    public static long start = GetTimeMs();

    public static RenderTexture2D target = Raylib.LoadRenderTexture(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()); //FOR SHADER

    //Shader glow = Raylib.LoadShader(string.Format("Files/Shaders/glow.vert", 330), string.Format("Files/Shaders/glow.frag", 330));

    //const int GLSL_VERSION = 330;

    public static Shader glow = Raylib.LoadShader(null, "Files/Shaders/glow.frag");

    bool ShaderOn = false;

    /*
    float time = 0.0f;
    int timeLoc = GetShaderLocation(shader, "uTime");
    Raylib.SetShaderValue(shader, timeLoc, time, SHADER_UNIFORM_FLOAT);
    */
    // dictionary is a hashmap
    public static Dictionary<Keybindings, KeyboardKey> keybindings = new()
    {
        { Press0, KEY_ONE }, { Press1, KEY_TWO }, { Press2, KEY_THREE }, { Press3, KEY_FOUR }, { Press4, KEY_FIVE }, { Scatter1, KEY_K }, { Scatter50, KEY_O },
        { Scatter5k, KEY_L },{ ResetWave, KEY_P}, { ToggleShader, KEY_Z }
    };

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
            case Press4:
                lastPressed3 = 4;
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
            case ResetWave:
                WaveReset();
                break;
            case ToggleShader:
                ShaderOn = !ShaderOn;
                break;
        }
    }

    public DebugController statsController = new();
    public Game()
    {
        //Console.WriteLine(Directory.GetCurrentDirectory());
        //this.enemy = enemy;
        //alli = new Ally();
        //allies = new List<Ally>();
        //allies[0] = new Ally();
        //allies.Add(new Ally(new Vector2(100, 100)));

        //BORDERS
        int borderThicness = 50;
        borders[0] = new Rectangle(0, -borderThicness, Raylib.GetScreenWidth(), borderThicness);         //N
        borders[1] = new Rectangle(0, Raylib.GetScreenHeight(), Raylib.GetScreenWidth(), borderThicness);//S
        borders[2] = new Rectangle(Raylib.GetScreenWidth(), 0, borderThicness, Raylib.GetScreenHeight());//E
        borders[3] = new Rectangle(-borderThicness, 0, borderThicness, Raylib.GetScreenHeight());        //W
        wave++;
        //Reset();
        //ScatterThem(50);
        lastPressed3 = 0;

        normalhealth = (int)playerhealth.X;
        WaveReset();
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
        //if (Raylib.GetKeyPressed)
    }

    void Work()
    {
        if (Raylib.IsWindowFocused()) //BORDELESS WINDOW??
        {
            Raylib.SetWindowState(ConfigFlags.FLAG_FULLSCREEN_MODE);
        } else if (Raylib.IsWindowFullscreen())
        {
            Raylib.ToggleFullscreen();
        }

        if (enemies.Count == 0 && player.handpowers.isActive)
        {
            wave++;
            WaveReset();
        }

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
        if (player.health < playerhealth.X + 1)
        {
            normalhealth = player.health;
        }
    }

    void Draw()
    {
        if (quitting) return;
        

        
        Raylib.BeginTextureMode(target);
        //MAKE IT GLOW
        Raylib.ClearBackground(Window.backround);
        mutables.ForEach(m => m.Draw());
        player.Draw();
        Raylib.EndTextureMode();


        if (ShaderOn)
        {
            Raylib.BeginShaderMode(glow);
        }
        // NOTE: Render texture must be y-flipped due to default OpenGL coordinates (left-bottom)
        Raylib.DrawTextureRec(target.texture, new Rectangle(0,0, target.texture.width, -target.texture.height), new Vector2(0,0), Color.WHITE);
        Raylib.EndShaderMode();

        Raylib.DrawFPS(15, 15);

        //Raylib.DrawText(mutables.Count.ToString(), 15, 135, 30, Color.WHITE);
        //Raylib.DrawText(statues.Count.ToString(), 15, 345, 30, Color.WHITE);
        //Raylib.DrawText($"{(GetTimeMs() - start) / 1000f}s", 200, 22, 32, Color.BLUE);

        selected.Draw(); //UI
        health.Draw();   //UI

        Raylib.DrawText(wave.ToString(), (Raylib.GetScreenWidth() / 2) - (Raylib.MeasureText(wave.ToString(), (int)(100 * Window.multyplier.Y))) / 2, 20, (int)(100 * Window.multyplier.Y), Color.WHITE);

        Raylib.DrawText(Window.multyplier.ToString(), 15, 135, 30, Color.WHITE);
        //Raylib.DrawText(player.loc.ToString(), 15, 165, 30, Color.WHITE);
        /*
        switch (gamemode)
        {
            case 0:
            DrawStart
            break;
            case 1:
            Draw Main game
            break;
            case 2:
            Draw Death screen
            break;
        }
        if (DrawUI) 
        {
            
        }
        */
    }

    public void Reset() //Temporary for testing
    {
        lastPressed3 = 0;
        mutables.Clear();
        player.health = player.maxhealth;
        player.isActive = false;
        player.handpowers.isActive = true;
        player.maxhealth = (int)playerhealth.Y;
        player.health = (int)playerhealth.Y;
        health = new();
        Selected.Reset();
    }
    public void WaveReset()
    {
        mutables.Clear();
        player.isActive = false;
        player.handpowers.isActive = true;
        player.maxhealth = (int)playerhealth.X;
        player.health = normalhealth;
        health = new();
        ScatterThem((int)Math.Round(wave * 2.3f));
    }

    public void ScatterThem(int count)
    {
        enemies = new List<Enemy>();
        var rndm = new Random();

        for (var i = 0; i < count; i++)
        {
            Vector2 loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
            while (DistanceTo(loc, player.loc) > 400 * Window.multyplier.Y || DistanceTo(loc, player.loc) < 150 * Window.multyplier.Y)
            {
                loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
            }
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
    public float DistanceTo(Vector2 vec, Vector2 loc)
    {
        double dx = loc.X - vec.X; //calculate the diffrence in x-coordinate
        double dy = loc.Y - vec.Y; //calculate the diffrence in y-coordinate
        return (float)Math.Sqrt(dx * dx + dy * dy); //use the distance formula to find the difference
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