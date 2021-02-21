using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField]
    private int attackPower = 1;

    [SerializeField]
    private bool destroyOnCollision = true;

    private void OnTriggerStay2D(Collider2D collider) {
        Damagable damagable = collider.gameObject.GetComponent<Damagable>();
        if (damagable && !damagable.isInvulnerable()) {
            damagable.takeDamage(attackPower);
            if (destroyOnCollision) {
                Destroy(gameObject);
            }
        }
    }
}
