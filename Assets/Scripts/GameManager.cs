using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private float timer;
    private bool isPause;
    private Dictionary<int, GameObject> listPlayer = new Dictionary<int, GameObject>();
    [SerializeField] private TextMeshProUGUI timerUI;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject localRecord;
    [SerializeField] private GameObject liveRanking;

    void Start()
    {
        Debug.Log("scene start !");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause) Resume();
            else Pause();
        }

        timerUI.text = timer.ToString();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPause = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPause = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
