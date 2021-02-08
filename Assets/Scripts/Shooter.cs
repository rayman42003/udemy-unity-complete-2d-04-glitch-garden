using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private GameObject gun;

    public void shoot() {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
}
