using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    [Header("Game Objects")]
    public GameObject entity;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (entity.tag == "Zombie")
        {
            maxHealth = 2;
        }
        if (entity.tag == "Player")
        {
            maxHealth = 3;
        }

        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealh(int damage)
    {
        currentHealth -= damage;
    }

    void Die()
    {   
        if (entity.tag == "Zombie")
        {
            if(currentHealth <= 0)
            {
                entity.SetActive(false);
            }
        }

        if (entity.tag == "Player")
        {
            if (currentHealth <= 0)
            {
                Time.timeScale = 0;
            }
        }
    }
}
