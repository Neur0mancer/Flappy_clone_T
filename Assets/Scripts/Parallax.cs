using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed = 1f;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        InitializeMeshRenderer();
    }

    private void Update()
    {
        AppyParallaxEffect();
    }

    private void InitializeMeshRenderer()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void AppyParallaxEffect()
    {
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset.x += parallaxSpeed * Time.deltaTime;
        meshRenderer.material.mainTextureOffset = offset;
    }
}
