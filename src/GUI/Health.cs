using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.GUI
{
    public class Health
    {
        int widht = 200;
        int hight = 50;

        Rectangle blood; //yes blood
        int spacing = 30;

        Rectangle border;
        int room = 11;

        float ratio;
        public Health()
        {
            int health = Game.player.health;
            blood = new Rectangle(Raylib.GetScreenWidth() - widht - spacing, spacing, widht, hight);
            border = new Rectangle(blood.x - room, blood.y - room, blood.width + room * 2, blood.height + room * 2);
            ratio = widht / Game.player.maxhealth;

        }
        public void Work()
        {
            blood.width = 0.2f * Game.player.health;
        }
        public void Draw()
        {
            Raylib.DrawRectangleRec(border, Window.backround);
            Raylib.DrawRectangleRec(blood, Color.RED);
            Raylib.DrawRectangleLinesEx(border, 8f, Color.WHITE);

            Raylib.DrawText(Game.player.health.ToString(), (int)(blood.x + widht / 2) - (Raylib.MeasureText(Game.player.health.ToString(), 50) / 2), (int)blood.y + 3, 50, Color.WHITE); //idc if messy

        }
    }
}
