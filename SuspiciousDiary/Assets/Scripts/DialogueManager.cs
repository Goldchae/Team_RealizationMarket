using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    private List<string> currentLines;
    private int index;

    public void StartDialogue(List<string> lines)
    {
        currentLines = lines;

        if (currentLines != null && currentLines.Count > 0)
        {
            index = 0;
            dialogueText.text = currentLines[index]; 
        }
        else
        {
            dialogueText.text = "";
            index = 0;
        }
    }

    public void ShowNextLine()
    {
        index++; 
        if (currentLines != null && index < currentLines.Count)
        {
            dialogueText.text = currentLines[index];
        }
    }

    public bool IsDialogueComplete()
    {
        return currentLines == null || index >= currentLines.Count - 1;
       
    }
}
