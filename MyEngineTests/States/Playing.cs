using MyEngine;
using MyEngine.States;
using MyEngine.Extensions;
using SFML.System;
using SFML.Graphics;
using MyEngine.Objects.UI;

namespace MyEngineTests.States
{
    class Playing : State
    {
        TextLabel textLabel = TextLabel.NewTextLabel("textt :sunglasses: :skull:");

        public override void Initialize()
        {
            textLabel.text.Position = new Vector2f(100, 100);
            textLabel.text.FillColor = Color.Black;
            textLabel.text.CharacterSize = 10;
        }

        public override void Input()
        {
            Game.window.DispatchEvents();
        }

        public override void Render()
        {
            Game.window.Clear(Color.White);
            textLabel.Render();
            Game.window.Display();
        }

        public override void Update()
        {
            
        }
    }
}
