using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField]
    private int attackPower = 1;

    [SerializeField]
    private bool destroyOnCollision = true;

    private void OnCollisionEnter2D(Collision2D collision) {
        Damagable damagable = collision.gameObject.GetComponent<Damagable>();
        if (damagable) {
            damagable.takeDamage(attackPower);
            if (destroyOnCollision) {
                Destroy(gameObject);
            }
        }
    }
}
