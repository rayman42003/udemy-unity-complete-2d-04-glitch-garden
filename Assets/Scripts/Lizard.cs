using UnityEngine;

public class Lizard : MonoBehaviour
{
    private Fighter fighter;

    private void Start() {
        fighter = GetComponent<Fighter>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject other = collision.gameObject;
        Defender defender = other.GetComponent<Defender>();
        if (defender) {
            Debug.Log($"Defender {other.name} encounted");
            fighter.attack(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        GameObject other = collision.gameObject;
        Defender defender = other.GetComponent<Defender>();
        if (defender) {
            fighter.attack(false);
            Debug.Log($"Defender {other.name} EXIT");
        }
    }
}
