using SFML.Graphics;
using SFML.System;

namespace MyEngine.Extensions
{
    public static class SimpleDraw
    {
        public static VertexArray DrawLine(this RenderWindow window, Vector2f firstEnd, Vector2f secondEnd, Color color)
        {
            VertexArray vertexArray = new VertexArray(PrimitiveType.LineStrip, 2);
            vertexArray[0] = new Vertex(firstEnd, color);
            vertexArray[1] = new Vertex(secondEnd, color);

            window.Draw(vertexArray);

            return vertexArray;
        }

        public static VertexArray DrawLine(Vector2f firstEnd, Vector2f secondEnd, Color color)
            => Game.window.DrawLine(firstEnd, secondEnd, color);
    }
}
