using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField]
    private Damager hitbox;

    [SerializeField]
    private Transform hitboxPosition;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void attack(bool state) {
        animator.SetBool("isAttacking", state);
    }

    public void meleeAttack() {
        Debug.Log("meleeAttack called");
        Damager clone = Instantiate(hitbox, hitboxPosition.position, hitboxPosition.rotation);
        clone.gameObject.transform.parent = gameObject.transform;
    }
}
