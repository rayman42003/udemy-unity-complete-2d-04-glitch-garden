using UnityEngine;
using UnityEngine.Events;

public class DefenderIcon : MonoBehaviour
{
    private GameObjectEvent onDefenderSelected = new GameObjectEvent();

    [SerializeField]
    private Color disabledColor = new Color(32, 32, 32);

    private void Start() {
        foreach (DefenderIcon defender in FindObjectsOfType<DefenderIcon>()) {
            if (defender.gameObject != this.gameObject) {
                defender.registerOnDefenderSelected((selectedDefender) => disableIcon());
            }
        }
    }

    private void OnMouseDown() {
        enableIcon();
        onDefenderSelected.Invoke(this.gameObject);
    }

    private void enableIcon() {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void disableIcon() {
        GetComponent<SpriteRenderer>().color = disabledColor;
    }

    public void registerOnDefenderSelected(UnityAction<GameObject> action) {
        onDefenderSelected.AddListener(action);
    }
}
