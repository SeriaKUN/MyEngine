using SFML.System;
using SFML.Graphics;
using MyEngine.GameObjects;

namespace MyEngine.Render
{
    class Camera
    {
        public FloatRect rectangle = new FloatRect();
        public Vector2f center;
        public Vector2f size;

        public Camera(FloatRect rectangle, Vector2f center, Vector2f size)
        {
            this.rectangle = rectangle;
            this.center = center;
            this.size = size;
        }

        public void Render(List<GameObject> gameObjects, RenderTarget target)
        {
            rectangle.Left = center.X - size.X * 0.5f;
            rectangle.Top = center.Y - size.Y * 0.5f;
            rectangle.Width = size.X;
            rectangle.Height = size.Y;

            target.Clear(Color.Black);

            foreach (GameObject gameObject in gameObjects)
                gameObject.TryRender();
        }
    }
}
