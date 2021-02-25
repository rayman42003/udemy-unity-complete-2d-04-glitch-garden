using UnityEngine;

public class Dasher : MonoBehaviour
{
    [Range(-5f, 5f)]
    [SerializeField]
    private float dashSpeed;

    private bool isDashing = false;

    private void Update() {
        if (isDashing) {
            transform.Translate(Vector2.left * dashSpeed * Time.deltaTime);
        }
    }

    private void startDashing() {
        isDashing = true;
    }

    private void stopDashing() {
        isDashing = false;
    }
}
