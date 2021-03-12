using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DefenderIcon : MonoBehaviour
{
    [SerializeField]
    private Color disabledColor = new Color(32, 32, 32);

    [SerializeField]
    private Defender defenderPrefab;

    private DefenderEvent onDefenderSelected = new DefenderEvent();

    private void Start() {
        foreach (DefenderIcon defender in FindObjectsOfType<DefenderIcon>()) {
            if (defender.gameObject != this.gameObject) {
                defender.registerOnDefenderSelected((selectedDefender) => disableIcon());
            }
        }

        Text defenderCostText = GetComponentInChildren<Text>();
        defenderCostText.text = defenderPrefab.getStarCost().ToString();
    }

    private void OnMouseDown() {
        enableIcon();
        onDefenderSelected.Invoke(defenderPrefab);
    }

    private void enableIcon() {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void disableIcon() {
        GetComponent<SpriteRenderer>().color = disabledColor;
    }

    public void registerOnDefenderSelected(UnityAction<Defender> action) {
        onDefenderSelected.AddListener(action);
    }
}
