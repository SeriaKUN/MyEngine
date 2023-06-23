﻿using SFML.Window;
using SFML.System;

namespace MyEngine.Input
{
    public class PlayerInput
    {
        private Dictionary<string, KeyBind> inputKeys = new Dictionary<string, KeyBind>();

        private Dictionary<string, Vector2f> inputVectors = new Dictionary<string, Vector2f>();

        public Vector2f GetVector(string vectorName)
            => inputVectors[vectorName];

        public KeyBind GetKeyBind(string keyBindName)
            => inputKeys[keyBindName];

        public Keyboard.Key GetKey(string keyBindName)
            => inputKeys[keyBindName].key;

        public bool IsKeyPressed(string keyBindName)
            => inputKeys[keyBindName].isPressed;

        public bool WasKeyPressed(string keyBindName)
            => inputKeys[keyBindName].wasPressed;

        public void SetVector(string vectorName, Vector2f vector)
            => inputVectors[vectorName] = vector;

        public void SetKey(string keyBindName, Keyboard.Key key)
            => inputKeys[keyBindName].key = key;

        public void SetKeyPress(string keyBindName, bool isPressed)
            => inputKeys[keyBindName].isPressed = isPressed;

        public void AddBinding(string name, Keyboard.Key key)
            => inputKeys.Add(name, new KeyBind(key));

        public void AddVector2(string name)
            => inputVectors.Add(name, new Vector2f());

        public void UpdateKeyInput()
        {
            foreach (KeyBind keyBind in inputKeys.Values)
            {
                keyBind.wasPressed = keyBind.isPressed;
                keyBind.isPressed = Keyboard.IsKeyPressed(keyBind.key);
            }
        }
    }
}
