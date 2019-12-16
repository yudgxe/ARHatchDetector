using System;

static class MathLocation
{
    public static float CalculateBearingRadians(GPSLocation startLocation, GPSLocation endLocation)
    {
        double lat1, lat2, lon1, lon2;

        lat1 = startLocation.latitude.ToRadians();
        lon1 = startLocation.longitude.ToRadians();

        lat2 = endLocation.latitude.ToRadians();
        lon2 = endLocation.longitude.ToRadians();

        double dLon = lon2 - lon1;

        double x = Math.Sin(dLon) * Math.Cos(lat2);
        double y = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(dLon);

        float radiansBearing = (float)Math.Atan2(x, y);

        return radiansBearing;
    }

    public static float CalculateDistance(GPSLocation startLocation, GPSLocation endLocation)
    {
        double lat1, lat2, dLat, dLon;
        double radius = 6371.008;//km

        lat1 = startLocation.latitude.ToRadians();
        lat2 = endLocation.latitude.ToRadians();

        dLat = lat2 - lat1;
        dLon = (endLocation.longitude - startLocation.longitude).ToRadians();

        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(lat1) * Math.Cos(lat2) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        double distance = radius * c;//km

        return (float)distance * 1000;
    }
}
