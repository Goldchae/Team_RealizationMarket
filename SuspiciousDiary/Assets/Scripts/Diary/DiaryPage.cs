using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DiaryPage {
    public int PageID;
    public string Date;
    public string Content;
}

[System.Serializable]
public class DiaryPageList {
    public DiaryPage[] pages;
}