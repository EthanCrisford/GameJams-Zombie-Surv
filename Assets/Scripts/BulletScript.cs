using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bullet;
    public int damage = 1;
    HealthScript hs;
    // Start is called before the first frame update
    void Start()
    {
        hs = GetComponent<HealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        print("COLLISION");
        if(col.gameObject.tag == "Zombie")
        {
            hs = (HealthScript)col.gameObject.GetComponent<HealthScript>();
            hs.LoseHealh(damage);
            print(hs.currentHealth);
        }
        else
        {
            Destroy(bullet);
        }
    }
}
