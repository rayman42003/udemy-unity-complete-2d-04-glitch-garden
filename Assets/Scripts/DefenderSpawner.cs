using UnityEngine;
using UnityEngine.Events;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField]
    private Defender defender;

    [SerializeField]
    private int stars = 100;

    private IntEvent onStarGeneration = new IntEvent();
    private IntEvent onStarAmountUpdated = new IntEvent();

    private void Start() {
        foreach (DefenderIcon defenderIcon in FindObjectsOfType<DefenderIcon>()) {
            defenderIcon.registerOnDefenderSelected((selectedDefender) => setDefender(selectedDefender));
        }
        onStarGeneration.AddListener((amount) => addStars(amount));
    }

    private void OnMouseDown() {
        int defenderCost = defender.getStarCost();
        if (stars >= defenderCost) {
            addStars(-defenderCost);
            spawnDefender(getMouseWorldPos());
        }
    }

    private Vector2 getMouseWorldPos() {
        Vector2 screenClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        return Camera.main.ScreenToWorldPoint(screenClickPos);
    }

    private void spawnDefender(Vector2 worldPos) {
        Vector2 snappedClickPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
        Instantiate(defender, snappedClickPos, Quaternion.identity);
    }

    private void addStars(int amount) {
        stars += amount;
        onStarAmountUpdated.Invoke(stars);
    }

    private void setDefender(Defender defender) {
        this.defender = defender;
    }

    public int getStars() {
        return stars;
    }

    public IntEvent getStarGenerationEvent() {
        return onStarGeneration;
    }

    public void registerOnStarAmountUpdated(UnityAction<int> action) {
        onStarAmountUpdated.AddListener(action);
    }
}
