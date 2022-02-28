using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private CarSelection carSelector;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void QuiteGame(bool value)
    {
        if (value == true)
            Application.Quit();
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("IDCar", carSelector.GetIDCar());
        PlayerPrefs.Save();
        SceneManager.LoadScene("FirstRun");
    }
}
