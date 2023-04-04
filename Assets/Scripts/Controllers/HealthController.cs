using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    float currentHealth;
    [SerializeField] float maxHealth;

    public void GetDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }

    public void Die()
    {
        Application.Quit();
    }

}
