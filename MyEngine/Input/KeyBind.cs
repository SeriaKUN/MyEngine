﻿using SFML.Window;

namespace MyEngine.Input
{
    class KeyBind
    {
        public Keyboard.Key key;
        public bool isPressed = false;

        public KeyBind(Keyboard.Key key)
        {
            this.key = key;
        }
    }
}
