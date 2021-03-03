using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject levelCompleteCanvas;

    private int enemyCount = 0;
    private bool lastWave = false;
    private UnityEvent onNextLevel = new UnityEvent();

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
        }
    }

    private void completeLevel() {
        levelCompleteCanvas.SetActive(true);
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        StartCoroutine(finishLevel(audioSource.clip.length));
    }

    private IEnumerator finishLevel(float delaySeconds) {
        yield return new WaitForSeconds(delaySeconds);
        onNextLevel.Invoke();
    }

    public void registerOnNextLevel(UnityAction action) {
        onNextLevel.AddListener(action);
    }
}
