using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static MutateThem.Some_things.player.Input;

namespace MutateThem.Some_things.player
{
    class Input
    {
        public enum actions
        {
            interact,
            use,
            startwave,
            lastpressedRight,
            lastpressedLeft,
            uiUp,
            uiDown,
            uiLeft,
            uiRight,
        }


        bool interact = false;
        bool use = false;
        bool startwave = false;

        Vector2 rightstick;
        Vector2 leftstick;


        //bool 

        public Dictionary<actions, KeyboardKey> keyboardBindings = new()
        {
            {actions.startwave, KeyboardKey.KEY_SPACE}, 
        };
        public Dictionary<actions, MouseButton> mouseBindings = new()
        {
            {actions.interact, MouseButton.MOUSE_LEFT_BUTTON}, { actions.use, MouseButton.MOUSE_RIGHT_BUTTON},
        };

        public Dictionary<actions, GamepadButton> controllerBindings = new()
        {
            {actions.interact, GamepadButton.GAMEPAD_BUTTON_RIGHT_FACE_DOWN}, { actions.use, GamepadButton.GAMEPAD_BUTTON_LEFT_FACE_LEFT},
        };

        public void Play()
        {

        }
        public void Work()
        {

        }
        public void Draw()
        {

        }
    }
}
