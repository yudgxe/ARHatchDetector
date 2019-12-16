using System;

public static class FloatExtension
{
    public static float ToRadians(this float Degress)
    {
        return Degress * (float)Math.PI / 180f;
    }

    public static float ToDegress(this float Degress)
    {
        return Degress * 180 / (float)Math.PI;
    }
}
