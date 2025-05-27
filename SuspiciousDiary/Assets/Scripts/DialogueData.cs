using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Script/DialogueData")]
public class DialogueData : ScriptableObject
{
    public List<string> lines;
}