using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [SerializeField]
    private int hitPoints = 1;

    private bool invulnerable = false;
    private UnityEvent onDamaged = new UnityEvent();
    private UnityEvent onKilled = new UnityEvent();

    public void takeDamage(int amount) {
        if (invulnerable) {
            return;
        }

        hitPoints -= amount;
        if (hitPoints <= 0) {
            onKilled.Invoke();
            Destroy(gameObject);
        }
        onDamaged.Invoke();
    }

    public void registerOnKilled(UnityAction action) {
        onDamaged.AddListener(action);
    }

    public bool isInvulnerable() {
        return invulnerable;
    }

    public void setInvulnerable(int state) {
        invulnerable = state != 0;
    }
}
