using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseDisplay : MonoBehaviour
{
    [SerializeField]
    private Text healthText;

    private void Start() {
        PlayerBase playerBase = FindObjectOfType<PlayerBase>();
        updateHealth(playerBase.getHealth());
        playerBase?.registerOnPlayerBaseDamaged((health) => updateHealth(health));
    }

    private void updateHealth(int health) {
        healthText.text = health.ToString();
    }
}
