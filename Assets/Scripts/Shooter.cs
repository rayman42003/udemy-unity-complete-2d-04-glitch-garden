using UnityEngine;

public class Shooter : MonoBehaviour
{
    private const string PROJECTILES_PARENT_NAME = "Projectiles";

    [SerializeField]
    private GameObject projectile;

    private GameObject projectilesParent;

    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private bool debugHasEnemiesInLane;

    private EnemySpawner laneEnemySpawner;
    private Animator animator;

    private void Start() {
        projectilesParent = GameObject.Find(PROJECTILES_PARENT_NAME) ?? new GameObject(PROJECTILES_PARENT_NAME);

        laneEnemySpawner = findLaneEnemySpawner();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        bool hasEnemiesInLane = laneEnemySpawner.transform.childCount > 0;
        debugHasEnemiesInLane = hasEnemiesInLane;
        animator.SetBool("isAttacking", hasEnemiesInLane);
    }

    public void shoot() {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        newProjectile.transform.parent = projectilesParent.transform;
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
