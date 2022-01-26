using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text maxScoreText;
    private int currentScore;

    private void Start()
    {
        maxScoreText.text = "BEST: " + (int)Player.Instance.MaxScore;
    }

    private void Update()
    {
        currentScore = (int)Player.Instance.CurrentScore;
        scoreText.text = currentScore.ToString();
    }
}
