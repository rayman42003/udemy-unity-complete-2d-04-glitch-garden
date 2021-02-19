using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private GameObject gun;

    private EnemySpawner laneEnemySpawner;
    private Animator animator;

    private void Start() {
        laneEnemySpawner = findLaneEnemySpawner();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        bool hasEnemiesInLane = laneEnemySpawner.transform.childCount > 0;
        animator.SetBool("isAttacking", hasEnemiesInLane);
    }

    public void shoot() {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }

    private EnemySpawner findLaneEnemySpawner() {
        foreach (EnemySpawner spawner in FindObjectsOfType<EnemySpawner>()) {
            float yDelta = this.gameObject.transform.position.y - spawner.transform.position.y;
            if (Mathf.Abs(yDelta) <= Mathf.Epsilon) {
                return spawner;
            }
        }
        return null;
    }
}
