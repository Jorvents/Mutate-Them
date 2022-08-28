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
        public Texture2D playerHands { get; set; }
        public float HandRotation { get; set; }
        Vector2 OrginOfHands { get; set; }
        Rectangle Hands { get; set; }
        Rectangle Desging { get; set; }
        public Player()
        {
            loc = new Vector2();

            loc = new(Raylib.GetScreenWidth() / 2.0f, Raylib.GetScreenHeight() / 2.0f);

            IsPlaying = false;
            radius = 40;
            colour = Color.SKYBLUE;

            playerHands = Raylib.LoadTexture("Files/Sprites/PlayerHands.png");
            HandRotation = 0.14f;
            Hands = new Rectangle(0.0f, 0.0f, 600.0f, 600.0f); //DONT CHANGE
            Desging = new Rectangle(loc.X, loc.Y, 100.0f, 100.0f);
            OrginOfHands = new Vector2(45, 90);
            //Raylib.UnloadTexture(playerHands);
        }
        public void Work()
        {
            //HandRotation += 700.0f * Raylib.GetFrameTime();
            int x = (Raylib.IsKeyDown(KeyboardKey.KEY_A) ? -1 : 0) + (Raylib.IsKeyDown(KeyboardKey.KEY_D) ? 1 : 0);
            int y = (Raylib.IsKeyDown(KeyboardKey.KEY_W) ? -1 : 0) + (Raylib.IsKeyDown(KeyboardKey.KEY_S) ? 1 : 0);
            Vector2 input = new(x, y);
            if (input != Vector2.Zero)
            {
                IsPlaying = true;
                input = Vector2.Normalize(input);
            }
            loc += input * 300 * Raylib.GetFrameTime();
            Desging = new Rectangle(loc.X, loc.Y, 90.0f, 90.0f);
        }
        public void Draw()
        {

            if (isDead) return;
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
            //Raylib.DrawTextureEx(playerHands, loc, HandRotation, 0.14f, Color.WHITE);
            Raylib.DrawTexturePro(playerHands, Hands, Desging, OrginOfHands, HandRotation + 134, Color.YELLOW);
            //Raylib.DrawText(Desging.height.ToString(), 15, 15, 30, Color.WHITE);
            //Raylib.DrawText(playerHands.height.ToString(), 15, 15, 30, Color.WHITE);
        }
    }
}
