using UnityEngine;

public class MouseListener : MonoBehaviour
{
    [SerializeField]
    private GameObject defender;

    private void OnMouseDown() {
        Vector2 screenClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldClickPos = Camera.main.ScreenToWorldPoint(screenClickPos);
        Instantiate(defender, worldClickPos, Quaternion.identity);
    }
}
