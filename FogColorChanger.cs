using UnityEngine;

public class FogColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] allColors;

    private void Start()
    {
        int colorIndex = Random.Range(0, allColors.Length);
        RenderSettings.fogColor = allColors[colorIndex];
    }
}
