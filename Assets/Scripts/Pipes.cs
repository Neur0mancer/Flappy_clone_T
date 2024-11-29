using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private float pipeDestroyerX;
    private float pipeDestroyOffset = 1f;

    private void Start()
    {
        SetPipeDestroyerX();
    }

    private void Update()
    {
        MovePipe();
        CheckForDestruction();
    }

    // Destroy the pipe when it moves off the left side of the screen, with an offset to hide its disappearance.
    private void SetPipeDestroyerX()
    {
        pipeDestroyerX = Camera.main.ScreenToWorldPoint(Vector3.zero).x - pipeDestroyOffset;
    }

    private void MovePipe()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void CheckForDestruction()
    {
        if (transform.position.x < pipeDestroyerX)
        {
            Destroy(gameObject);
        }
    }
}
