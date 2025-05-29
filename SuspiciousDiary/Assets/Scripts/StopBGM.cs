using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBGM : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;
    void Start()
    {
        audioSource.Stop();
    }
}
