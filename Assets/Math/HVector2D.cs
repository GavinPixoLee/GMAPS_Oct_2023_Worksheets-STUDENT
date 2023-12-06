using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using System.Runtime.Remoting.Messaging;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    public static HVector2D operator +(HVector2D vector1, HVector2D vector2)
    {
        return new HVector2D(vector1.x + vector2.x, vector1.y + vector2.y);
    }

    public static HVector2D operator -(HVector2D vector1, HVector2D vector2)
    {
        return new HVector2D(vector1.x - vector2.x, vector1.y - vector2.y);
    }

    public static HVector2D operator *(HVector2D vector, float scale)
    {
        return new HVector2D(vector.x * scale, vector.y * scale);
    }

    public static HVector2D operator /(HVector2D vector, float scale)
    {
        return scale == 0 ? new HVector2D(0, 0) : new HVector2D(vector.x / scale, vector.y / scale);
    }

    public float Magnitude()
    {
        return (float)Math.Sqrt((this.x * this.x) + (this.y * this.y));
    }

    public void Normalize()
    {
        float magnitude = this.Magnitude();
        this.x /= magnitude;
        this.y /= magnitude;
    }

    public float DotProduct(HVector2D vector)
    {
        return (this.x * vector.x) + (this.y * vector.y);
    }

    public HVector2D Projection(HVector2D vector)
    {
        return vector * (DotProduct(vector) / vector.DotProduct(vector));
    }

    public float FindAngle(HVector2D vector)
    {
        return (float)Mathf.Acos(DotProduct(vector) / (this.Magnitude() * vector.Magnitude()));
    }

    public Vector2 ToUnityVector2()
    {
        return new Vector2(this.x, this.y); // change this
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(this.x, this.y, 0); // change this
    }

    // public void Print()
    // {

    // }
}
