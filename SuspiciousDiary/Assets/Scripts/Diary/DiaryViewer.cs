using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DiaryViewer : MonoBehaviour
{
    public GameObject diaryPanel; 
    public TMP_Text dateText;
    public TMP_Text contentText;

    public int startPageID = 1;
    public bool autoShow = false;

    private Dictionary<int, DiaryPage> pageDict;
    private Coroutine typingCoroutine;

    void Start()
    {
        if (diaryPanel != null)
            diaryPanel.SetActive(false); 

        LoadDiary();

        if (autoShow)
        {
            ShowPage(startPageID); 
        }
    }

    void LoadDiary()
    {
        TextAsset json = Resources.Load<TextAsset>("DiaryContents");
        DiaryPage[] pages = JsonParser.FromJson<DiaryPage>(json.text);
        pageDict = new Dictionary<int, DiaryPage>();
        foreach (var page in pages)
        {
            pageDict[page.PageID] = page;
        }
    }

    public void ShowPage(int id)
    {
        if (pageDict != null && pageDict.ContainsKey(id))
        {
            if (diaryPanel != null)
                diaryPanel.SetActive(true);

            DiaryPage page = pageDict[id];
            dateText.text = page.Date;

            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeText(page.Content));
        }
    }

    public void CloseDiary()
    {
        if (diaryPanel != null)
            diaryPanel.SetActive(false);
    }

    private IEnumerator TypeText(string fullText)
    {
        contentText.text = "";

        int i = 0;
        while (i < fullText.Length)
        {
            if (fullText[i] == '<')
            {
                int tagEnd = fullText.IndexOf('>', i);
                if (tagEnd != -1)
                {
                    string tag = fullText.Substring(i, tagEnd - i + 1);
                    contentText.text += tag;
                    i = tagEnd + 1;
                    continue;
                }
            }

            contentText.text += fullText[i];
            i++;
            yield return new WaitForSeconds(0.05f); 
        }
    }
}