using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    static public event Action OnGameStarted;
    static public event Action OnGameEnded;

    public enum GameState
    {
        MainMenu,
        InGame,
        GameOver
    }

    public float speedPipe;
    public float numberPipes;
    public float distanceBetwinPipe;

    public Pipe pipePrefab;

    public GameState currentState;

    public Transform pipeSponePoint;

    void Awake()
    {
        Instance = this;

        Application.targetFrameRate = 60;
    }

    void Start()
    {
        currentState = GameState.MainMenu;

        for(int i = 0; i < numberPipes; i++)
        {
            Pipe pipe = Instantiate(pipePrefab, pipeSponePoint.position + new Vector3(i * distanceBetwinPipe, 0, 0), Quaternion.identity);
        }
    }

    public void StartGame()
    {
        currentState = GameState.InGame;
        OnGameStarted?.Invoke();
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        CameraController.Instance.Shake(strenght: 0.3f, duration: 0.25f);
        OnGameEnded?.Invoke();
    }

    public void RestartGame()
    {
        TransitionManager.Instance.DoTransiton(SceneManager.GetActiveScene().buildIndex, 0.3f);
    }

    public void ReturnToHome()
    {
        TransitionManager.Instance.DoTransiton((int)Scene.MainScene, 0.3f);
    }
}
