using UnityEngine;

public class Fox : MonoBehaviour
{
    private Animator animator;
    private Fighter fighter;

    private void Start() {
        animator = GetComponent<Animator>();
        fighter = GetComponent<Fighter>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject otherGameObject = collision.gameObject;
        if (otherGameObject.GetComponent<Gravestone>()) {
            animator.SetTrigger("jumpTrigger");
        } else if (otherGameObject.GetComponent<Defender>()) {
            fighter.attack(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        GameObject other = collision.gameObject;
        Defender defender = other.GetComponent<Defender>();
        if (defender) {
            fighter.attack(false);
        }
    }
}
