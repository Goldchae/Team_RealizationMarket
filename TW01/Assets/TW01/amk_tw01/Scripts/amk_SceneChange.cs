using UnityEngine;
using UnityEngine.SceneManagement;

public class amk_SceneChange : MonoBehaviour
{
    private string targetSceneName = "TW01_MainScene";

    private void OnTriggerEnter(Collider collider)
{
    if (collider.name == "FPSController") 
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
}