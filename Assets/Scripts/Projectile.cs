using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    private void Update() {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * 120 * Time.deltaTime);
    }
}
