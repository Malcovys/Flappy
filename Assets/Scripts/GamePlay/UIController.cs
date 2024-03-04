using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public CanvasGroup MainMenu;
    public CanvasGroup GamePlay;
    public CanvasGroup GameOverMenu;

    public Text scoreText;

    public GameObject startGameUI;

    public GameObject restartGame;
    public GameObject returnHome;
    public GameObject gameOverPanel;
    public Text gameOverScoreText;
    public Text GameOverHightScoreText;

    void Awake()
    {
        Instance = this;

        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnGameEnded += OnGameEnded;
    }

    void Start()
    {
        MainMenu.alpha = 1;
        GamePlay.alpha = 0;
        GameOverMenu.alpha = 0;

        GameOverMenu.gameObject.SetActive(false);
        GamePlay.gameObject.SetActive(false);

        StarManager.Instance.EvalActiveStar();
    }

    void OnDestroy()
    {
        GameManager.OnGameStarted -= OnGameStarted;
        GameManager.OnGameEnded -= OnGameEnded;
    }

    void OnGameStarted()
    {
        MainMenu.DOFade(0, 0.2f).OnComplete(() => MainMenu.gameObject.SetActive(false));
        GamePlay.gameObject.SetActive(true);
        GamePlay.DOFade(1, 0.2f);
    }

    void OnGameEnded()
    {
        GamePlay.DOFade(0, 0.2f).OnComplete(() => GamePlay.gameObject.SetActive(false));
        GameOverMenu.gameObject.SetActive(true);

        gameOverScoreText.text = ScoreManager.Instance.score.ToString();
        GameOverHightScoreText.text = ScoreManager.Instance.hightScore.ToString();

        gameOverPanel.transform.localScale = Vector3.zero;
        restartGame.transform.localScale = Vector3.zero;
        returnHome.transform.localScale = Vector3.zero;

        GameOverMenu.DOFade(1, 0.4f).SetDelay(0.5f)
        .OnComplete(() => gameOverPanel.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack)
        .OnComplete(() => restartGame.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack)
        .OnComplete(() => returnHome.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack))));
    }

    public void UpdateScore(int scrore)
    {
        scoreText.text = scrore.ToString();
        scoreText.transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
    }

    public void TriggerStartGame()
    {
        startGameUI.SetActive(false);
        GameManager.Instance.StartGame();
    }
}
