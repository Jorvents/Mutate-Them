using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace MutateThem.GUI
{
    public class Button
    {
        Rectangle box;
        public bool isPressed = false;

        string message;
        public Button()
        {
            box = new Rectangle(100,100,100,100);
        }
        public void Work()
        {
            isPressed = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), box) && Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT);
            /*
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), box))
            {
                isPressed = true;
            } else
            {
                isPressed = false;
            }
            */
        }
        public void Draw()
        {
            if (isPressed)
            {
                Raylib.DrawRectangleLinesEx(box, 6.5f, Color.WHITE);
            } else
            {
                Raylib.DrawRectangleLinesEx(box, 6.5f, Color.GOLD);
            }
        }
    }
}
