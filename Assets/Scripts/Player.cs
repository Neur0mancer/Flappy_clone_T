using UnityEngine;

public class Player : MonoBehaviour
{
    private const float AnimationInterval = 0.15f;

    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpPower;
    [SerializeField] private Sprite[] playerSprites; 

    private Vector3 direction;
    private SpriteRenderer spriteRenderer;
    private int spriteIndex;    

    private void Awake()
    {
        InitializeSpriteRenderer();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), AnimationInterval, AnimationInterval);
    }

    private void OnEnable()
    {
        ResetPosition();
    }

    private void Update()
    {        
        HandleInput();
        ApplyGravity();
        MovePlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
        else if (collision.CompareTag("Score"))
        {
            GameManager.Instance.IncreaseScore();
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0)))
        {
            direction = Vector3.up * jumpPower;
        }
    }

    private void ApplyGravity()
    {
        direction.y += gravity * Time.deltaTime;
    }

    private void MovePlayer()
    {
        transform.position += direction * Time.deltaTime;
    }

    private void ResetPosition()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        direction = Vector3.zero;
    }

    //Cycle through the player sprites to create animation
    private void AnimateSprite()
    {
        spriteIndex = (spriteIndex + 1) % playerSprites.Length;
        spriteRenderer.sprite = playerSprites[spriteIndex];
    }

    private void InitializeSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
