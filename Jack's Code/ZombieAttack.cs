using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [Header("Scripts")]
    private HealthScript hs;
    private HealthScript playerHS;

    [Header("GameObjects")]
    public GameObject player;
    public GameObject attacker;

    [Header("Colliders")]
    public CapsuleCollider playerCol;
    public CapsuleCollider attackerCol;

    [Header("Integers")]
    public int damage;
    public int playerHealth;

    bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        hs = GetComponent<HealthScript>();
        playerHS = player.GetComponent<HealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            attacking = true;
        }

        while (attacking)
        {
            Attack();
        }
    }
    private void OnCollisionExit(Collision col)
    {
        attacking = false;
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.5f);

        playerHS.LoseHealh(damage);
    }
}
