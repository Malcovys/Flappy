using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 200f;
    public float rotationSpeed = 3f;

    public Rigidbody2D rb;
    public Animator animator;

    bool isReady, isDead;

    void Awake()
    {
        GameManager.OnGameStarted += OnGameStarted;
    }

    void Start()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnDestroy()
    {
        GameManager.OnGameStarted -= OnGameStarted;
    }

    void OnGameStarted()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        isReady = true;
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce);

        AudioManager.Instance.PlaySound(AudioType.Wing, AudioSourceType.Player);
    }

    void Update()
    {
        if(isReady && !isDead)
        {
            float angle;
            float rotSpeed = rotationSpeed;

            if(rb.velocity.y < -2)
            {
                angle = Mathf.Lerp(-90, 90, rb.velocity.y);
            }
            else
            {
                angle = 20;
                rotSpeed *= 3;
            }

            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotSpeed);

            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);
                AudioManager.Instance.PlaySound(AudioType.Wing, AudioSourceType.Player);
            }

            if(transform.position.y > 6.4)
            {
                Die();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        AudioManager.Instance.PlaySound(AudioType.Hit, AudioSourceType.Player);
        Die();
    }

    void Die()
    {
        if(isDead)
            return;
        isDead = true;
        animator.speed = 0;
        AudioManager.Instance.PlaySound(AudioType.Die, AudioSourceType.Player);
        transform.DORotate(new Vector3(0, 0, -90), 0.5f);
        GameManager.Instance.GameOver();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Pipe"))
        {
            ScoreManager.Instance.AddScore();
        }
    }
}
