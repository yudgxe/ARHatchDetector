using System.Collections.Generic;

public class DistanceCalculate
{
    public static List<Hatch> hatches { get; private set; }
    public float raduis = 10;
    private float distance;

    private void ControlDraw()
    {
        foreach (Hatch hatch in JsonReader.hatches)
        {
            distance = MathLocation.CalculateDistance(GPSTraker.currentlocation, hatch.location);
            if (raduis >= distance && hatch.state == State.unDrawed)
            {
                hatch.distance = distance;
                hatches.Add(hatch);
            }
        }
    }

    private void ControlDelete()
    {
        foreach (Hatch hatch in hatches)
        {
            if (raduis <= MathLocation.CalculateDistance(GPSTraker.currentlocation, hatch.location))
            {
                hatch.state = State.toErase;
            }

            if (hatch.state == State.toDelete)
            {
                hatch.state = State.unDrawed;
                hatches.Remove(hatch);
            }
        }
    }

    public void ControlDistance()
    {
        ControlDraw();
        ControlDelete();
    }
}
