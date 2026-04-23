using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainStage.Stage
{
    public class LogicManager : MonoBehaviour
    {
        [SerializeField] int playerScore;
        [SerializeField] Text scoreText;
        [SerializeField] Text ballsRemainingText;
        public GameObject gameOverPanel;

        [ContextMenu("Increase Score")]
        public void AddScore(int score)
        {
            playerScore += score;
            scoreText.text = playerScore.ToString();
        }

        public void UpdateBalls(int num)
        {
            ballsRemainingText.text = num.ToString() + "/5";
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GameOver()
        {
            gameOverPanel.SetActive(true);
            if(playerScore > PlayerPrefs.GetInt("HighScore"))
                PlayerPrefs.SetInt("HighScore", playerScore);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }
}