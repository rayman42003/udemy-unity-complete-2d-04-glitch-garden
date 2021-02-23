using System.Collections;
using UnityEngine;

public class Expirable : MonoBehaviour
{
    [SerializeField]
    private bool active = true;

    [SerializeField]
    private float duration = 0.5f;

    private void Update() {
        if (active) {
            StartCoroutine(expireInXSeconds(duration));
            active = false;
        }
    }

    private IEnumerator expireInXSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}
