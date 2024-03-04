using UnityEngine;

public class Pipe : MonoBehaviour
{
    float speed;
    float distanceBetwinPipes;
    float numberPipes;

    float startPositionY;

    public Collider2D[] colliders;

    void Start()
    {
        GameManager.OnGameEnded += OnGameEnded;
        speed = GameManager.Instance.speedPipe;
        numberPipes = GameManager.Instance.numberPipes;
        distanceBetwinPipes = GameManager.Instance.distanceBetwinPipe;

        startPositionY = transform.position.y;
        transform.position = new Vector3(transform.position.x, startPositionY + Random.Range(-2,2), transform.position.z);
    }

    void OnDestroy()
    {
        GameManager.OnGameEnded -= OnGameEnded;
    }

    void OnGameEnded()
    {
        foreach (var item in colliders)
        {
            item.enabled = false;
        }
    }

    void Update()
    {
        if(GameManager.Instance.currentState == GameManager.GameState.InGame)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    public void UpdatePosition()
    {
        transform.position = new Vector3(transform.position.x + distanceBetwinPipes * numberPipes, startPositionY, transform.position.z);
        transform.position = new Vector3(transform.position.x, startPositionY + Random.Range(-2,2), transform.position.z);
    }
}
