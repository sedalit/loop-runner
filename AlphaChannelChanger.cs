using UnityEngine;
using DG.Tweening;

public class AlphaChannelChanger : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    private MeshRenderer[] meshRenderers;

    private void OnEnable()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.material.DOFade(0, duration).From();
        }
    }
}
