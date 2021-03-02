using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(destroyNextFrame(collision.gameObject));
    }

    private IEnumerator destroyNextFrame(GameObject other) {
        yield return new WaitForEndOfFrame();
        Damagable damagable = other.GetComponent<Damagable>();
        if (damagable) {
            damagable.kill();
        } else {
            Destroy(other);
        }
    }
}
