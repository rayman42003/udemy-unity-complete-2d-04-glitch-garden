using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject levelCompleteCanvas;

    [SerializeField]
    private GameObject levelLostCanvas;

    private int enemyCount = 0;
    private bool lastWave = false;
    private bool gameLost = false;
    private UnityEvent onNextLevel = new UnityEvent();

    private void Start() {
        Time.timeScale = 1;
        levelCompleteCanvas.SetActive(false);
        levelLostCanvas.SetActive(false);

        GameTimer gameTimer = FindObjectOfType<GameTimer>();
        gameTimer?.registerOnGameTimerFinished(() => startLastWave());

        PlayerBase playerBase = FindObjectOfType<PlayerBase>();
        playerBase?.registerOnPlayerBaseKilled(() => loseLevel());
    }

    private void startLastWave() {
        lastWave = true;
    }

    public void addEnemy() {
        enemyCount++;
    }

    public void removeEnemy() {
        enemyCount--;
        if (lastWave && enemyCount <= 0 && !gameLost) {
            completeLevel();
        }
    }

    private void completeLevel() {
        levelCompleteCanvas.SetActive(true);
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        StartCoroutine(finishLevel(audioSource.clip.length));
    }

    private void loseLevel() {
        levelLostCanvas.SetActive(true);
        gameLost = true;
        Time.timeScale = 0;
    }

    private IEnumerator finishLevel(float delaySeconds) {
        yield return new WaitForSeconds(delaySeconds);
        onNextLevel.Invoke();
    }

    public void registerOnNextLevel(UnityAction action) {
        onNextLevel.AddListener(action);
    }
}
