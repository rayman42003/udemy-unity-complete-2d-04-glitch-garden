using UnityEngine;

public class Walker : MonoBehaviour
{
    [Range(-5f, 5f)]
    [SerializeField]
    private float walkSpeed = 1f;

    private bool isWalking = false;

    private void Update() {
        if (isWalking) {
            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
        }
    }

    private void startWalking() {
        isWalking = true;
    }

    private void stopWalking() {
        isWalking = false;
    }

    public float getWalkSpeed() {
        return walkSpeed;
    }

    public void setWalkSpeed(float walkSpeed) {
        this.walkSpeed = walkSpeed;
    }
}
