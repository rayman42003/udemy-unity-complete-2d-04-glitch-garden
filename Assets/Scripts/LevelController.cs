using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    private int enemyCount = 0;
    private bool lastWave = false;
    private UnityEvent onLevelCompleted = new UnityEvent();

    private void Start() {
        GameTimer gameTimer = FindObjectOfType<GameTimer>();
        gameTimer?.registerOnGameTimerFinished(() => startLastWave());
    }

    private void startLastWave() {
        lastWave = true;
    }

    public void addEnemy() {
        enemyCount++;
    }

    public void removeEnemy() {
        enemyCount--;
        if (lastWave && enemyCount <= 0) {
            onLevelCompleted.Invoke();
        }
    }

    public void registerOnLevelCompleted(UnityAction action) {
        onLevelCompleted.AddListener(action);
    }
}
