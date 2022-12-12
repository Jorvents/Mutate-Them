using MutateThem.Some_things.Me;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using MutateThem.Some_things.notPlayer;
using static MutateThem.Scenes.Game.Keybindings;
using static Raylib_cs.KeyboardKey;
using MutateThem.GUI;

namespace MutateThem.Scenes
{
    class Game
    {
        public enum Keybindings
        {
            Press0,
            Press1,
            Press2,
            Press3,
            Press4,
            Press5,
            Scatter1,
            Scatter50,
            Scatter5k,
            ResetWave,
            ToggleShader
        }

        public static Player player = new();

        Vector2 playerhealth = new(20, 20000);

        int normalhealth; //DEBUG

        public static MutablesController mutablescontroller = new();

        public static List<Mutable> mutables = new();

        public static List<Enemy> enemies;

        public static int wave;

        public static Rectangle[] borders = new Rectangle[4];

        public static sbyte lastPressed3;
        //public List<bool> avelible;

        public static Selected selected = new();
        public static Health health = new();
        EnemyCountre enemyCountre = new();

        public bool nextwave = false;

        public static long start = GetTimeMs();

        public static RenderTexture2D target = Raylib.LoadRenderTexture(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());




        public static Shader glow = Raylib.LoadShader(null, "Files/Shaders/glow.frag");

        public bool ShaderOn = false;

        // dictionary is a hashmap
        public static Dictionary<Keybindings, KeyboardKey> keybindings = new()
        {
            { Press0, KEY_ONE }, { Press1, KEY_TWO }, { Press2, KEY_THREE }, { Press3, KEY_FOUR }, { Press4, KEY_FIVE }, { Press5, KEY_SIX }, { Scatter1, KEY_K }, { Scatter50, KEY_O },
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
                case Press5:
                    lastPressed3 = 5;
                    break;
                    /*
                case Scatter1:
                    Reset();
                    ScatterThem(1);
                    player.health = 1;
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
                    */
                case ToggleShader:
                    ShaderOn = !ShaderOn;
                    break;
            }
        }
        public Game()
        {

            //BORDERS

            player = new();
            int borderThicness = 50;
            borders[0] = new Rectangle(0, -borderThicness, Raylib.GetScreenWidth(), borderThicness);         //N
            borders[1] = new Rectangle(0, Raylib.GetScreenHeight(), Raylib.GetScreenWidth(), borderThicness);//S
            borders[2] = new Rectangle(Raylib.GetScreenWidth(), 0, borderThicness, Raylib.GetScreenHeight());//E
            borders[3] = new Rectangle(-borderThicness, 0, borderThicness, Raylib.GetScreenHeight());        //W

            wave = 0;

            wave++;
            lastPressed3 = 0;

            Reset();
            normalhealth = (int)playerhealth.X;
            WaveReset();
        }

        public void JustRun() // VERY IMPORTANT
        {
            Play();
            Work();
            Draw();
        }

        public void Play()
        {
            foreach (var (key, value) in keybindings)
            {
                if (Raylib.IsKeyPressed(value)) KeyPressed(key);
            }
            if (Raylib.GetMouseWheelMoveV().Y == -1)
            {
                lastPressed3++;
            }
            if (Raylib.GetMouseWheelMoveV().Y == 1)
            {
                lastPressed3--;
            }
            //INFINATE SCROLL
            if (lastPressed3 > selected.mutablesCounter - 1)
            {
                lastPressed3 = (sbyte)(selected.mutablesCounter - 1);
            }
            if (lastPressed3 < 0)
            {
                lastPressed3 = 0;
            }
        }
        public void Work()
        {
            if (enemies.Count == 0)
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
            mutablescontroller.Work();
            if (player.isDying)
            {
                mutables.ForEach(m => m.Die());
            }
            
            player.Work();
            selected.Work();

            health.Work();
            if (player.health < playerhealth.X + 1)
            {
                normalhealth = player.health;
            }
        }
        public void Draw()
        {
            mutables.ForEach(m => m.Draw());
            mutablescontroller.Draw();
            player.Draw();

            //Raylib.DrawFPS(15, 15);

            //Raylib.DrawText(Raylib.IsGamepadAvailable(0).ToString(), 15, 345, 30, Color.WHITE);
            selected.Draw();     //UI
            health.Draw();       //UI
            enemyCountre.Draw(); //UI

            Raylib.DrawText(wave.ToString(), Raylib.GetScreenWidth() / 2 - Raylib.MeasureText(wave.ToString(), (int)(100 * Window.multyplier.Y)) / 2, 20, (int)(100 * Window.multyplier.Y), Window.agedwhite);
        }

        public void Reset()
        {
            lastPressed3 = 0;
            mutables.Clear();
            player.health = player.maxhealth;
            player.isActive = false;
            player.handpowers.isActive = true;
            player.maxhealth = (int)playerhealth.Y;
            player.health = (int)playerhealth.Y;
            health = new();
            selected.Reset();
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

            if (wave > 1)
            {
                nextwave = true;
            }
        }

        public void ScatterThem(int count)
        {
            enemies = new List<Enemy>();
            var rndm = new Random();

            for (var i = 0; i < count; i++)
            {
                Vector2 loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
                while (DistanceTo(loc, player.loc) > 400 + (wave * 6 * Window.multyplier.Y) * Window.multyplier.Y || DistanceTo(loc, player.loc) < 150 * Window.multyplier.Y)
                {
                    loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
                }
                Enemy adding = new Enemy(player, loc);
                enemies.Add(adding);
                mutables.Add(adding);
            }
        }

        public float DistanceTo(Vector2 vec, Vector2 loc)
        {
            double dx = loc.X - vec.X; //calculate the diffrence in x-coordinate
            double dy = loc.Y - vec.Y; //calculate the diffrence in y-coordinate
            return (float)Math.Sqrt(dx * dx + dy * dy); //use the distance formula to find the difference
        }

        public static long GetTimeMs() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}