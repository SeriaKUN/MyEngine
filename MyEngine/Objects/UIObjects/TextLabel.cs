using MyEngine.Objects.Interfaces;
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

        public static TextLabel NewTextLabel(string text)
        {
            Font font = new Font("C:\\Users\\Kudlaty\\GIT things\\MyEngine\\MyEngine\\bin\\ARIAL.TTF");
            return new TextLabel(new Text(text, font));
        }

        public void Render()
        {
            if (isRendered)
                Game.window.Draw(text);
        }
    }
}
