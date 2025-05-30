using System.Collections;
using UnityEngine;
using TMPro;


public class StageManager_AsanEngineering : MonoBehaviour
{
    public enum Stage
    {
        Start,
        YeonwhaAppeared,
        YeonwhaCameCloser,
        YeonwhaAskedLunch,
        HalfComplete,
        AtRestaurant,
        AfterDiary,
        AfterRestaurant,
        AtAlert,
        Complete
    }

    public Stage currentStage = Stage.Start;

    [Header("오브젝트")]
    public GameObject yeonwha1;
    public GameObject yeonwha2;
    public GameObject yeonwha3;
    public GameObject yeonwha4;
    public GameObject yeonwha5;
    public GameObject alert;
    public GameObject midOutro;
    public GameObject outro;
    public GameObject instruction;
    public GameObject nextButton;
  
    [Header("대사")]
    public DialogueData AsanEngineering01;
    public DialogueData AsanEngineering02;
    public DialogueData AsanEngineering03;
    public DialogueData AsanEngineering04;
    public DialogueData AsanEngineering05;
    public DialogueData AsanEngineering06;
    public DialogueData AsanEngineering07;
    public DialogueData AsanEngineering08;

    public DialogueManager dialogueManager;

    private bool isHalfdone = false;
    void Start()
    {
        yeonwha1.SetActive(false);
        yeonwha2.SetActive(false);
        yeonwha3.SetActive(false);
        yeonwha4.SetActive(false);
        yeonwha5.SetActive(false);
        alert.SetActive(false);
        midOutro.SetActive(false);
        outro.SetActive(false);
    }

    private void Update()
    {
        if (isHalfdone)
        {
            OnClick_Next();
        }
    }

    public void OnClick_Next()
    {
        Debug.Log(currentStage);

        switch (currentStage)
        {
            case Stage.Start:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                } else
                {
                    dialogueManager.StartDialogue(AsanEngineering01.lines);
                    currentStage = Stage.YeonwhaAppeared;
                }
                break;

            case Stage.YeonwhaAppeared:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                } else
                {
                    yeonwha1.SetActive(true);
                    dialogueManager.StartDialogue(AsanEngineering02.lines);
                    currentStage = Stage.YeonwhaCameCloser;
                }
                break;

            case Stage.YeonwhaCameCloser:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    yeonwha1.SetActive(false);
                    yeonwha2.SetActive(true);
                    dialogueManager.StartDialogue(AsanEngineering03.lines);
                    currentStage = Stage.YeonwhaAskedLunch;
                }
                break;

            case Stage.YeonwhaAskedLunch:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    yeonwha2.SetActive(false);
                    yeonwha3.SetActive(true);
                    dialogueManager.StartDialogue(AsanEngineering04.lines);
                    currentStage = Stage.HalfComplete;
                }
                break;

            case Stage.HalfComplete:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    midOutro.SetActive(true);
                    yeonwha3.SetActive(false);
                    instruction.SetActive(false);
                    currentStage = Stage.AtRestaurant;
                    isHalfdone = true;
                }
                break;

            case Stage.AtRestaurant:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    isHalfdone = false;
                    instruction.SetActive(true);
                    yeonwha2.SetActive(true);
                    dialogueManager.StartDialogue(AsanEngineering05.lines);
                    currentStage = Stage.AfterDiary;
                }
                break;

            case Stage.AfterDiary:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    yeonwha2.SetActive(false);
                    yeonwha4.SetActive(true);
                    dialogueManager.StartDialogue(AsanEngineering06.lines);
                    currentStage = Stage.AfterRestaurant;
                }
                break;

            case Stage.AfterRestaurant:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    yeonwha4.SetActive(false);
                    yeonwha5.SetActive(true);
                    dialogueManager.StartDialogue(AsanEngineering07.lines);
                    currentStage = Stage.AtAlert;
                }
                break;

            case Stage.AtAlert:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    alert.SetActive(true);
                    dialogueManager.StartDialogue(AsanEngineering08.lines);
                    currentStage = Stage.Complete;
                }
                break;

            case Stage.Complete:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    outro.SetActive(true);
                    instruction.SetActive(false);
                }
                break;

            default:
                break;
        }
    }

    public bool IsDialogueComplete()
    {
        return dialogueManager.IsDialogueComplete();
    }
}