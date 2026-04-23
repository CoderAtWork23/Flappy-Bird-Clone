using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TitlesStage
{
    public class TitleSceneManager : MonoBehaviour
    {
        [SerializeField] GameObject controls;
        [SerializeField] TMP_Text highScoreText;
        int _highScore;
        void Awake()
        {
            _highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = $"High Score: {_highScore}";
        }

        public void StartGame()
        {
            SceneManager.LoadScene("GameScreen");
        }

        public void ToggleControls()
        {
            controls.SetActive(!controls.activeSelf);
        }
    }
}
