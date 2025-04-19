using UnityEngine;
using UnityEngine.SceneManagement;

public class TW01_MainController : MonoBehaviour
{
    [SerializeField]
    private string targetSceneName;
    
    private void OnTriggerEnter(Collider collider)
{
    if (collider.name == "FPSController")
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
}