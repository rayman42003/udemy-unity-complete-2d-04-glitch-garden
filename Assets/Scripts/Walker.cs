using UnityEngine;

public class Walker : MonoBehaviour
{
    [Range(-5f, 5f)]
    [SerializeField]
    private float walkSpeed = 1f;

    private void Update() {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }
}
