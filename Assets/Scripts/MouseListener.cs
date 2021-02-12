using UnityEngine;

public class MouseListener : MonoBehaviour
{
    [SerializeField]
    private GameObject defender;

    private void OnMouseDown() {
        Debug.Log("mouse was clicked");
        Instantiate(defender, transform.position, Quaternion.identity);
    }
}
