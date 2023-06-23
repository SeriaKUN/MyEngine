using SFML.Window;

namespace MyEngine.Input
{
    public class KeyBind
    {
        public Keyboard.Key key;
        public bool isPressed = false;
        public bool wasPressed = false;

        public KeyBind(Keyboard.Key key)
        {
            this.key = key;
        }
    }
}
