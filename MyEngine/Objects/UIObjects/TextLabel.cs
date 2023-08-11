using MyEngine.Objects.Interfaces;
using MyEngine.Objects.UI;
using SFML.Graphics;

namespace MyEngine.Objects.UI
{
    public class TextLabel : UIObject, IRenderable
    {
        public Text text;

        public TextLabel(Text text)
        {
            this.text = text;
        }

        public static TextLabel NewTextLabel(string text, string fontPath)
        {
            Font font = new Font(fontPath);
            return new TextLabel(new Text(text, font));
        }

        public void Render()
        {
            if (isRendered)
                Game.window.Draw(text);
        }
    }
}
