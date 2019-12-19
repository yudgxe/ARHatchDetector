using System;
using UnityEngine;

public static class MathMatrix
{
    public static Matrix4x4 RotateAroundY(float radians)
    {
        var matrix = Matrix4x4.identity;

        matrix.SetColumn(0, new Vector4((float)Math.Cos(radians), 0f, (float)-Math.Sin(radians), 0f));
        matrix.SetColumn(2, new Vector4((float)Math.Sin(radians), 0f, (float)Math.Cos(radians), 0f));

        //return matrix.inverse;
        return matrix;
    }

    private static Matrix4x4 TranslationMatrix(Vector4 translation)
    {
        var matrix = Matrix4x4.identity;
        matrix.SetColumn(3, translation);

        return matrix;
    }

    public static Vector3 TransformMatrix(GPSLocation startLocaion, GPSLocation endLocation, Vector3 originalVector3)
    {
        var bearing = MathLocation.CalculateBearingRadians(startLocaion, endLocation);
        var originalVector = new Vector4(originalVector3.x, originalVector3.y, originalVector3.z, 1);
        var rotationMatrix = RotateAroundY(bearing);

        return rotationMatrix * originalVector;
    }
}
