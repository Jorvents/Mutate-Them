using System.Numerics;
using Raylib_cs;

namespace MutateThem.Some_things.Me;

public class Player : Something
{
    public Texture2D playerHands;
    public float handRotation;
    public HandPowers handpowers;

    public int maxhealth = 10000;
    public float health;

    Vector2 OrginOfHands;
    Rectangle Hands;
    Rectangle Desging;

    public Player() : base(Window.WindowSize / 2, 40, Color.SKYBLUE)
    {
        //Circle
        playerHands = Raylib.LoadTexture("Files/Sprites/PlayerHands.png");
        health = maxhealth;
        handRotation = .14f;
        Hands = new Rectangle(0, 0, 600, 600); //DONT CHANGE
        Desging = new Rectangle(loc.X, loc.Y, 100, 100);
        OrginOfHands = new Vector2(45, 90);

        //Hand powers
        handpowers = new HandPowers(Window.WindowSize / 2);
    }

    public void Work()
    {
        //HandRotation += 700.0f * Raylib.GetFrameTime();
        if (health <= 0)
        {
            Game.Quit();
        }
        var x = (Raylib.IsKeyDown(KeyboardKey.KEY_A) ? -1 : 0) + (Raylib.IsKeyDown(KeyboardKey.KEY_D) ? 1 : 0);
        var y = (Raylib.IsKeyDown(KeyboardKey.KEY_W) ? -1 : 0) + (Raylib.IsKeyDown(KeyboardKey.KEY_S) ? 1 : 0);
        Vector2 input = new(x, y);

        if (input != Vector2.Zero)
        {
            isActive = true;
            input = Vector2.Normalize(input);
        }

        loc += input * 300 * Raylib.GetFrameTime();
        Desging = new Rectangle(loc.X, loc.Y, 90.0f, 90.0f);

        var angle = Angle(loc, Raylib.GetMouseX(), Raylib.GetMouseY());
        handRotation = angle + 135.5f;

        handpowers.rotateIn = toVector(angle - 180) * handpowers.disctance;

        handpowers.stickTo = loc;
        handpowers.Work();
    }

    public void Draw()
    {
        //if (!IsActive) return;
        Raylib.DrawCircle((int) loc.X, (int) loc.Y, radius, colour);
        //Raylib.DrawText(health.ToString(), 15, 195, 30, Color.WHITE);
        //Raylib.DrawTextureEx(playerHands, loc, HandRotation, 0.14f, Color.WHITE);
        Raylib.DrawTexturePro(playerHands, Hands, Desging, OrginOfHands, handRotation + 134, Color.YELLOW);

        //handpowers.Draw();
        //Raylib.DrawText(Desging.height.ToString(), 15, 15, 30, Color.WHITE);
        //Raylib.DrawText(playerHands.height.ToString(), 15, 15, 30, Color.WHITE);
    }
    public void Damage(int amount)
    {
        health = health - amount;
    }
}