using System.Collections;
using UnityEngine;
using TMPro;

public class StageManager_Library : MonoBehaviour
{
    public enum Stage
    {
        Start,
        ArSceneAppeared,
        DiaryDisappeared,
        Complete
    }

    public Stage currentStage = Stage.Start;

    [Header("오브젝트")]
    public GameObject diaryScene;
    public GameObject arScene;
    public GameObject minigameScene;
    public GameObject instruction;
    public GameObject nextButton;

    public GameObject ImageTarget_arScene;
    public GameObject ImageTarget_minigameScene;

    public GameObject everytimeButton;
    public GameObject timebox;
    public GameObject nobattery;
    public GameObject yesbattery;

    public TextMeshProUGUI sec;

    [Header("대사")]
    public DialogueData Auditorium01;
    public DialogueData Auditorium02;

    public DialogueManager dialogueManager;

    private bool clicked = false;
    private bool dialogueStarted = false;
    private Coroutine timerCoroutine;

    void Start()
    {
        diaryScene.SetActive(false);
        arScene.SetActive(false);
        ImageTarget_minigameScene.SetActive(false);
        everytimeButton.SetActive(false);
        timebox.SetActive(false);
        nobattery.SetActive(false);
        yesbattery.SetActive(false);
        sec.text = "";
    }

    public void OnClick_Next()
    {
        Debug.Log(currentStage);

        switch (currentStage)
        {
            case Stage.Start:
                if (!dialogueStarted)
                {
                    dialogueManager.StartDialogue(Auditorium01.lines);
                    dialogueStarted = true;
                    nobattery.SetActive(true);
                }
                else if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    currentStage = Stage.ArSceneAppeared;
                    ArSceneAppeared_start();

                    dialogueStarted = false;
                    nobattery.SetActive(false);
                }
                break;

            case Stage.DiaryDisappeared:
                if (!dialogueStarted)
                {
                    dialogueManager.StartDialogue(Auditorium02.lines);
                    dialogueStarted = true;
                    yesbattery.SetActive(true);
                }
                else if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    currentStage = Stage.Complete;

                    dialogueStarted = false;
                    everytimeButton.SetActive(true);
                    yesbattery.SetActive(false);
                }
                break;

            case Stage.Complete:
                break;
        }
    }

    public void ArSceneAppeared_start()
    {
        arScene.SetActive(true);
        instruction.SetActive(false);
        nextButton.SetActive(false);
    }

    public void minigameSceneAppeared_start()
    {
        minigameScene.SetActive(true);
        timebox.SetActive(true);
        instruction.SetActive(false);
        nextButton.SetActive(false);
        everytimeButton.SetActive(false);

        ImageTarget_minigameScene.SetActive(true);
        ImageTarget_arScene.SetActive(false);

        // 타이머 시작
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = StartCoroutine(CountdownTimer(444));
    }

    private IEnumerator CountdownTimer(int seconds)
    {
        int timeLeft = seconds;
        while (timeLeft > 0)
        {
            sec.text = timeLeft.ToString(); // 또는 Format MM:SS 원하면 여기 수정
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        sec.text = "0";

        // 타이머 종료 후 처리 추가 (예: 실패 UI 띄우기)
        Debug.Log("⏰ 타이머 종료!");
    }

    public void OnClick_Diary()
    {
        diaryScene.SetActive(false);
        instruction.SetActive(true);
        nextButton.SetActive(true);
        currentStage = Stage.DiaryDisappeared;
        OnClick_Next();
    }

    public bool IsDialogueComplete()
    {
        return dialogueManager.IsDialogueComplete();
    }
}