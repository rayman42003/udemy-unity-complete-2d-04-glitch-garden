using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float minSpawnTime = 2f;

    [SerializeField]
    private float maxSpawnTime = 4f;

    private bool isSpawning = true;

    private IEnumerator Start() {
        while (isSpawning) {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
