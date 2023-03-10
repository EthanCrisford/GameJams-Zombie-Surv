using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUN : MonoBehaviour
{
    //Gun variables
    public GameObject bulletPref;
    public int ammo = 7;
    public float shootForce;
    public float upwardForce;

    //Reference
    public Camera camHold;
    public Transform Muzzle;
    public Light muzzleLight;
    public ParticleSystem flash;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammo > 0)
        {
            StartCoroutine(Shoot());
        }
    }


    IEnumerator Shoot()
    {
        Ray ray = camHold.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        muzzleLight.enabled = true;
        flash.Play(true);
        
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - Muzzle.position;

        GameObject currentBullet = Instantiate(bulletPref, Muzzle.position, Quaternion.identity);

        currentBullet.transform.forward = directionWithoutSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread * shootForce, ForceMode.Impulse);

        yield return new WaitForSeconds(0.1f);
        muzzleLight.enabled = false;

    }
}
