using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CosmicCuration.UI
{
    public class UIView : MonoBehaviour
    {
        #region References
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private GameObject gameplayPanel;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Button playAgainButton;
        [SerializeField] private Button quitButton;
        #endregion

        #region Variables
        private int currentScore;
        #endregion

        private void Start()
        {
            currentScore = 0;
            IncrementScore(currentScore);
        }

        public void IncrementScore(int scoreToIncrement)
        {
            currentScore += scoreToIncrement;
            scoreText.SetText(currentScore.ToString());
        }

        public void UpdateHealthUI(int healthToDisplay) => healthText.SetText(healthToDisplay.ToString());

        public void EnableGameOverUI(float delay)
        {
            StartCoroutine(EnableGameOverUICorutine(delay));
        }

        private IEnumerator EnableGameOverUICorutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            gameplayPanel.SetActive(false);
            gameOverPanel.SetActive(true);
            playAgainButton.onClick.AddListener(OnPlayAgainClicked);
            quitButton.onClick.AddListener(OnQuitClicked);
        }

        private void OnPlayAgainClicked() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        private void OnQuitClicked() => Application.Quit();
    } 
}