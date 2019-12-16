using UnityEngine;

public class PositionTerminator : MonoBehaviour
{
    private void WorldToLocal()
    {
        foreach(Hatch hatch in DistanceCalculate.hatches)
        {
            if (!hatch.isDrawed)
            {
                //посчитать позицию hatch
                hatch.toDrow = true;
            }
        }
    }

    private void Update()
    {
        WorldToLocal();
    }
}
