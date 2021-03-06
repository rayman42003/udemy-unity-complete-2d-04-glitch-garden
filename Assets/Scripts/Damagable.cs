﻿using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [SerializeField]
    private int hitPoints = 1;

    private bool invulnerable = false;
    private UnityEvent onDamaged = new UnityEvent();
    private UnityEvent onKilled = new UnityEvent();

    public void takeDamage(int amount) {
        if (invulnerable) {
            return;
        }

        hitPoints -= amount;
        if (hitPoints <= 0) {
            kill();
        }
        onDamaged.Invoke();
    }

    public void kill() {
        onKilled.Invoke();
        Destroy(gameObject);
    }

    public void registerOnKilled(UnityAction action) {
        onKilled.AddListener(action);
    }

    public bool isInvulnerable() {
        return invulnerable;
    }

    public void setInvulnerable(int state) {
        invulnerable = state != 0;
    }
}
