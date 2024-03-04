using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomeUIController : MonoBehaviour
{
    [Header("Player")]
    public Text HighScoreValue;

    [Header("Flappy")]
    public Rigidbody2D birdBody;
    public float birdJumpForce = 350f;
    private bool isReady;
    private float initialPosY;

    void Awake()
    {
        birdBody.bodyType = RigidbodyType2D.Kinematic;

        HomeManager.OnHomeLoaded += OnHomeLoaded;
        ScoreManager.OnHighScoreReady += OnHighScoreReady;
    }

    void OnDestroy()
    {
        HomeManager.OnHomeLoaded -= OnHomeLoaded;
        ScoreManager.OnHighScoreReady -= OnHighScoreReady;
    }

    void OnHomeLoaded()
    {
        initialPosY = birdBody.position.y;

        birdBody.bodyType = RigidbodyType2D.Dynamic;
        isReady = true;
    }

    void OnHighScoreReady()
    {
        StartCoroutine(SetHighScore(ScoreManager.Instance.hightScore, 0.1f));
    }

    void FixedUpdate()
    {
        if(isReady)
        {
            DoFlap(birdBody, initialPosY, birdJumpForce);
        }
    }   

    IEnumerator SetHighScore(int hightScore, float interval)
    {
        for(int i=0; i <= hightScore; i++)
        {
            HighScoreValue.text = i.ToString();
            yield return new WaitForSeconds(interval);
        }

        StarManager.Instance.EvalActiveStar();
    }

    void DoFlap(Rigidbody2D body,float initialPosY, float force)
    {
        body.velocity = Vector2.zero;

        if(body.position.y <= initialPosY)
        {
            birdBody.AddForce(Vector2.up * force);
        }
    }
}
