using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculate : MonoBehaviour
{
    public static List<Hatch> hatches { get; private set; }
    public float raduis = 10;
    private float distance;

    private void ControlDraw()
    {
        foreach (Hatch hatch in JsonReader.hatches)
        {
            distance = MathLocation.CalculateDistance(GPSTraker.currentlocation, hatch.location);
            if (raduis >= distance && !hatch.isProcessed)
            {
                hatches.Add(hatch);
                hatches[hatches.Count - 1].distance = distance;
                hatches[hatches.Count - 1].isProcessed = true;
            }
        }
    }

    private void ControlDelete()
    {
        foreach (Hatch hatch in hatches)
        {
            if (raduis <= MathLocation.CalculateDistance(GPSTraker.currentlocation, hatch.location))
            {
                hatch.toDelete = true;
            }

            if (!hatch.isDrawed && hatch.toDelete)
            {
                hatch.isProcessed = false;
                hatches.Remove(hatch);
            }
        }
    }

    private void Awake()
    {
        hatches = new List<Hatch>();
    }

    private void Update()
    {
        ControlDraw();
        ControlDelete();
    }
}
