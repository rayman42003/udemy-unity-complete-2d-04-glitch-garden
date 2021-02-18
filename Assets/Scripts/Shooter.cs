using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private bool hasEnemiesInLane;

    private EnemySpawner laneEnemySpawner;

    private void Start() {
        laneEnemySpawner = findLaneEnemySpawner();
    }

    private void Update() {
        hasEnemiesInLane = laneEnemySpawner.transform.childCount > 0;
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
