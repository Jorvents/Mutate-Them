using System.Numerics;
using System.Xml.Linq;
using Raylib_cs;

namespace MutateThem.Some_things.Me;

public class Player : Something
{
    public Texture2D playerHands;
    public float handRotation;
    public HandPowers handpowers;

    public int maxhealth = 20;
    public int health;
    int speed = (int)(260 * Window.multyplier.Y);

    Vector2 OrginOfHands;
    Rectangle Hands;
    Rectangle Desging;

    Vector2 input = new Vector2();
    bool[] touching = new bool[4];

    public Player() : base(new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()) / 2, 40, Color.SKYBLUE)
    {
        //Circle
        playerHands = Raylib.LoadTexture("Files/Sprites/PlayerHands.png");
        health = maxhealth;
        handRotation = .14f;
        Hands = new Rectangle(0, 0, 600 , 600); //DONT CHANGE
        Desging = new Rectangle(loc.X, loc.Y, 100, 100);
        OrginOfHands = new Vector2(45 * Window.multyplier.Y, 90 * Window.multyplier.Y);

        //Hand powers
        handpowers = new HandPowers(new Vector2(loc.X, loc.Y));
    }

    public void Work()
    {
        if (health <= 0)
        {
            Game.Quit();
        }

        var x = (Raylib.IsKeyDown(KeyboardKey.KEY_A) ? -1 : 0) + (Raylib.IsKeyDown(KeyboardKey.KEY_D) ? 1 : 0);
        var y = (Raylib.IsKeyDown(KeyboardKey.KEY_W) ? -1 : 0) + (Raylib.IsKeyDown(KeyboardKey.KEY_S) ? 1 : 0);

        input = new(x, y);

        var angle = Angle(loc, Raylib.GetMouseX(), Raylib.GetMouseY());
        handRotation = angle + 135.5f;

        Game.player.handpowers.rotateIn = toVector(angle - 180) * handpowers.disctance;

        handpowers.stickTo = loc;
        handpowers.Work();

        Desging = new Rectangle(loc.X, loc.Y, 90.0f * Window.multyplier.Y, 90.0f * Window.multyplier.Y);

        for (int i = 0; i < Game.borders.Length; i++)
        {
            touching[i] = Raylib.CheckCollisionCircleRec(loc, radius, Game.borders[i]);
            /*
            if (Raylib.CheckCollisionCircleRec(loc, radius, Game.borders[i]))
            {

                switch (i)
                {
                    case 0:
                    if (oginput.Y < -0.1f)
                    {
                        input.Y = 0;
                        if (oginput.X > 0.1f)
                        {
                            input.X = 1f;
                        }
                        if (oginput.X < -0.1f)
                        {
                            input.X = -1f;
                        }
                    }
                    break;
                    case 1:
                    if (oginput.Y > 0.1f)
                    {
                        input.Y = 0;
                        if (oginput.X > 0.1f)
                        {
                            input.X = 1f;
                        }
                        if (oginput.X < -0.1f)
                        {
                            input.X = -1f;
                        }
                    }
                    break;
                    case 3:
                        if (oginput.X < -0.1f)
                        {
                            input.X = 0;
                            if (oginput.Y > 0.1f)
                            {
                                input.Y = 1f;
                            }
                            if (oginput.Y < -0.1f)
                            {
                                input.Y = -1f;
                            }
                        }
                        break;
                    case 2:
                        if (oginput.X > 0.1f)
                        {
                            input.X = 0;
                            if (oginput.Y > 0.1f)
                            {
                                input.Y = 1f;
                            }
                            if (oginput.Y < -0.1f)
                            {
                                input.Y = -1f;
                            }
                        }
                        break;
                }
            }
            */
        }

        if (touching[0])
        {
            if (input.Y < -0.1f)
            {
                input.Y = 0;
                if (input.X > 0.1f)
                {
                    input.X = 1f;
                }
                if (input.X < -0.1f)
                {
                    input.X = -1f;
                }
            }
        }
        if (touching[1])
        {
            if (input.Y > 0.1f)
            {
                input.Y = 0;
                if (input.X > 0.1f)
                {
                    input.X = 1f;
                }
                if (input.X < -0.1f)
                {
                    input.X = -1f;
                }
            }
        }
        if (touching[2])
        {
            if (input.X > 0.1f)
            {
                input.X = 0;
                if (input.Y > 0.1f)
                {
                    input.Y = 1f;
                }
                if (input.Y < -0.1f)
                {
                    input.Y = -1f;
                }
            }
        }
        if (touching[3])
        {
            if (input.X < -0.1f)
            {
                input.X = 0;
                if (input.Y > 0.1f)
                {
                    input.Y = 1f;
                }
                if (input.Y < -0.1f)
                {
                    input.Y = -1f;
                }
            }
        }
        //CORNERS
        if (touching[0] && touching[2])
        {
            if (input.Y < -0.1f && input.X > 0.1f)
            {
                input = new(0);
            }
        }
        if (touching[2] && touching[1])
        {
            if (input.X > 0.1f && input.Y > 0.1f)
            {
                input = new(0);
            }
        }
        if (touching[1] && touching[3])
        {
            if (input.X > 0.1f && input.X < -0.1f)
            {
                input = new(0);
            }
        }
        if (touching[3] && touching[0])
        {
            if (input.X < -0.1f && input.Y < -0.1f)
            {
                input = new(0);
            }
        }
        if (input != Vector2.Zero)
        {
            isActive = true;
            input = Vector2.Normalize(input);
        }
        loc += input * speed * Raylib.GetFrameTime();
    }

    public void Draw()
    {
        //if (!IsActive) return;
        Raylib.DrawCircle((int) loc.X, (int) loc.Y, radius, colour);
        //Raylib.DrawText(health.ToString(), 15, 195, 30, Color.WHITE);
        //Raylib.DrawTextureEx(playerHands, loc, HandRotation, 0.14f, Color.WHITE);
        Raylib.DrawTexturePro(playerHands, Hands, Desging, OrginOfHands, handRotation + 134, Color.YELLOW);
        //Raylib.DrawText(input.ToString(),15, 195, 30, Color.WHITE);

        //handpowers.Draw();
        //Raylib.DrawText(Desging.height.ToString(), 15, 15, 30, Color.WHITE);
        //Raylib.DrawText(playerHands.height.ToString(), 15, 15, 30, Color.WHITE);
    }
    public void Damage(int amount)
    {
        health = health - amount;
    }
}