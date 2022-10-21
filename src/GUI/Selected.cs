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
        private int mutablesCounter;
        //bool loaded = false;
        private Color transparency = new Color(235, 235, 255, 210);
        //private Vector2[] positions;
        //Mutable source = new Mutable();
        public Selected()
        {
            selected = Raylib.LoadTexture("Files/Sprites/Selected.png");
            unselected = Raylib.LoadTexture("Files/Sprites/UnSelected.png");
            string[] allofthem = Enum.GetNames(typeof(HandPowers.Holding));
            mutablesCounter = allofthem.Length;
            /*
            positions = new Vector2[mutablesCounter];
            positions[0] = new Vector2(50, Raylib.GetScreenHeight() - 200);
            positions[1] = new Vector2(225, Raylib.GetScreenHeight() - 200);
            */
        }
        public void Work()
        {
            //string[] allofthem = Enum.GetNames(typeof(Mutable.Mutables));

            //int need2 = Game.lastPressed3;
            //need3 - Getinfo
        }
        public void Draw()
        {
            int spacing = 50;
            Mutable drawing = new Empty();
            for (int i = 0; i < mutablesCounter; i++)
            {
                if (i == Game.lastPressed3)
                {
                    Raylib.DrawTextureEx(selected, new Vector2(spacing, Raylib.GetScreenHeight() - 150), 0f, 0.5f, transparency);
                }
                else
                {
                    Raylib.DrawTextureEx(unselected, new Vector2(spacing, Raylib.GetScreenHeight() - 150), 0f, 0.5f, transparency);
                }
                switch(i)
                {
                    case 0:
                    drawing = new Enemy(Game.player, new Vector2(spacing + 50, Raylib.GetScreenHeight() - 100));
                    break;
                    case 1:
                    drawing = new Ally(new Vector2(spacing + 50, Raylib.GetScreenHeight() - 100));
                    break;
                }
                drawing.Draw();
                spacing += 125;
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
    }
}
