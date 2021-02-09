using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [SerializeField]
    private int hitPoints = 1;

    private UnityEvent onDamaged = new UnityEvent();
    private UnityEvent onKilled = new UnityEvent();

    public void takeDamage(int amount) {
        hitPoints -= amount;
        if (hitPoints <= 0) {
            onKilled.Invoke();
            Destroy(gameObject);
        }
        onDamaged.Invoke();
    }
}
