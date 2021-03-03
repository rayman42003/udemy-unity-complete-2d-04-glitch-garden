using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private const string SPLASH_SCREEN = "01-splash-screen";
    private const string START_MENU = "02-start-menu";
    private const string LOSE_SCREEN = "99-lose-screen";

    [SerializeField]
    private float splashScreenLoadTime = 1.75f;

    [SerializeField]
    private float gameOverLoadTime = 1f;

    private void Start() {
        string currScene = SceneManager.GetActiveScene().name;
        switch (currScene) {
            case SPLASH_SCREEN:
                StartCoroutine(delayedLoad(START_MENU, splashScreenLoadTime));
                break;
        }

        PlayerBase playerBase = FindObjectOfType<PlayerBase>();
        playerBase?.registerOnPlayerBaseKilled(() => StartCoroutine(delayedLoad(LOSE_SCREEN, gameOverLoadTime)));
        LevelController levelController = FindObjectOfType<LevelController>();
        levelController?.registerOnNextLevel(() => loadNextScene());
    }

    private IEnumerator delayedLoad(string scene, float delaySeconds) {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(scene);
    }

    private void loadNextScene() {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currSceneIndex + 1);
    }
}
