using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    [SerializeField]
    private Difficulty easyDifficulty = new Difficulty(1.2f, 0.8f, 10f);

    [SerializeField]
    private Difficulty normalDifficulty = new Difficulty(1.0f, 1.0f, 8.5f);

    [SerializeField]
    private Difficulty hardDifficulty = new Difficulty(0.9f, 1.2f, 7f);

    [SerializeField]
    private Difficulty extremeDifficulty = new Difficulty(0.75f, 1.2f, 5.5f);

    private enum DifficultyLevel
    {
        EASY = 0,
        NORMAL = 1,
        HARD = 2,
        EXTREME = 3
    }

    private DifficultyLevel loadDifficulty() {
        if (PlayerPrefs.HasKey(OptionsController.DIFFICULTY_KEY)) {
            return (DifficultyLevel)PlayerPrefs.GetInt(OptionsController.DIFFICULTY_KEY);
        } else {
            return (DifficultyLevel)OptionsController.DEFAULT_DIFFICULTY;
        }
    }

    public Difficulty getDifficulty() {
        DifficultyLevel difficultyLevel = loadDifficulty();
        switch (difficultyLevel) {
            case DifficultyLevel.EASY:
                return easyDifficulty;

            case DifficultyLevel.NORMAL:
            default:
                return normalDifficulty;

            case DifficultyLevel.HARD:
                return hardDifficulty;

            case DifficultyLevel.EXTREME:
                return extremeDifficulty;
        }
    }
}
