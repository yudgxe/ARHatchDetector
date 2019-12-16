using UnityEngine;

public class GPSTraker : MonoBehaviour
{
    private static GPSLocation _currentLocation;
    public static GPSLocation currentlocation { get => _currentLocation; }
   

    public float angleToNorth
    {
        get => Input.location.status == LocationServiceStatus.Running ? -Input.compass.trueHeading : 0;
    }

    public void StartTraking()
    {
        if (Input.location.isEnabledByUser)
        {
            Input.location.Start();
        }
    }

    private void UpdateLocation()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            _currentLocation.latitude = Input.location.lastData.latitude;
            _currentLocation.longitude = Input.location.lastData.longitude;
        }
    }

    private void Awake()
    {
        StartTraking();
    }

    private void Update()
    {
        UpdateLocation();
    }
}
