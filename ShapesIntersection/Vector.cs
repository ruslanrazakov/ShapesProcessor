using System;

namespace ShapesIntersection;

public struct Vector
{
    public float X { get; }
    public float Y { get; }
    public float Magnitude => (float)Math.Sqrt(X * X + Y * Y); 

    public Vector(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static Vector operator -(Vector a)
        => new Vector(-a.X, -a.Y);

    public static Vector operator -(Vector a, Vector b)
        => new Vector(a.X - b.X, a.Y - b.Y);

    public Vector Normalize()
        => new Vector(X / Magnitude, Y / Magnitude);

    public float DotProduct(Vector vector)
        => X * vector.X + Y * vector.Y;
}
