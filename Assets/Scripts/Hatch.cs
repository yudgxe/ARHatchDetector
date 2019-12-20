using UnityEngine;

public class Hatch : MonoBehaviour
{
    public State state = State.unDrawed;
    public Vector3 position;

    public float distance;
    public GPSLocation location;
    public string description;
    public Hatch model;
}