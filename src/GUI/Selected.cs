using System;
using System.Drawing;
using System.Numerics;
using MutateThem.Scenes;
using MutateThem.Some_things.Me;
using MutateThem.Some_things.notPlayer;
using Raylib_cs;
using Color = Raylib_cs.Color;

namespace MutateThem.GUI
{
    public class Selected
    {
        public Texture2D selected;
        public Texture2D unselected;
        public sbyte mutablesCounter;
        public float[] Cooldowns;
        public float[] Cooldown;

        public float pausetime = 0f;
        public bool ispaused = false;

        private Color transparency = new Color(255, 255, 255, 170);

        Vector3[] positions;

        Mutable[] draw;
        Vector2[] locdraw;

        public Selected()
        {
            selected = Raylib.LoadTexture("Files/Sprites/Selected.png");
            unselected = Raylib.LoadTexture("Files/Sprites/UnSelected.png");
            string[] allofthem = Enum.GetNames(typeof(HandPowers.Holding));
            mutablesCounter = (sbyte)(allofthem.Length - 1);
            Cooldowns = new float[mutablesCounter];
            Cooldown = new float[mutablesCounter];

            positions = new Vector3[mutablesCounter];
            draw = new Mutable[mutablesCounter];
            locdraw = new Vector2[mutablesCounter];
        }

        public void Draw()
        {
            for (int i = 0; i < mutablesCounter; i++)
            {
                Vector2 position = new Vector2(positions[i].X, positions[i].Y);

                Raylib.DrawTextureEx(unselected, position, 0f, 0.45f * Window.multyplier.Y, transparency);

                if (i == Game.lastPressed3)
                {
                    Raylib.DrawTextureEx(selected, position, 0f, 0.45f * Window.multyplier.Y, Window.agedwhite);
                }

                Raylib.DrawCircle((int)locdraw[i].X, (int)locdraw[i].Y, draw[i].radius, draw[i].ogColour);

                int cooldawn = (int)Cooldown[i];
                if (Cooldown[i] > 0f)
                {
                    Raylib.DrawTextureEx(unselected, position, 0f, 0.45f * Window.multyplier.Y, new Color(150, 150, 180, 175));
                    int centerection = Raylib.MeasureText(cooldawn.ToString(), (int)(78 * Window.multyplier.Y));
                    Raylib.DrawText(cooldawn.ToString(), (int)(positions[i].X - (centerection / 2) + 45 * Window.multyplier.Y), (int)(positions[i].Y + (11 * Window.multyplier.Y)), (int)(78 * Window.multyplier.Y), Window.agedblue);
                }
            }
        }
        public void Work()
        {
            int spacing = (int)(30 * Window.multyplier.Y);
            int between = (int)(45 * Window.multyplier.Y);

            int up1 = 150;
            int up = 105;

            Mutable drawing = new Empty();
            for (int i = 0; i < mutablesCounter; i++)
            {
                positions[i] = new Vector3(spacing, Raylib.GetScreenHeight() - up1 * Window.multyplier.Y, between);

                switch (i)
                {
                    default:
                    drawing = new Empty(); //without it the last one drawn woudlve not work good VV
                    break;
                    case 0:
                    drawing = Game.mutablescontroller.info[i + 1];
                    break;
                    case 1:
                    drawing = Game.mutablescontroller.info[i + 1];
                    break;
                    case 2:
                    drawing = Game.mutablescontroller.info[i + 1];
                    break;
                    case 3:
                    drawing = Game.mutablescontroller.info[i + 1];
                    break;
                    case 4:
                    drawing = Game.mutablescontroller.info[i + 1];
                    break;
                }
                draw[i] = drawing;
                locdraw[i] = new Vector2(spacing + between, Raylib.GetScreenHeight() - up * Window.multyplier.Y);

                if (Cooldowns[i] > 0)
                {
                    if (Game.player.isActive)
                    {
                        Cooldown[i] = Cooldown[i] - Raylib.GetFrameTime();
                    }

                    if (Cooldown[i] < 1f && Cooldown[i] > 0.1f)
                    {
                        Cooldown[i] = 0f;
                        Cooldowns[i] = 0f;
                    }

                    if (Cooldown[i] < 0)
                    {
                        Cooldown[i] = drawing.cooldown + 1;
                    }
                }

                spacing = spacing + (int)(95 * Window.multyplier.Y);
            }
        }
        public void AddCooldown(int add)
        {
            Cooldowns[add] = 1;
        }
        public void Reset()
        {
            Cooldowns = new float[mutablesCounter];
            Cooldown = new float[mutablesCounter];
        }
    }
}
