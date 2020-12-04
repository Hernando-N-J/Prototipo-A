using UnityEngine;
using UnityEngine.UI;

public class TappyBirdGameManager : MonoBehaviour
{
    enum PageState { None, Start, GameOver, Countdown };

    public delegate void GameDelegate();
    public static event GameDelegate OnGameStartedEvent;
    public static event GameDelegate OnGameoverConfirmedEvent;

    public static TappyBirdGameManager Instance;

    public GameObject startPage;
    public GameObject gameoverPage;
    public GameObject countdownPage;
    public Text scoreText;

    private int score = 0;
    private bool isGameover = true;

    public int Score { get => score; }
    public bool IsGameover { get => isGameover; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        SetPageState(PageState.Start);
    }

    private void OnEnable()
    {
        CountdownText.OnCountdownFinishedEvent += OnCountdownFinishedMethod;
        TapController.OnPlayerScored += OnPlayerScoredMethod;
        TapController.OnPlayerDied += OnPlayerDiedMethod;
    }

    private void OnDisable()
    {
        CountdownText.OnCountdownFinishedEvent -= OnCountdownFinishedMethod;
        TapController.OnPlayerScored -= OnPlayerScoredMethod;
        TapController.OnPlayerDied -= OnPlayerDiedMethod;
    }

    private void OnCountdownFinishedMethod()
    {
        // what to do after countdown finishes?
        // deactivate pages
        // reset score
        // isGameOver to false => start the game (enable update code)
        SetPageState(PageState.None);
        OnGameStartedEvent();
        score = 0;
        isGameover = false;
    }

    private void OnPlayerScoredMethod()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void OnPlayerDiedMethod()
    {
        isGameover = true;
        int savedScore = PlayerPrefs.GetInt("HighScore");
        if (score > savedScore) PlayerPrefs.SetInt("HighScore", score);
        SetPageState(PageState.GameOver);
    }

    // activated when play button is pressed
    // show up countdown page and execute counter (OnEnable)
    public void StartGame()
    => SetPageState(PageState.Countdown);

    // activated when replay button is pressed
    public void GameOverConfirmedMethod()
    {
        OnGameoverConfirmedEvent();  // event sent to TapController
        scoreText.text = "Score " + "\n0"; // reset score
        SetPageState(PageState.Start); // show up start page
    }

    private void SetPageState(PageState pg)
    {
        switch (pg)
        {
            case PageState.None:
                startPage.SetActive(false);
                gameoverPage.SetActive(false);
                countdownPage.SetActive(false);
                break;

            case PageState.Start:
                startPage.SetActive(true);
                gameoverPage.SetActive(false);
                countdownPage.SetActive(false);
                break;

            case PageState.GameOver:
                startPage.SetActive(false);
                gameoverPage.SetActive(true);
                countdownPage.SetActive(false);
                break;

            case PageState.Countdown:
                startPage.SetActive(false);
                gameoverPage.SetActive(false);
                countdownPage.SetActive(true);
                break;
        }
    }
}
