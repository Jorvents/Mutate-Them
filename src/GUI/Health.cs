using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.GUI
{
    public class Health
    {
        Vector2 dimensions = new Vector2(200,50);
        //int widht = 200;
        //int hight = 50;

        Rectangle blood; //yes blood
        int spacing = 30;

        Rectangle border;
        int room = 11;

        float ratio;
        public Health()
        {
            float health = Game.player.health;
            blood = new Rectangle(Raylib.GetScreenWidth() - dimensions.X - spacing, spacing, dimensions.X, dimensions.Y);
            border = new Rectangle(blood.x - room, blood.y - room, blood.width + room * 2, blood.height + room * 2);
            ratio = dimensions.X / health;

        }
        public void Work()
        {
            blood.width = ratio * Game.player.health;
        }
        public void Draw()
        {
            Raylib.DrawRectangleRec(border, Window.backround);
            Raylib.DrawRectangleRec(blood, Color.RED);
            Raylib.DrawRectangleLinesEx(border, 8f, Color.WHITE);

            Raylib.DrawText(Game.player.health.ToString(), (int)(blood.x + dimensions.X / 2) - (Raylib.MeasureText(Game.player.health.ToString(), 50) / 2), (int)blood.y + 3, 50, Color.WHITE); //idc if messy


            //Raylib.DrawText(ratio.ToString(), 15, 285, 30, Color.WHITE);
            //Raylib.DrawText(widht.ToString(), 15, 315, 30, Color.WHITE);

            //Raylib.DrawText((200 / 1000).ToString(), 15, 345, 30, Color.WHITE);
        }
    }
}
