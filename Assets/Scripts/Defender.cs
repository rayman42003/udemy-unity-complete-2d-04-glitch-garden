using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField]
    private int starCost = 100;

    public int getStarCost() {
        return starCost;
    }
}
