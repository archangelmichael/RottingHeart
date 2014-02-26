using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public float maxEnemyHealth = 200;
    public float currentEnemyHealth;

    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
    }

    void Update()
    {
    }

    void DamageEnemy(float damage)
    {
        currentEnemyHealth -= damage;
        if (currentEnemyHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        animation.CrossFade("die");
        gameObject.SetActive(false);
    }
}
