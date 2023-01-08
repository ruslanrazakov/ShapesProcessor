using System;

namespace ShapesProcessor.Lib.Shapes;

public struct Vector
{
    public float X { get; }
    public float Y { get; }

    public Vector(float x, float y)
    {
        X = x;
        Y = y;
    }

    public static Vector operator +(Vector a, Vector b)
        => new Vector(a.X + b.X, a.Y + b.Y);

    public static Vector operator -(Vector a)
        => new Vector(-a.X, -a.Y);

    public static Vector operator -(Vector a, Vector b)
        => new Vector(a.X - b.X, a.Y - b.Y);

    public static Vector operator *(Vector a, float b)
        => new Vector(a.X * b, a.Y * b);

    public static Vector operator *(float b, Vector a)
        => new Vector(a.X * b, a.Y * b);

    public float Magnitude 
        => (float)Math.Sqrt(X * X + Y * Y);

    public Vector Normalize()
        => new Vector(X / Magnitude, Y / Magnitude);


    public float DotProduct(Vector vector)
        => X * vector.X + Y * vector.Y;

    public float LengthSquared()
        => (X * X) + (Y * Y);
    
    public float DistanceSquared(Vector b)
    {
        float v1 = X - b.X, v2 = Y - b.Y;
        return (v1 * v1) + (v2 * v2);
    }
}
