using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    static public TransitionManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void DoTransiton(int sceneIndex, float duration)
    {
        StartCoroutine(PerformTransiton(sceneIndex, duration));
    }

    IEnumerator PerformTransiton(int sceneIndex, float duration)
    {
        AudioManager.Instance.PlaySound(AudioType.Swoosh, AudioSourceType.Game);
        yield return new WaitForSecondsRealtime(duration);
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
