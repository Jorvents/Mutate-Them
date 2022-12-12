using MutateThem.Scenes;
using MutateThem.Some_things.Me;
using Raylib_cs;
using System.Numerics;

namespace MutateThem.GUI
{
    public class Health
    {
        Vector2 dimensions = new Vector2(200, 50) * Window.multyplier.Y;

        Rectangle blood; //yes blood
        int spacing = (int)(30 * Window.multyplier.Y);
        public Vector2 centre;

        public Rectangle border;
        byte room = 11;
        float ratio;

        byte critical = 5;

        public Health()
        {
            float health = Game.player.health;
            blood = new Rectangle(Raylib.GetScreenWidth() - dimensions.X - spacing, spacing, dimensions.X, dimensions.Y);
            border = new Rectangle(blood.x - room, blood.y - room, blood.width + room * 2, blood.height + room * 2);
            ratio = dimensions.X / Game.player.maxhealth;
            centre = new Vector2(border.x + border.width / 2, border.y + border.height / 2);
        }
        public void Work()
        {
            blood.width = ratio * Game.player.health;
        }
        public void Draw()
        {
            Raylib.DrawRectangleRec(border, Window.backround);
            Raylib.DrawRectangleRec(blood, Color.RED);
            Raylib.DrawRectangleLinesEx(border, 8f, Window.agedwhite);
            var health = Game.player.health.ToString();
            Raylib.DrawText(health, (int)(blood.x + dimensions.X / 2) - (Raylib.MeasureText(health, (int)(50 * Window.multyplier.Y)) / 2), (int)blood.y + 3, (int)(50 * Window.multyplier.Y), Color.WHITE); //idc if messy
        }
    }
}
