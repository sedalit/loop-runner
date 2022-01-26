using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    private CanvasGroup gameOverGroup;

    private void Start()
    {
        gameOverGroup = GetComponent<CanvasGroup>();
        gameOverGroup.alpha = 0;
    }

    private void OnEnable()
    {
        player.Died += OnDied;
        restartButton.onClick.AddListener(OnRestarButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        player.Died -= OnDied;
        restartButton.onClick.RemoveListener(OnRestarButtonClick);
        exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnDied()
    {
        gameObject.SetActive(true);
        gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestarButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnExitButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
