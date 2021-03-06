using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public void Awake() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        if (PlayerPrefs.HasKey(OptionsController.MASTER_VOLUME_KEY)) {
            audioSource.volume = PlayerPrefs.GetFloat(OptionsController.MASTER_VOLUME_KEY);
        } else {
            audioSource.volume = OptionsController.DEFAULT_VOLUME;
        }
    }

    public void updateVolume(float volume) {
        audioSource.volume = volume;
    }
}
