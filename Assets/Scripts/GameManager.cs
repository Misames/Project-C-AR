using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Animator starterAnim;
    private bool isPause;
    private float gameTime;
    private bool gameState = false;
    private int lapMake;
    private int IDCar;
    public int IDMap;
    private string nickname = "joueur1";
    [SerializeField] private int lapNumber = 3;
    [SerializeField] private TextMeshProUGUI timerUI;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject liveRanking;
    [SerializeField] private TextMeshProUGUI liveLap;
    [SerializeField] private GameObject carPlayer;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Start()
    {
        IDCar = PlayerPrefs.GetInt("IDCar");
        Screen.autorotateToLandscapeLeft = true;
        lapMake = 0;
        gameTime = 0.0f;
        gameState = false;
        isPause = false;
        liveLap.text = lapMake + " / " + lapNumber;
        liveRanking.SetActive(false);
        carPlayer.GetComponent<CarController>().enabled = false;
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

        if (Input.GetKey(KeyCode.A))
            Restart();
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

    public void LapPassed()
    {
        lapMake++;
        liveLap.text = lapMake + " / " + lapNumber;
    }

    private void SaveGame()
    {
        PlayerPrefs.SetFloat("time", this.gameTime);
        PlayerPrefs.SetString("nickname", this.nickname);
        PlayerPrefs.SetInt("map", this.IDMap);
        PlayerPrefs.Save();
        Time.timeScale = 0f;
        // Afficher menu de fin
    }

    public void StartCount()
    {
        carPlayer.GetComponent<CarController>().enabled = false;
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        starterAnim.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(3);
        gameState = true;
        carPlayer.GetComponent<CarController>().enabled = true;
    }
}
