using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    [SerializeField]
    private int generationAmount = 5;

    private IntEvent onStarGeneration;

    private void Start() {
        DefenderSpawner defenderSpawner = FindObjectOfType<DefenderSpawner>();
        onStarGeneration = defenderSpawner.getStarGenerationEvent();
    }

    private void generateStar() {
        onStarGeneration.Invoke(generationAmount);
    }
}
