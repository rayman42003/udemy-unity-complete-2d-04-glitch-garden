using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField]
    private Text starText;

    private int stars = 100;

    private void Start() {
        updateDisplay();
    }

    private void updateDisplay() {
        starText.text = stars.ToString();
    }
}
