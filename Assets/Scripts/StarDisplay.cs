using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField]
    private Text starText;

    private void Start() {
        DefenderSpawner defenderSpawner = FindObjectOfType<DefenderSpawner>();
        updateDisplay(defenderSpawner.getStars());
        defenderSpawner.registerOnStarAmountUpdated((amount) => updateDisplay(amount));
    }

    private void updateDisplay(int stars) {
        starText.text = stars.ToString();
    }
}
