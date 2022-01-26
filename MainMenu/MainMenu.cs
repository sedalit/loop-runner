using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    private float bestScore;

    private void Start()
    {
        Saver<float>.TryLoad("Saved game", ref bestScore);
        if (bestScore > 0)
        {
            bestScoreText.text = "Ваш рекорд: \n" + (int)bestScore + " м.";
        }
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(Exit);
    }
    private void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
        exitButton.onClick.RemoveListener(Exit);
    }
    public void StartGame()
    {
        startButton.GetComponentInChildren<Text>().color = Color.red;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
