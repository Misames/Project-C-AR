using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isPause;
    private Dictionary<int, GameObject> listPlayer = new Dictionary<int, GameObject>();
    [SerializeField] private TextMeshProUGUI timerUI;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject localRecord;
    [SerializeField] private GameObject liveRanking;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Start()
    {
        Debug.Log("scene start !");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause) Resume();
            else Pause();
        }
        timerUI.text = Mathf.Floor(Time.time / 60).ToString("00")
                     + ":" + Mathf.FloorToInt(Time.time % 60).ToString("00")
                     + "," + Mathf.FloorToInt((Time.time * 100) % 100).ToString("00");
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
