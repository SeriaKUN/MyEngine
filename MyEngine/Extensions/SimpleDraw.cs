using SFML.Graphics;
using SFML.System;

namespace MyEngine.Extensions
{
    public static class SimpleDraw
    {
        public static VertexArray DrawLine(this RenderTarget target, Vector2f firstEnd, Vector2f secondEnd, Color color)
        {
            VertexArray vertexArray = new VertexArray(PrimitiveType.LineStrip, 2);
            vertexArray[0] = new Vertex(firstEnd, color);
            vertexArray[1] = new Vertex(secondEnd, color);

            target.Draw(vertexArray);

            return vertexArray;
        }

        public static VertexArray DrawLine(Vector2f firstEnd, Vector2f secondEnd, Color color)
            => Game.window.DrawLine(firstEnd, secondEnd, color);

        public static CircleShape DrawCircle(this RenderTarget target, Vector2f position, float radius, Color color, Vector2f origin)
        {
            CircleShape circle = new CircleShape(radius);
            circle.Position = position;
            circle.Origin = origin;
            circle.FillColor = color;
            target.Draw(circle);
            return circle;
        }

        public static CircleShape DrawCircle(Vector2f position, float radius, Color color, Vector2f origin)
            => Game.window.DrawCircle(position, radius, color, origin);

        public static CircleShape DrawCircle(this RenderTarget target, Vector2f position, float radius, Color color)
            => DrawCircle(target, position, radius, color, new Vector2f(radius, radius));

        public static CircleShape DrawCircle(Vector2f position, float radius, Color color)
            => Game.window.DrawCircle(position, radius, color);

        public static CircleShape DrawCircle(this RenderTarget target, Vector2f position, float radius)
            => DrawCircle(target, position, radius, Color.White);

        public static CircleShape DrawCircle(Vector2f position, float radius)
            => Game.window.DrawCircle(position, radius);

        public static Vertex DrawPoint(this RenderTarget target, Vector2f position, Color color)
        {
            Vertex point = new Vertex(position, color);
            target.Draw(new Vertex[1]{point}, PrimitiveType.Points);
            return point;
        }

        public static Vertex DrawPoint(Vector2f position, Color color)
        {
            Vertex point = new Vertex(position, color);
            Game.window.Draw(new Vertex[1] { point }, PrimitiveType.Points);
            return point;
        }
    }
}
