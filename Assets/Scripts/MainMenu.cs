using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuiteGame(bool value)
    {
        if (value == true)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("FirstRun");
    }
}
