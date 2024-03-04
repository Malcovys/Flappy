using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public Camera cam;

    void Awake()
    {
        Instance = this;
    }

    public void Shake(float strenght, float duration)
    {
        cam.DOShakePosition(duration, strenght);
    }
}
