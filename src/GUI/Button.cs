using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using MutateThem.Scenes;
using Raylib_cs;

namespace MutateThem.GUI
{
    public class Button
    {
        Rectangle box;
        public bool isPressed = false;
        public bool isHovered = false;

        string text;
        Texture2D icon;
        Vector2 center;
        int size;

        public Button(Vector2 loc, Vector2 size, string text, int textsize)
        {
            center = loc;
            box = new Rectangle(loc.X - (size.X * Window.multyplier.Y / 2), loc.Y - (size.Y * Window.multyplier.Y / 2), size.X * Window.multyplier.Y, size.Y * Window.multyplier.Y);
            this.text = text;
            this.size = (int)(textsize * Window.multyplier.Y);
        }
        public Button(Vector2 loc, Vector2 size, Texture2D icon, int texturesize)
        {
            center = loc * Window.multyplier.Y;
            box = new Rectangle(loc.X - (size.X * Window.multyplier.Y / 2), loc.Y - (size.Y * Window.multyplier.Y / 2), size.X * Window.multyplier.Y, size.Y * Window.multyplier.Y);
            this.icon = icon;
            this.size = (int)(texturesize * Window.multyplier.Y);
        }
        public void Work()
        {
            isPressed = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), box) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT);
            isHovered = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), box);
        }
        public void Draw()
        {
            Raylib.DrawRectangleRec(box, Window.backround);

            Raylib.DrawText(text, (int)center.X - (Raylib.MeasureText(text, size) / 2), (int)(center.Y - size / 2.3f), size, Window.agedwhite);
            if (!isHovered)
            {
                Raylib.DrawRectangleLinesEx(box, 6.5f * Window.multyplier.Y, Window.agedwhite);
            }
            else
            {
                Raylib.DrawRectangleLinesEx(box, 6.5f * Window.multyplier.Y, Window.agedblue);
            }
        }
    }
}
