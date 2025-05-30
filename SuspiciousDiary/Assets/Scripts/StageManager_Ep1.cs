using System.Collections;
using UnityEngine;
using TMPro;


public class StageManager_Ep1 : MonoBehaviour
{
    public enum Stage
    {
        KeyAppeared,
        DiaryOpen,
        TicketPut,
        Complete
    }

    public Stage currentStage = Stage.KeyAppeared;
    public DiaryViewer diaryViewer;

    [Header("오브젝트")]
    public GameObject key;
    public GameObject blankDiary;
    public GameObject blankTiket;
    public GameObject tiket;
    public GameObject nextButton;

    [Header("대사")]
    public DialogueData Ep1_1;
    public DialogueData Ep1_2;
    public DialogueData Ep1_3;
    public DialogueData Ep1_4;



    public DialogueManager dialogueManager;

    void Start()
    {
        tiket.SetActive(false);
        blankDiary.SetActive(false);
        blankTiket.SetActive(false);
        dialogueManager.StartDialogue(Ep1_1.lines);
    }

    private bool keyClickAllowed = false;
    private bool blankTiketClickAllowed = false;
    private int i = 0;
    

    public void OnClick_Next()
    {
        Debug.Log(currentStage);

        switch (currentStage)
        {
            case Stage.KeyAppeared:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                    keyClickAllowed = true;
                }
                break;


            case Stage.DiaryOpen:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    diaryViewer.ShowPage(1);
                    blankDiary.SetActive(false);
                    currentStage = Stage.TicketPut;
                    dialogueManager.StartDialogue(Ep1_3.lines);
                }
                break;

            case Stage.TicketPut:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();

                    i += 1;
                    if(i==2) blankTiketClickAllowed = true;
                }
                break;

            case Stage.Complete:
                if (!dialogueManager.IsDialogueComplete())
                {
                    dialogueManager.ShowNextLine();
                }
                else
                {
                    //다음 에피소드로 이동
                }
                break;
            default:
                break;
        }
    }

    public void OnClick_Key()
    {
        if (!keyClickAllowed) return;

        key.SetActive(false);
        blankDiary.SetActive(true);
        blankTiket.SetActive(true);
        currentStage = Stage.DiaryOpen;
        dialogueManager.StartDialogue(Ep1_2.lines);
    }

    public void OnClick_BlankTiket()
    {
        if (!blankTiketClickAllowed) return;

        blankTiket.SetActive(false);
        tiket.SetActive(true);
        dialogueManager.StartDialogue(Ep1_4.lines);
        currentStage = Stage.Complete;
    }


    public bool IsDialogueComplete()
    {
        return dialogueManager.IsDialogueComplete();
    }
}