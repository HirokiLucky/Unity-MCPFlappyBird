using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private TextMeshProUGUI finalScoreText;
        [SerializeField] private float scoreIncreaseInterval = 1f;

        private int currentScore = 0;
        private float scoreTimer;
        public bool IsGameOver { get; private set; }

        private void Awake()
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

        private void Start()
        {
            IsGameOver = false;
            gameOverPanel.SetActive(false);
            UpdateScoreText();
        }

        private void Update()
        {
            if (!IsGameOver)
            {
                scoreTimer += Time.deltaTime;
                if (scoreTimer >= scoreIncreaseInterval)
                {
                    AddScore();
                    scoreTimer = 0;
                }
            }
        }

        private void AddScore()
        {
            currentScore++;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            if (scoreText != null)
            {
                scoreText.text = $"Score: {currentScore}";
            }
        }

        public void GameOver()
        {
            IsGameOver = true;
            gameOverPanel.SetActive(true);
            if (finalScoreText != null)
            {
                finalScoreText.text = $"Final Score: {currentScore}";
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}