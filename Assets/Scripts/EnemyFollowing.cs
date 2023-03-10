using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class EnemyFollowing : MonoBehaviour
{

    Rigidbody rb;
    public Vector3 foward;

    public int speed;
    public GameObject player;
    public float rotationSpeed = 5;


    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {

        rb.velocity = transform.forward * speed;

        //rotate to look at the player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime);
        //Vector3 movement = new Vector3(player.transform.position - transform.position);
       
    }
}
