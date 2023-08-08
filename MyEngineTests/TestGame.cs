using MyEngine;
using MyEngineTests.States;

namespace MyEngineTests
{
    class TestGame : Game
    {
        protected override void SetStartingState()
        {
            SetState(new Playing());
        }
    }
}
