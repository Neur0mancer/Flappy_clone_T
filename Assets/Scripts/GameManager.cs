using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject player;

    public static GameManager Instance { get; private set; }

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        InitializeSingletone();
        playButton.onClick.AddListener(Play);
        Pause();
    }

    private void Start()
    {        
        ResetScore();
    }
    private void InitializeSingletone()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Resetting game state and starting the game
    private void Play()
    {
        ResetScore();
        UpdateScoreText();
        playButton.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);        
        player.SetActive(true);
        DestroyAllPipes();
        Time.timeScale = 1;
    }

    private void Pause()
    {
        Time.timeScale = 0;
        player.SetActive(false);
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOverPanel.SetActive(true);
        playButton.gameObject.SetActive(true);
        Pause();
    }

    private void ResetScore()
    {
        score = 0;
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    private void DestroyAllPipes()
    {
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach(var pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }        
    }
}
