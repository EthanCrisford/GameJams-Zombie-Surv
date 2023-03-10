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
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
        Die();
    }

    public void LoseHealh(int damage)
    {
        currentHealth -= damage;
        print("current health is "+currentHealth);
    }

    void Die()
    {   
        print(entity.tag);
        if (entity.tag == "Zombie")
        {
            if(currentHealth <= 0)
            {
                Destroy(gameObject);
               
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
    public void destroy()
    {
        Destroy(gameObject);
    }
}
