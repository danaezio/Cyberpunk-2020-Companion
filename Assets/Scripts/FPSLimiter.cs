using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    [SerializeField, Min(1)] private int limit;

    private void Start() => Application.targetFrameRate = limit;
}
