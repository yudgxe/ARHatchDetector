using UnityEngine;

public class Drawer : MonoBehaviour
{
    public void DrowObject()
    {
        foreach(Hatch hatch in DistanceCalculate.hatches)
        {
            if(!hatch.isDrawed && hatch.toDrow)
            {
                hatch.isDrawed = true;
                //нарисовать
            }

            if(hatch.isDrawed && hatch.toDelete)
            {
                //удаляем
                hatch.isDrawed = false;
            }

        }
    }
    
}
