using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject levelCompleteCanvas;

    [SerializeField]
    private int enemyCount = 0;

    private bool lastWave = false;
    private UnityEvent onLevelCompleted = new UnityEvent();

    private void Start() {
        levelCompleteCanvas.SetActive(false);

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
            completeLevel();
            onLevelCompleted.Invoke();
        }
    }

    private void completeLevel() {
        levelCompleteCanvas.SetActive(true);
    }

    public void registerOnLevelCompleted(UnityAction action) {
        onLevelCompleted.AddListener(action);
    }
}
