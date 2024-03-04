using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float backgroundSpeed = 0.2f;
    private float spriteSize;

    public SpriteRenderer backgroundSprite; 

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        spriteSize = backgroundSprite.sprite.bounds.size.x * backgroundSprite.transform.localScale.x; 
    }

    void Update()
    {
        if(GameManager.Instance.currentState != GameManager.GameState.GameOver)
        {
            float newPositon = Mathf.Repeat(Time.time * backgroundSpeed, spriteSize);
            transform.position = startPosition + Vector3.left * newPositon;
        }
        
    }
}
