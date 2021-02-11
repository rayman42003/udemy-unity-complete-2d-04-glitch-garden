using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField]
    private int attackPower = 1;

    [SerializeField]
    private bool destroyOnCollision = true;

    private void OnCollisionStay2D(Collision2D collision) {
        Damagable damagable = collision.gameObject.GetComponent<Damagable>();
        if (damagable && !damagable.isInvulnerable()) {
            damagable.takeDamage(attackPower);
            if (destroyOnCollision) {
                Destroy(gameObject);
            }
        }
    }
}
