using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ARSessionOrigin))]
public class Drawer : MonoBehaviour
{
    private ARSessionOrigin m_SessionOrigin;

    [SerializeField]
    private GameObject arCamera;

    public void DrowObject()
    {
        for (int i = 0; i < DistanceCalculate.hatches.Count - 1; i++)
        {
            if (!DistanceCalculate.hatches[i].isDrawed && DistanceCalculate.hatches[i].toDrow)
            {
                DistanceCalculate.hatches[i].isDrawed = true;
                DistanceCalculate.hatches[i] = Instantiate(DistanceCalculate.hatches[i].model, Vector3.zero, Quaternion.identity);
                m_SessionOrigin.MakeContentAppearAt(DistanceCalculate.hatches[i].model.transform, arCamera.transform.position, Quaternion.identity);
                m_SessionOrigin.MakeContentAppearAt(DistanceCalculate.hatches[i].model.transform, DistanceCalculate.hatches[i].position, Quaternion.identity);
            }

            if (DistanceCalculate.hatches[i].isDrawed && DistanceCalculate.hatches[i].toDelete)
            {
                Destroy(DistanceCalculate.hatches[i].gameObject);
                DistanceCalculate.hatches[i].isDrawed = false;
            }
        }
    }

    private void Awake()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
    }
}
