using UnityEngine;

public class Hatch : MonoBehaviour
{
    public bool isDrawed = false;
    public bool toDelete = false;
    public bool isProcessed = false;
    public bool toDrow = false;

    public float distance;
    public GPSLocation location;
    public Vector3 position;
    public string description;
    public Hatch model;
}