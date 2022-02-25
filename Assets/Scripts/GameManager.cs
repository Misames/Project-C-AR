using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isPause;
    private float gameTime;
    private bool gameState;
    private int lapMake;
    private int playerPosition;
    private int numberPlayer = 12;
    [SerializeField] private int lapNumber = 3;
    [SerializeField] private int countDown = 3;
    [SerializeField] private GameObject myPlayer;
    private Dictionary<int, GameObject> listPlayer = new Dictionary<int, GameObject>();
    [SerializeField] private TextMeshProUGUI timerUI;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject liveRanking;
    [SerializeField] private TextMeshProUGUI playerPositionRanking;
    [SerializeField] private TextMeshProUGUI liveLap;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Start()
    {
        Screen.autorotateToLandscapeLeft = true;
        lapMake = 0;
        gameTime = 0.0f;
        gameState = false;
        isPause = false;
        playerPosition = 1;
        playerPositionRanking.text = playerPosition + " / " + numberPlayer;
        liveLap.text = lapMake + " / " + lapNumber;
        listPlayer.Add(0, myPlayer);
    }

    private void Update()
    {
        if (lapMake > lapNumber)
        {
            gameState = false;
            SaveGame();
        }

        if (gameState == true)
        {
            gameTime += Time.deltaTime;
            timerUI.text = gameTime.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause) Resume();
            else Pause();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
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

    public void Play()
    {
        gameState = true;
    }

    private void LapPassed()
    {
        lapMake++;
    }

    private void SaveGame()
    {
        // save la partie
        // on save quand tous les joueurs sont arrivaient
        // et si ils ont pas fini 30 secondes après le premier la game se fini
    }
}
