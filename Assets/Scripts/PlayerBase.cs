using UnityEngine;
using UnityEngine.Events;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    private int health = 10;

    private IntEvent onPlayerBaseDamaged = new IntEvent();
    private UnityEvent onPlayerBaseKilled = new UnityEvent();

    private void Start() {
        DifficultyController difficultyController = FindObjectOfType<DifficultyController>();
        Difficulty difficulty = difficultyController.getDifficulty();
        health = Mathf.RoundToInt(health * difficulty.getHealthScaling());
        onPlayerBaseDamaged.Invoke(health);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject other = collision.gameObject;
        Enemy enemy = other.GetComponent<Enemy>();
        Fighter fighter = other.GetComponent<Fighter>();
        if (enemy && fighter) {
            int damage = fighter.getHitbox().getAttackPower();
            health = Mathf.Clamp(health - damage, 0, int.MaxValue);
            onPlayerBaseDamaged.Invoke(health);
        } else {
            Debug.LogError($"{other.name} did not damage player base");
        }
        if (health <= 0) {
            onPlayerBaseKilled.Invoke();
        }
    }

    public void registerOnPlayerBaseDamaged(UnityAction<int> action) {
        onPlayerBaseDamaged.AddListener(action);
    }

    public void registerOnPlayerBaseKilled(UnityAction action) {
        onPlayerBaseKilled.AddListener(action);
    }

    public int getHealth() {
        return health;
    }
}
