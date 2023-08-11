using MyEngine;
using MyEngine.States;
using MyEngine.Extensions;
using SFML.System;
using SFML.Graphics;

namespace MyEngineTests.States
{
    class Playing : State
    {

        public override void Initialize()
        {

        }

        public override void Input()
        {
            Game.window.DispatchEvents();
        }

        public override void Render()
        {
            Game.window.Clear(new Color(128, 128, 128));
            Game.window.DrawCircle(new Vector2f(100, 100), 100);
            Game.window.DrawCircle(new Vector2f(0, 0), 50, Color.Red);
            Game.window.Display();
        }

        public override void Update()
        {
            
        }
    }
}
