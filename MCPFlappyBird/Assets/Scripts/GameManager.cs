using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private TMPro.TextMeshProUGUI scoreText;
        [SerializeField] private TMPro.TextMeshProUGUI highScoreText;

        private int score = 0;
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
            score = 0;
            UpdateScoreText();
            if (gameOverPanel != null)
                gameOverPanel.SetActive(false);
        }

        public void AddScore()
        {
            if (IsGameOver) return;
            score++;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            if (scoreText != null)
                scoreText.text = $"Score: {score}";
        }

        public void GameOver()
        {
            IsGameOver = true;
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            if (score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScore = score;
            }

            if (highScoreText != null)
                highScoreText.text = $"High Score: {highScore}";
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}