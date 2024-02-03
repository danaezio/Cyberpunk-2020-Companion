using UnityEngine;
using UnityEngine.Events;

public class AutoClick : MonoBehaviour
{
    [SerializeField] private UnityEvent clickEvent;

    int clickCount = 0;

    private void FixedUpdate()
    {
        clickEvent.Invoke();
        clickCount++;
        //Debug.Log(clickCount);
    }
}
