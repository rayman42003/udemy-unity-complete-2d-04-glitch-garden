using UnityEngine;
using UnityEngine.Events;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField]
    private Defender defender;

    private IntEvent onStarGeneration = new IntEvent();
    private IntEvent onStarAmountUpdated = new IntEvent();
    private int stars = 100;

    private void Start() {
        foreach (DefenderIcon defenderIcon in FindObjectsOfType<DefenderIcon>()) {
            defenderIcon.registerOnDefenderSelected((selectedDefender) => setDefender(selectedDefender));
        }
        onStarGeneration.AddListener((amount) => addStars(amount));
    }

    private void OnMouseDown() {
        Vector2 screenClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldClickPos = Camera.main.ScreenToWorldPoint(screenClickPos);
        Vector2 snappedClickPos = new Vector2(Mathf.RoundToInt(worldClickPos.x), Mathf.RoundToInt(worldClickPos.y));
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
