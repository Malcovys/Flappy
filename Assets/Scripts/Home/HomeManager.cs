using UnityEngine;
using System;

public class HomeManager : MonoBehaviour
{
    static public event Action OnHomeLoaded;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        OnHomeLoaded?.Invoke();
    }

    public void Play()
    {
        TransitionManager.Instance.DoTransiton((int)Scene.PlayScene, 0.3f);
    }
}
