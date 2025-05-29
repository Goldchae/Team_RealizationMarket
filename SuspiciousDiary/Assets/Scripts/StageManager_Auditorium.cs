using System.Collections;
using UnityEngine;
using TMPro;


public class StageManager_Auditorium : MonoBehaviour
{
    public enum Stage
    {
        Start,
        AlertAppeared,
        DiaryAppeared,
        Complete
    }

    public Stage currentStage = Stage.Start;

    [Header("오브젝트")]
    public GameObject chapelClearAlert;
    public GameObject chapelFailAlert;
    public GameObject diary;
    public GameObject nextButton;
  
    [Header("대사")]
    public DialogueData Auditorium01;
    public DialogueData Auditorium02;
    public DialogueData Auditorium03;
    public DialogueData Auditorium04;


    public DialogueManager dialogueManager;

    void Start()
    {
        chapelClearAlert.SetActive(false);
        chapelFailAlert.SetActive(false);
        diary.SetActive(false);
    }

    private bool clicked = false;
    private bool isOnTime = true;

    public void OnClick_Next()
    {
        Debug.Log(currentStage);

        switch (currentStage)
        {
            case Stage.Start:
                if (isOnTime)
                {
                    chapelClearAlert.SetActive(true);
                    dialogueManager.StartDialogue(Auditorium01.lines);
                } else
                {
                    chapelFailAlert.SetActive(true);
                    dialogueManager.StartDialogue(Auditorium02.lines);
                }

                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                break;

            case Stage.AlertAppeared:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                } else
                {
                    dialogueManager.StartDialogue(Auditorium03.lines);
                    currentStage = Stage.DiaryAppeared;
                }
                break;

            case Stage.DiaryAppeared:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    dialogueManager.StartDialogue(Auditorium04.lines);
                    currentStage = Stage.Complete;
                }
                break;

            case Stage.Complete:
                break;
            default:
                break;
        }
    }

    public void OnClick_Alert()
    {
        if (clicked) return;

        clicked = true;

        chapelClearAlert.SetActive(false);
        chapelFailAlert.SetActive(false);
        diary.SetActive(true);
        currentStage = Stage.AlertAppeared;
        OnClick_Next();
    }

    public void OnClick_Diary()
    {
        if (!clicked) return;

        clicked = false;

        diary.SetActive(false);
        OnClick_Next();
    }

    public bool IsDialogueComplete()
    {
        return dialogueManager.IsDialogueComplete();
    }
}