using UnityEngine;

public class PositionTerminator : MonoBehaviour
{
    private Matrix4x4 rotation;
    private Vector4 initialPose;

    private void WorldToLocal()
    {
        foreach(Hatch hatch in DistanceCalculate.hatches)
        {
            if (!hatch.isDrawed)
            {
                //посчитать позицию hatch
                rotation = MathMatrix.RotateAroundY(GPSTraker.angleToNorth);
                initialPose = new Vector4(0f, 0f, hatch.distance, 1f);

                hatch.position = MathMatrix.TransformMatrix(GPSTraker.currentlocation, hatch.location, rotation * initialPose);
                hatch.toDrow = true;
            }
        }
    }

    private void Update()
    {
        WorldToLocal();
    }
}
