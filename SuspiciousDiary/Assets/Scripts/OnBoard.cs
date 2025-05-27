//챕터 시작화면 -> 스토리 시작 (터치로 인식)

using System.Collections;
using UnityEngine;
using TMPro;

public class OnBoard : MonoBehaviour
{
    public GameObject stage1;
    public GameObject stage2;

    private bool hasSwitched = false;

    void Update()
    {
        if (hasSwitched) return;

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            stage1.SetActive(false);
            stage2.SetActive(true);
            hasSwitched = true;
        }
    }
}
