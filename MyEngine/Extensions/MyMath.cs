using SFML.Graphics;
using SFML.System;

namespace MyEngine.Extensions
{
    public static class MyMath
    {
        public static float Distance(this Vector2f firstVector, Vector2f secondVector)
            => (float)Math.Sqrt(DistanceSquared(firstVector, secondVector));

        public static float DistanceSquared(this Vector2f firstVector, Vector2f secondVector)
        {
            float differenceX = firstVector.X - secondVector.X;
            float differenceY = firstVector.Y - secondVector.Y;

            float result = (differenceX * differenceX) + (differenceY * differenceY);
            return result;
        }

        public static float GetLengthSquared(this Vector2f vector)
            => (vector.X * vector.X) + (vector.Y * vector.Y);

        public static float GetLength(this Vector2f vector)
            => (float)Math.Sqrt(GetLengthSquared(vector));

        public static Vector2f Normal(this Vector2f vector)
        {
            float vectorLength = vector.GetLength();
            return new Vector2f(vector.X / vectorLength, vector.Y / vectorLength);
        }

        public static Vector2f CalculateVector(float length, float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            Vector2f direction = new Vector2f(cos, sin);
            return direction * length;
        }

        public static Vector2f Clamp(Vector2f valueVector, Vector2f minVector, Vector2f maxVector)
        {
            float clampedX = Math.Clamp(valueVector.X, minVector.X, maxVector.X);
            float clampedY = Math.Clamp(valueVector.Y, minVector.Y, maxVector.Y);

            return new Vector2f(clampedX, clampedY);
        }

        public static Vector2f[] GetCorners(this FloatRect rectangle)
        {
            Vector2f leftTopCorner = new Vector2f(rectangle.Left, rectangle.Top);
            Vector2f rightTopCorner = new Vector2f(rectangle.Left + rectangle.Width, rectangle.Top);
            Vector2f leftBottomCorner = new Vector2f(rectangle.Left, rectangle.Top + rectangle.Height);
            Vector2f rightBottomCorner = new Vector2f(rectangle.Left + rectangle.Width, rectangle.Top + rectangle.Height);

            return new Vector2f[] { leftTopCorner, rightTopCorner, leftBottomCorner, rightBottomCorner };
        }

        public static Vector2f GetCenter(this FloatRect rectangle)
            => new Vector2f(rectangle.GetCenterX(), rectangle.GetCenterY());

        public static float GetCenterX(this FloatRect rectangle)
            => rectangle.Left + (rectangle.Width * 0.5f);

        public static float GetCenterY(this FloatRect rectangle)
            => rectangle.Top + (rectangle.Height * 0.5f);

        public static Vector2f GetSize(this FloatRect rectangle)
            => new Vector2f(rectangle.Width, rectangle.Height);

        public static void SetCenter(this ref FloatRect rectangle, Vector2f center)
        {
            rectangle.Left = center.X - rectangle.Width * 0.5f;
            rectangle.Top = center.Y - rectangle.Height * 0.5f;
        }
    }
}
