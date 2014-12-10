using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace VoidEngine
{
    public static class Collision
    {
        public struct MapSegment
        {
            public Point point1;
            public Point point2;

            public MapSegment(Point a, Point b)
            {
                point1 = a;
                point2 = b;
            }

            public Vector2 getVector()
            {
                return new Vector2(point2.X - point1.X, point2.Y - point1.Y);
            }

            public Rectangle collisionRect()
            {
                return new Rectangle(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y), Math.Abs(point1.X - point2.X), Math.Abs(point1.Y - point2.Y));
            }
        }

        public static float magnitude(Vector2 vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector2 vectorNormal(Vector2 vector)
        {
            return new Vector2(-vector.Y, vector.X);
        }

        public static Vector2 unitVector(Vector2 vector)
        {
            return new Vector2(vector.X / (float)magnitude(vector), vector.Y / (float)magnitude(vector));
        }

        public static float dotProduct(Vector2 unitVector, Vector2 vector)
        {
            return unitVector.X * vector.X + unitVector.Y * vector.Y;
        }

        public static Vector2 reflectedVector(Vector2 vector, Vector2 reflectVector)
        {
            Vector2 normal = vectorNormal(reflectVector);
            float coeficient = -2 * (dotProduct(vector, normal) / (magnitude(normal) * magnitude(normal)));
            Vector2 r;
            r.X = vector.X + coeficient * normal.X;
            r.Y = vector.Y + coeficient * normal.Y;
            return r;
        }
    }
}
