using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Awake() {
        LevelController levelController = FindObjectOfType<LevelController>();
        levelController.addEnemy();

        Damagable damagable = GetComponent<Damagable>();
        damagable?.registerOnKilled(() => levelController.removeEnemy());

        DifficultyController difficultyController = FindObjectOfType<DifficultyController>();
        Difficulty difficulty = difficultyController.getDifficulty();
        Walker walker = GetComponent<Walker>();
        walker?.setWalkSpeed(walker.getWalkSpeed() * difficulty.getEnemySpeedScaling());
    }
}
