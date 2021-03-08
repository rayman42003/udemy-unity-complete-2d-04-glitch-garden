using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public const string MASTER_VOLUME_KEY = "MASTER_VOLUME";
    public const float DEFAULT_VOLUME = 0.4f;

    public const string DIFFICULTY_KEY = "DIFFICULTY";
    public const int DEFAULT_DIFFICULTY = 1;

    [SerializeField]
    private Slider masterVolumeSlider;

    [SerializeField]
    private Slider difficultySlider;

    private MusicPlayer musicPlayer;

    private void Start() {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY)) {
            masterVolumeSlider.value = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        } else {
            masterVolumeSlider.value = DEFAULT_VOLUME;
        }
        if (PlayerPrefs.HasKey(DIFFICULTY_KEY)) {
            difficultySlider.value = PlayerPrefs.GetInt(DIFFICULTY_KEY);
        } else {
            difficultySlider.value = DEFAULT_DIFFICULTY;
        }
    }

    public void onMasterVolumeChanged() {
        float volume = masterVolumeSlider.value;
        updateVolume(volume);
    }

    public void onDifficultyChanged() {
        int difficulty = (int)difficultySlider.value;
        updateDifficulty(difficulty);
    }

    private void updateVolume(float volume) {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        musicPlayer?.updateVolume(volume);
        masterVolumeSlider.value = volume;
    }

    private void updateDifficulty(int difficulty) {
        PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        difficultySlider.value = difficulty;
    }

    public void restoreDefaults() {
        updateVolume(DEFAULT_VOLUME);
        updateDifficulty(DEFAULT_DIFFICULTY);
    }
}
