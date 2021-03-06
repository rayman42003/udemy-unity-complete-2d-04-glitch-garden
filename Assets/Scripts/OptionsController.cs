using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public const string MASTER_VOLUME_KEY = "MASTER_VOLUME";
    public const float DEFAULT_VOLUME = 0.4f;

    [SerializeField]
    private Slider masterVolumeSlider;

    private MusicPlayer musicPlayer;

    private void Start() {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY)) {
            masterVolumeSlider.value = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        } else {
            masterVolumeSlider.value = DEFAULT_VOLUME;
        }
    }

    public void onMasterVolumeChanged() {
        float volume = masterVolumeSlider.value;
        updateVolume(volume);
    }

    private void updateVolume(float volume) {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        musicPlayer?.updateVolume(volume);
        masterVolumeSlider.value = volume;
    }

    public void restoreDefaults() {
        updateVolume(DEFAULT_VOLUME);
    }
}
