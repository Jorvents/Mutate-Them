using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MutateThem.Some_things.Me;

namespace MutateThem.Some_things.Me
{
    public class Player : Something
    {
        public Texture2D playerHands { get; set; }
        public float HandRotation { get; set; }
        public HandPowers handpowers { get; set; }

        Vector2 OrginOfHands;
        Rectangle Hands;
        Rectangle Desging;
        public Player()
        {
            //Body
            loc = new(Raylib.GetScreenWidth() / 2.0f, Raylib.GetScreenHeight() / 2.0f);

            IsActive = false;
            radius = 40;
            colour = Color.SKYBLUE;

            //Circle
            playerHands = Raylib.LoadTexture("Files/Sprites/PlayerHands.png");
            HandRotation = 0.14f;
            Hands = new Rectangle(0.0f, 0.0f, 600.0f, 600.0f); //DONT CHANGE
            Desging = new Rectangle(loc.X, loc.Y, 100.0f, 100.0f);
            OrginOfHands = new Vector2(45, 90);

            //Hand powers
            handpowers = new HandPowers();
        }
        public void Work()
        {
            //HandRotation += 700.0f * Raylib.GetFrameTime();
            int x = (Raylib.IsKeyDown(KeyboardKey.KEY_A) ? -1 : 0) + (Raylib.IsKeyDown(KeyboardKey.KEY_D) ? 1 : 0);
            int y = (Raylib.IsKeyDown(KeyboardKey.KEY_W) ? -1 : 0) + (Raylib.IsKeyDown(KeyboardKey.KEY_S) ? 1 : 0);
            Vector2 input = new(x, y);
            if (input != Vector2.Zero)
            {
                IsActive = true;
                input = Vector2.Normalize(input);
            }
            loc += input * 300 * Raylib.GetFrameTime();
            Desging = new Rectangle(loc.X, loc.Y, 90.0f, 90.0f);

            handpowers.stickTo = loc;
            handpowers.Work();
        }
        public void Draw()
        {

            //if (!IsActive) return;
            Raylib.DrawCircle((int)loc.X, (int)loc.Y, radius, colour);
            //Raylib.DrawTextureEx(playerHands, loc, HandRotation, 0.14f, Color.WHITE);
            Raylib.DrawTexturePro(playerHands, Hands, Desging, OrginOfHands, HandRotation + 134, Color.YELLOW);

            handpowers.Draw();
            //Raylib.DrawText(Desging.height.ToString(), 15, 15, 30, Color.WHITE);
            //Raylib.DrawText(playerHands.height.ToString(), 15, 15, 30, Color.WHITE);
        }
    }
}
