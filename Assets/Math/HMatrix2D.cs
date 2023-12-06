using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        SetIdentity();
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                Entries[row, col] = multiArray[row, col];
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;

    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        float[,] sumEntries = new float[3,3];
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                sumEntries[row, col] = left.Entries[row, col] + right.Entries[row,col];
        return new HMatrix2D(sumEntries);
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        float[,] differenceEntries = new float[3, 3];
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                differenceEntries[row, col] = left.Entries[row, col] - right.Entries[row, col];
        return new HMatrix2D(differenceEntries);
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        float[,] scaledEntries = new float[3, 3];
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                scaledEntries[row, col] = left.Entries[row, col] * scalar;
        return new HMatrix2D(scaledEntries);
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D(
                left.Entries[0,0] * right.x + left.Entries[0,1] * right.y + left.Entries[0,2],
                left.Entries[1,0] * right.x + left.Entries[1,1] * right.y + left.Entries[1,2]
            );
    }

    // Note that the second argument is a HMatrix2D object
    //

    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D product = new HMatrix2D();

        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                product.Entries[row, col] = (left.Entries[row, 0] * right.Entries[0, col]) + (left.Entries[row, 1] * right.Entries[1, col]) + (left.Entries[row, 2] * right.Entries[2, col]);

        return product;

    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                if (left.Entries[row, col] != right.Entries[row, col]) { return false; }
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                if (left.Entries[row, col] != right.Entries[row, col]) { return true; }
        return false;
    }


    public HMatrix2D Transpose()
    {
        HMatrix2D transposed = new HMatrix2D();

        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                transposed.Entries[row, col] = this.Entries[col, row];

        return transposed;
    }

    public float GetDeterminant()
    {
        float result = 0.0f;
        for (int  i = 0; i < 3; i++)
            result += ((this.Entries[0, i] * this.Entries[1, (i+1)%3] * this.Entries[2, (i+2) % 3]) - (this.Entries[0, i] * this.Entries[1, (i-1) % 3] * this.Entries[2, (i-2) % 3]));
        return result;
    }

    public void SetIdentity()
    {
        Entries = new float[3, 3];
        for (int row = 0; row < 3; row++) {
            Entries[row, row] = 1;
        }
    }

    public void SetTranslationMat(float transX, float transY)
    {
        this.SetIdentity();
        Entries[0, 2] = transX;
        Entries[1, 2] = transY;
    }

    public void SetRotationMat(float rotDeg)
    {
        this.SetIdentity();
        float rad = rotDeg * (math.PI / 180);
        Entries[0, 0] = math.cos(rad);
        Entries[0, 1] = -math.sin(rad);
        Entries[1, 0] = math.sin(rad);
        Entries[1, 1] = math.cos(rad);

    }

    public void SetScalingMat(float scaleX, float scaleY)
    {
        this.SetIdentity();
        Entries[0, 0] = scaleX;
        Entries[1, 1] = scaleY;
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}