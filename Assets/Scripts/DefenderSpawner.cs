using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField]
    private Defender defender;

    private void Start() {
        foreach (DefenderIcon defenderIcon in FindObjectsOfType<DefenderIcon>()) {
            defenderIcon.registerOnDefenderSelected((selectedDefender) => setDefender(selectedDefender));
        }
    }

    private void OnMouseDown() {
        Vector2 screenClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldClickPos = Camera.main.ScreenToWorldPoint(screenClickPos);
        Vector2 snappedClickPos = new Vector2(Mathf.RoundToInt(worldClickPos.x), Mathf.RoundToInt(worldClickPos.y));
        Instantiate(defender, snappedClickPos, Quaternion.identity);
    }

    private void setDefender(Defender defender) {
        this.defender = defender;
    }
}
