using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(destroyNextFrame(collision.gameObject));
    }

    private IEnumerator destroyNextFrame(GameObject thing) {
        yield return new WaitForEndOfFrame();
        Destroy(thing);
    }
}
