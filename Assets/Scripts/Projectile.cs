using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    private void Update() {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * 120 * Time.deltaTime);
    }
}
