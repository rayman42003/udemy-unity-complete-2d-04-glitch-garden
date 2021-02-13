using UnityEngine;

public class MouseListener : MonoBehaviour
{
    [SerializeField]
    private GameObject defender;

    private void OnMouseDown() {
        Vector2 screenClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldClickPos = Camera.main.ScreenToWorldPoint(screenClickPos);
        Vector2 snappedClickPos = new Vector2(Mathf.RoundToInt(worldClickPos.x), Mathf.RoundToInt(worldClickPos.y));
        Instantiate(defender, snappedClickPos, Quaternion.identity);
    }
}
