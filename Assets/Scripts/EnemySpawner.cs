using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Enemy[] enemyPrefabs;

    [SerializeField]
    private float minSpawnTime = 2f;

    [SerializeField]
    private float maxSpawnTime = 4f;

    private bool isSpawning = true;

    private void Awake() {
        FindObjectOfType<GameTimer>().registerOnGameTimerFinished(() => isSpawning = false);
    }

    private IEnumerator Start() {
        while (isSpawning) {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            if (isSpawning) {
                Enemy enemy = Instantiate(selectEnemy(), transform.position, Quaternion.identity) as Enemy;
                enemy.transform.parent = transform;
            }
        }
    }

    private Enemy selectEnemy() {
        return enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
    }
}
