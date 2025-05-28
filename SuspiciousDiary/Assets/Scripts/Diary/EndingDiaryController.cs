using UnityEngine;
using System.Collections;
using TMPro;

public class EndingDiaryController : MonoBehaviour
{
    public GameObject diaryPanel;
    public TMP_Text dateText;
    public TMP_Text contentText;

    public int pageToShow = 2;

    private DiaryPage[] pages;

    private Coroutine typingCoroutine;


    private void Start()
    {
        diaryPanel.SetActive(false);
        LoadDiaryData();
    }

    public void ShowPage(int pageNumber)
    {
        pageToShow = pageNumber;
        ShowEndingDiary();
    }

    private void LoadDiaryData()
    {
        TextAsset json = Resources.Load<TextAsset>("DiaryContents");
        pages = JsonParser.FromJson<DiaryPage>(json.text);
    }

    public void ShowEndingDiary()
    {
        if (pages == null || pages.Length == 0) return;

        DiaryPage page = System.Array.Find(pages, p => p.PageID == pageToShow);
        if (page != null)
        {
            diaryPanel.SetActive(true);
            dateText.text = page.Date;

            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeText(page.Content));
        }
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
    public void CloseDiary()
    {
        diaryPanel.SetActive(false);       
    }

}