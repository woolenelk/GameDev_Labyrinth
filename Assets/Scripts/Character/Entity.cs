using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public delegate void HealthUpdated(float newHealth);
    public HealthUpdated OnHealthUpdated = null;

    private bool isAlive = false;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth = 0f;

    public void Start()
    {
        isAlive = true;
        currentHealth = maxHealth;
        OnHealthUpdated += HealthUpdate;
    }

    private void FixedUpdate()
    {
        OnHealthUpdated?.Invoke(currentHealth);
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void HealthUpdate(float newHealth)
    {
        if (currentHealth <= 0)
        {
            if (isAlive)
            {
                Die();
            }
        }
    }

    //TODO 
    public void Hit(float damage)
    {
        currentHealth -= damage;
        OnHealthUpdated?.Invoke(currentHealth);
    }
    public void Heal(float heal)
    {
        currentHealth = Mathf.Min(currentHealth + heal, maxHealth);
        OnHealthUpdated?.Invoke(currentHealth);
    }
    public virtual void Die()
    {
        
        Debug.Log("i died");
        Destroy(gameObject);
    }
}
