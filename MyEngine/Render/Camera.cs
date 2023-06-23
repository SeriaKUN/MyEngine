﻿using SFML.System;
using SFML.Graphics;
using MyEngine.GameObjects;

namespace MyEngine.Render
{
    public class Camera
    {
        public FloatRect rectangle;
        public Vector2f center;
        public Vector2f size;
        public RenderTarget renderTarget;
        public Color backGroundColor;

        public Camera(Vector2f center, Vector2f size, RenderTarget renderTarget, Color backGroundColor)
        {
            this.center = center;
            this.size = size;
            this.renderTarget = renderTarget;
            this.backGroundColor = backGroundColor;

            rectangle = new FloatRect();
            rectangle.Left = center.X - size.X * 0.5f;
            rectangle.Top = center.Y - size.Y * 0.5f;
            rectangle.Width = size.X;
            rectangle.Height = size.Y;
        }

        public void Render(List<GameObject> gameObjects)
        {
            rectangle.Left = center.X - size.X * 0.5f;
            rectangle.Top = center.Y - size.Y * 0.5f;
            rectangle.Width = size.X;
            rectangle.Height = size.Y;

            renderTarget.Clear(Color.Black);

            foreach (GameObject gameObject in gameObjects)
                gameObject.TryRender();
        }
    }
}
