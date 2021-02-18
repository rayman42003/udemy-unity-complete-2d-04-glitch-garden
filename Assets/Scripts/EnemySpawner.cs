using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyPrefab;

    [SerializeField]
    private float minSpawnTime = 2f;

    [SerializeField]
    private float maxSpawnTime = 4f;

    private bool isSpawning = true;

    private IEnumerator Start() {
        while (isSpawning) {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            Enemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as Enemy;
            enemy.transform.parent = transform;
        }
    }
}
