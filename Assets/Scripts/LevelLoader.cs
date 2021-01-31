using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private const string SPLASH_SCREEN = "01-splash-screen";
    private const string START_MENU = "02-start-menu";

    [SerializeField]
    private float splashScreenLoadTime = 1.75f;

    private void Start() {
        string currScene = SceneManager.GetActiveScene().name;
        switch (currScene) {
            case SPLASH_SCREEN:
                StartCoroutine(delayedLoad(START_MENU, splashScreenLoadTime));
                break;
        }
    }

    private IEnumerator delayedLoad(string scene, float delaySeconds) {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(scene);
    }
}
