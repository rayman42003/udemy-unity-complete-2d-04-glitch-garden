using UnityEngine;

public class DeathSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;

    [SerializeField]
    private Transform spawnLocation;

    private void Start() {
        Damagable damageable = gameObject.GetComponent<Damagable>();
        damageable?.registerOnKilled(() => spawn());
    }

    private void spawn() {
        Instantiate(spawnObject, spawnLocation.position,
            spawnObject.gameObject.transform.rotation);
    }
}
