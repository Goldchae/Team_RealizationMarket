using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTargetHandler_Ep1_ECC : MonoBehaviour
{
    public GameObject stage1;
    public GameObject stage2;

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
            stage1.SetActive(false);
            stage2.SetActive(true);
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

