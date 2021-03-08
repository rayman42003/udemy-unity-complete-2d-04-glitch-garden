using System;
using UnityEngine;

[Serializable]
public class Difficulty
{
    [SerializeField]
    private float healthScaling;

    [SerializeField]
    private float enemySpeedScaling;

    [SerializeField]
    private float startingStarAmountScaling;

    public Difficulty(float healthScaling, float enemySpeedScaling, float startingStarAmountScaling) {
        this.healthScaling = healthScaling;
        this.enemySpeedScaling = enemySpeedScaling;
        this.startingStarAmountScaling = startingStarAmountScaling;
    }

    public float getHealthScaling() {
        return healthScaling;
    }

    public float getEnemySpeedScaling() {
        return enemySpeedScaling;
    }

    public float getStartingStarAmountScaling() {
        return startingStarAmountScaling;
    }
}
