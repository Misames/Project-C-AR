using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Animator starterAnim;
    private int lapMake = 1;
    private float gameTime = 0f;
    private bool isPause = false;
    private bool gameState = false;
    private int IDCar = 0;
    public int IDMap = 0;
    private string nickname = "joueur1";
    [SerializeField] private int lapNumber = 3;
    [SerializeField] private TextMeshProUGUI timerUI;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject liveRanking;
    [SerializeField] private TextMeshProUGUI liveLap;
    [SerializeField] private GameObject carPlayer;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject[] listCar;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Start()
    {
        liveLap.text = lapMake + " / " + lapNumber;
        liveRanking.SetActive(false);
        carPlayer = listCar[IDCar];
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
            timerUI.text = Mathf.Floor(gameTime / 60).ToString("00")
                    + ":" + Mathf.FloorToInt(gameTime % 60).ToString("00")
                    + "," + Mathf.FloorToInt((gameTime * 100) % 100).ToString("00");

            if (Input.GetKey(KeyCode.A))
                Restart();
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

    public void LapPassed()
    {
        liveLap.text = lapMake + " / " + lapNumber;
        lapMake++;
    }

    private void SaveGame()
    {
        PlayerPrefs.SetFloat("time", this.gameTime);
        PlayerPrefs.SetString("nickname", this.nickname);
        PlayerPrefs.SetInt("map", this.IDMap);
        PlayerPrefs.SetInt("IDCar", this.IDCar);
        PlayerPrefs.Save();
        Time.timeScale = 0f;
        endPanel.SetActive(true);
        endPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Fin de la course en " + Mathf.Floor(gameTime / 60).ToString("00")
                    + ":" + Mathf.FloorToInt(gameTime % 60).ToString("00")
                    + "," + Mathf.FloorToInt((gameTime * 100) % 100).ToString("00");
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
