using UnityEngine;
using UnityEngine.UI;

public class FallingCubeCounterUI : MonoBehaviour
{
    [SerializeField] private Text counterText;
    private int count;

    public void OnCubeDestroyed()
    {
        if (counterText.color.a == 0)
        {
            counterText.color = new Color(1, 0, 0, 1);
        }
        count++;
        counterText.text = "Кубов уничтожено: " + count;
    }
}
