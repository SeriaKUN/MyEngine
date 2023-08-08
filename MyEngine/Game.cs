using MyEngine.States;
using SFML.Graphics;
using SFML.Window;

namespace MyEngine
{
    public abstract class Game
    {
        public State state;
        public static RenderWindow window = new RenderWindow(new VideoMode(750, 750), "game");

        public bool continuePlaying = true;

        public void Run()
        {
            SetStartingState();
            while (continuePlaying)
            {
                state.Update();
                state.Render();
                state.Input();
                state.Timing();
            }
        }

        public void SetState(State state)
        {
            this.state = state;
            this.state.Initialize();
        }

        protected abstract void SetStartingState();

    }
}
