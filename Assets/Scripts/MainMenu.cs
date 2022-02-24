using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] GameObject MenuOption;
    [SerializeField] GameObject GameMode;
    [SerializeField] GameObject PopupQuit;

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
}
