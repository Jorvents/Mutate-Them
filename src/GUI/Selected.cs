using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MutateThem;
using MutateThem.Some_things.Me;
using MutateThem.Some_things.notPlayer;
using Raylib_cs;

namespace MutateThem.GUI
{
    public class Selected
    {
        public Texture2D selected;
        public Texture2D unselected;
        public static int mutablesCounter;
        public static float[] Cooldowns;
        public static float[] Cooldown;
        //bool loaded = false;
        private Color transparency = new Color(235, 235, 255, 210);
        //public Color[] iconColours;
        //public int allayCooldown;

        //private Vector2[] positions;
        //Mutable source = new Mutable();
        public Selected()
        {
            selected = Raylib.LoadTexture("Files/Sprites/Selected.png");
            unselected = Raylib.LoadTexture("Files/Sprites/UnSelected.png");
            string[] allofthem = Enum.GetNames(typeof(HandPowers.Holding));
            mutablesCounter = allofthem.Length;
            Cooldowns = new float[mutablesCounter];
            Cooldown = new float[mutablesCounter];
            //iconColours = new Color[mutablesCounter];
            //iconColours.ToList().Last
            //setColours();
            /*
            positions = new Vector2[mutablesCounter];
            positions[0] = new Vector2(50, Raylib.GetScreenHeight() - 200);
            positions[1] = new Vector2(225, Raylib.GetScreenHeight() - 200);
            */
        }
        public void Work()
        {
            //allayCooldown = Cooldowns[1] - 
            //Cooldowns
            //string[] allofthem = Enum.GetNames(typeof(Mutable.Mutables));

            //int need2 = Game.lastPressed3;
            //need3 - Getinfo

        }
        public void Draw()
        {
            int spacing = (int)(50 * Window.multyplier.Y);
            int between = (int)(50 * Window.multyplier.Y);
            Mutable drawing = new Empty();
            for (int i = 0; i < mutablesCounter; i++)
            {
                if (i == Game.lastPressed3)
                {
                    Raylib.DrawTextureEx(selected, new Vector2(spacing, Raylib.GetScreenHeight() - 150 * Window.multyplier.Y), 0f, 0.5f * Window.multyplier.Y, transparency);
                }
                else
                {
                    Raylib.DrawTextureEx(unselected, new Vector2(spacing, Raylib.GetScreenHeight() - 150 * Window.multyplier.Y), 0f, 0.5f * Window.multyplier.Y, transparency);
                }
                switch (i)
                {
                    default:
                    drawing = new Empty(); //without it the last one drawn woudlve not work good VV
                    break;
                    case 0:
                    drawing = new Enemy(Game.player, new Vector2(spacing + between, Raylib.GetScreenHeight() - 100 * Window.multyplier.Y));
                    break;
                    case 1:
                    drawing = new Ally(new Vector2(spacing + between, Raylib.GetScreenHeight() - 100 * Window.multyplier.Y));
                    break;
                    case 2:
                    drawing = new Bomb(new Vector2(spacing + between, Raylib.GetScreenHeight() - 100 * Window.multyplier.Y));
                    break;
                    case 3:
                    drawing = new Teleport(new Vector2(spacing + between, Raylib.GetScreenHeight() - 100 * Window.multyplier.Y));
                    break;
                    case 4:
                    drawing = new Shield(new Vector2(spacing + between, Raylib.GetScreenHeight() - 100 * Window.multyplier.Y));
                    break;
                }
                drawing.inControl = true;
                drawing.colour = drawing.ogColour;
                drawing.Draw();
                if (Cooldown[i] > 0f)
                {
                    Raylib.DrawTextureEx(unselected, new Vector2(spacing, Raylib.GetScreenHeight() - 150 * Window.multyplier.Y), 0f, 0.5f * Window.multyplier.Y, new Color(150, 150, 180, 200));
                    int centerection = Raylib.MeasureText(Cooldown[i].ToString(), (int)(90 * Window.multyplier.Y));
                    Raylib.DrawText(Cooldown[i].ToString(), (int)(spacing - (centerection / 2) + 50 * Window.multyplier.Y), (int)(Raylib.GetScreenHeight() - 140 * Window.multyplier.Y), (int)(90 * Window.multyplier.Y), Color.WHITE);
                }
                if (Cooldowns[i] > 0)
                {
                    Cooldown[i] = (int)drawing.cooldown + (int)(Cooldowns[i] - ((Game.GetTimeMs() - Game.start) / 1000f));
                    if (Cooldown[i] == 0)
                    {
                        Cooldown[i] = 0f;
                        Cooldowns[i] = 0f;
                    }
                }
                spacing += (int)(125 * Window.multyplier.Y);
                /*
                if (Cooldowns.Any())
                {
                    Raylib.DrawText(Cooldowns[1].ToString(), 30, 450, 30, Color.WHITE);
                }
                */
                //Raylib.DrawText(adding.ToString(), 30, 480, 30, Color.WHITE);
                //aylib.DrawText(Cooldowns[Game.lastPressed3].ToString(), 30, 510, 30, Color.WHITE);
                //Cooldowns.ForEach(s => Raylib.DrawText(s.ToString(), 450, 30, 30, Color.WHITE));
                /*
                if (!loaded)
                {
                    Game.statues.Add(drawing);
                    if (i > mutablesCounter)
                    {
                        loaded = true;
                    }
                }
                loaded = false;
                */
            }
            /*
            if (!loaded)
            {
                Game.statues.Add(drawing);
                loaded = true;
            }
            */

            //Raylib.DrawTextureEx(selected, positions[0], 0f, 0.75f, Color.WHITE);
            //Raylib.DrawTextureEx(selected, positions[1], 0f, 0.75f, Color.WHITE);
            //Raylib.DrawTexture(unselected, 600, 600, Color.WHITE);
            //Raylib.DrawText(mutablesCounter.ToString(), 15, 250, 30, Color.WHITE);
        }
        public static void AddCooldown(int add)
        {
            Cooldowns[add] = (Game.GetTimeMs() - Game.start) / 1000f;
        }
        public static void Reset()
        {
            Cooldowns = new float[mutablesCounter];
            Cooldown = new float[mutablesCounter];
        }
    }
}
