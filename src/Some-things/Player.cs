using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace MutateThem.Some_things
{
    public class Player : Something
    {
        public bool IsPlaying { get; set; }
        public Player()
        {
            loc = new Vector2();
            /*
            loc = new Vector2[1];
            loc[0] = new(Raylib.GetScreenWidth() / 2.0f, Raylib.GetScreenHeight() / 2.0f);
            */
            loc = new(Raylib.GetScreenWidth() / 2.0f, Raylib.GetScreenHeight() / 2.0f);
            IsPlaying = false;
            radius = 40;
            colour = Color.SKYBLUE;
        }
        public void Work()
        {
            int x = (Raylib.IsKeyDown(KeyboardKey.KEY_A) ? -1 : 0) + (Raylib.IsKeyDown(KeyboardKey.KEY_D) ? 1 : 0);
            int y = (Raylib.IsKeyDown(KeyboardKey.KEY_W) ? -1 : 0) + (Raylib.IsKeyDown(KeyboardKey.KEY_S) ? 1 : 0);
            Vector2 input = new(x, y);
            if (input != Vector2.Zero)
            {
                IsPlaying = true;
                input = Vector2.Normalize(input);
            }

            //loc[0] += input * 300 * Raylib.GetFrameTime();
            loc += input * 300 * Raylib.GetFrameTime();

            /*
            if (Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_W)) 
            {
                //y += -300.0f * Raylib.GetFrameTime();
                MoveY = -150.0f;
            }
            if (Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_A))
            {
                //x += -300.0f * Raylib.GetFrameTime();
                MoveX = -150.0f;
            }
            if (Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_S))
            {
                //y += 300.0f * Raylib.GetFrameTime();
                MoveY = 150.0f;
            }
            if (Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_D))
            {
                //x += 300.0f * Raylib.GetFrameTime();
                MoveX = 150.0f;
            }
            Draw();
            */
        }
    }
}
