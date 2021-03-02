using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Duration of level in seconds")]
    [SerializeField]
    private float levelDuration = 10f;

    private UnityEvent onGameTimerFinished = new UnityEvent();
    private Slider slider;

    private void Start() {
        slider = GetComponent<Slider>();
    }

    private void Update() {
        slider.value = Time.timeSinceLevelLoad / levelDuration;

        if (Time.timeSinceLevelLoad >= levelDuration) {
            onGameTimerFinished.Invoke();
            enabled = false;
        }
    }

    public void registerOnGameTimerFinished(UnityAction action) {
        onGameTimerFinished.AddListener(action);
    }
}
