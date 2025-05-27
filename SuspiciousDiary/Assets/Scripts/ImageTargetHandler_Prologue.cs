using UnityEngine;
using Vuforia;

public class ImageTargetHandler_Prologue : MonoBehaviour
{
    public GameObject stage0;
    public GameObject stage1;

    private ObserverBehaviour observer;
    private bool hasSwitched = false;  

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnStatusChanged;
        }
    }

    private void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (hasSwitched) return;  

        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            stage0.SetActive(false);
            stage1.SetActive(true);
            hasSwitched = true; 
        }
    }

    void OnDestroy()
    {
        if (observer)
        {
            observer.OnTargetStatusChanged -= OnStatusChanged;
        }
    }
}
