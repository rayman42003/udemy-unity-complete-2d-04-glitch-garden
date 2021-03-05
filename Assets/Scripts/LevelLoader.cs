using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private const string SPLASH_SCREEN = "01-splash-screen";
    private const string START_MENU = "02-start-menu";
    private const string LOSE_SCREEN = "99-lose-screen";
    private const string OPTIONS_MENU = "999-options-menu";

    [SerializeField]
    private float splashScreenLoadTime = 1.75f;

    private void Start() {
        string currScene = SceneManager.GetActiveScene().name;
        switch (currScene) {
            case SPLASH_SCREEN:
                StartCoroutine(delayedLoad(START_MENU, splashScreenLoadTime));
                break;
        }

        LevelController levelController = FindObjectOfType<LevelController>();
        levelController?.registerOnNextLevel(() => loadNextScene());
    }

    private IEnumerator delayedLoad(string scene, float delaySeconds) {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(scene);
    }

    public void loadNextScene() {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currSceneIndex + 1);
    }

    public void restartScene() {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currSceneIndex);
    }

    public void loadMainMenu() {
        SceneManager.LoadScene(START_MENU);
    }

    public void loadOptionsScreen() {
        SceneManager.LoadScene(OPTIONS_MENU);
    }

    public void quitGame() {
        Application.Quit();
    }
}
