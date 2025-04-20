using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khn_Pick_Controller : MonoBehaviour
{
    public GameObject UI;   // Step04 (UI 관련 스크립트를 갖고 있는 게임 오브젝트)

    // clickCounter의 값을 1씩 증가시키는 함수
    public void Add_Click(GameObject Clone)
    {
        int clickCounter = UI.GetComponent<khn_UI_Controller>().GetPickCounts();
        clickCounter++;
        print($"{clickCounter} 개의 클론을 클릭했습니다.");
        Destroy(Clone);

        // Step04 (UI에 내용을 표시하는 스크립트 호출)
        UI.GetComponent<khn_UI_Controller>().Display_PickCounts(clickCounter);
    }
}
