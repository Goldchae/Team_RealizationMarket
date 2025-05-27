using System.Collections;
using UnityEngine;
using TMPro;


public class StageManager : MonoBehaviour
{
    public enum Stage
    {
        Start,
        DiaryAppeared,
        DiaryPicked,
        TicketAppeared,
        TicketPicked,
        Complete
    }

    public Stage currentStage = Stage.Start;

    [Header("오브젝트")]
    public GameObject diary;
    public GameObject diary2;
    public GameObject diary3;
    public GameObject ticket;
    public GameObject ticket2;
    public GameObject nextButton;
  
    [Header("대사")]
    public DialogueData Prologue01;
    public DialogueData Prologue02;
    public DialogueData Prologue03;
    public DialogueData Prologue04;
    public DialogueData Prologue05;



    public DialogueManager dialogueManager;

    void Start()
    {
        diary.SetActive(false);
        diary2.SetActive(false);
        diary3.SetActive(false);
        ticket.SetActive(false);
        ticket2.SetActive(false);
    }

    private bool initialized = false;
    private bool clicked = false;

    public void OnClick_Next()
    {
        Debug.Log(currentStage);

        switch (currentStage)
        {
            case Stage.Start:
                if (!initialized)
                {
                    diary.SetActive(true);
                    dialogueManager.StartDialogue(Prologue01.lines);
                    initialized = true;
                }

                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                break;


            case Stage.DiaryAppeared:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    diary2.SetActive(false);
                    diary3.SetActive(true);
                    dialogueManager.StartDialogue(Prologue03.lines);
                    currentStage = Stage.DiaryPicked;
                }
                break;

            case Stage.DiaryPicked:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    currentStage = Stage.TicketAppeared;
                    dialogueManager.StartDialogue(Prologue04.lines);
                    ticket.SetActive(true);
                }
                break;

            case Stage.TicketAppeared:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    currentStage = Stage.TicketPicked;
                }
                break;

            case Stage.TicketPicked:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    currentStage = Stage.Complete;
                }
                break;

            case Stage.Complete:
                break;
            default:
                break;
        }
    }

    public void OnClick_Diary()
    {
        if (clicked) return;

        clicked = true;

        diary.SetActive(false);
        diary2.SetActive(true);
        currentStage = Stage.DiaryAppeared;
        dialogueManager.StartDialogue(Prologue02.lines);
    }

    public void OnClick_Ticket()
    {
        diary3.SetActive(false);
        ticket.SetActive(false);
        ticket2.SetActive(true);
        dialogueManager.StartDialogue(Prologue05.lines);
        currentStage = Stage.TicketPicked;
    }

    public void OnClick_Diary2()
    {
        if (currentStage == Stage.DiaryAppeared)
        {
            diary2.SetActive(false);
            diary3.SetActive(true);
            dialogueManager.StartDialogue(Prologue03.lines);
            currentStage = Stage.DiaryPicked;
        }
    }

    public bool IsDialogueComplete()
    {
        return dialogueManager.IsDialogueComplete();
    }
}