using UnityEngine;
using UnityEngine.Events;

public class DefenderSpawner : MonoBehaviour
{
    private const string DEFENDER_PARENT_NAME = "Defenders";

    [SerializeField]
    private Defender defender;

    private GameObject defendersParent;

    [SerializeField]
    private int stars = 100;

    private IntEvent onStarGeneration = new IntEvent();
    private IntEvent onStarAmountUpdated = new IntEvent();

    private void Start() {
        defendersParent = GameObject.Find(DEFENDER_PARENT_NAME) ?? new GameObject(DEFENDER_PARENT_NAME);

        DifficultyController difficultyController = FindObjectOfType<DifficultyController>();
        Difficulty difficulty = difficultyController.getDifficulty();
        stars = Mathf.RoundToInt(stars * difficulty.getStartingStarAmountScaling());
        onStarAmountUpdated.Invoke(stars);

        foreach (DefenderIcon defenderIcon in FindObjectsOfType<DefenderIcon>()) {
            defenderIcon.registerOnDefenderSelected((selectedDefender) => setDefender(selectedDefender));
        }
        onStarGeneration.AddListener((amount) => addStars(amount));
    }

    private void OnMouseDown() {
        if (!defender) {
            return;
        }
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
        Defender newDefender = Instantiate(defender, snappedClickPos, Quaternion.identity);
        newDefender.transform.parent = defendersParent.transform;
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
