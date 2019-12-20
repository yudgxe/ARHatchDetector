using UnityEngine;

public class PositionTerminator
{
    private Matrix4x4 rotation;
    private Vector4 initialPose;

    public void CanculateDistance()
    {
        foreach(Hatch hatch in DistanceCalculate.hatches)
        {
            if (hatch.state == State.unDrawed)
            {
                rotation = MathMatrix.RotateAroundY(GPSTraker.angleToNorth);
                initialPose = new Vector4(0f, 0f, hatch.distance, 1f);

                hatch.position = MathMatrix.TransformMatrix(GPSTraker.currentlocation, hatch.location, rotation * initialPose);
            }
        }
    }
}
