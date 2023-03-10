using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bullet;
    public int damage;
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
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Zombie")
        {
            hs.LoseHealh(damage);   
        }
        else
        {
            Destroy(bullet);
        }
    }
}
