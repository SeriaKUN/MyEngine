using SFML.System;
using SFML.Graphics;
using MyEngine.Extensions;
using MyEngine.Objects.GameObjects;

namespace MyEngine.Render
{
    public class Camera
    {
        public FloatRect rectangle;
        public RenderTarget renderTarget;

        public Color backGroundColor;

        public Vector2f Center => rectangle.GetCenter();
        public float CenterX => rectangle.GetCenterX();
        public float CenterY => rectangle.GetCenterY();
        public Vector2f Size => rectangle.GetSize();
        public float Left => rectangle.Left;
        public float Top => rectangle.Top;
        public float Right => rectangle.Left + rectangle.Width;
        public float Bottom => rectangle.Top + rectangle.Height;
        public float Height => rectangle.Height;
        public float Width => rectangle.Width;


        public Camera(FloatRect rectangle, RenderTarget renderTarget, Color backGroundColor)
        {
            this.rectangle = rectangle;
            this.renderTarget = renderTarget;
            this.backGroundColor = backGroundColor;
        }

        public void Render(List<GameObject> gameObjects)
        {
            renderTarget.Clear(Color.Black);

            foreach (GameObject gameObject in gameObjects)
                gameObject.TryRender();
        }

    }
}
