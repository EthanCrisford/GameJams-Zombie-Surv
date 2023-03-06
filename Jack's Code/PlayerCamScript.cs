using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamScript : MonoBehaviour
{
    // Mouse sensativity
    public float xSens;
    public float ySens;

    public Transform camOrientation;

    // Camera rotation
    float xRotate;
    float yRotate;

    // Start is called before the first frame update
    void Start()
    {
        // Locks the cursor in place
        Cursor.lockState = CursorLockMode.Locked;

        // Makes cursor incisible
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Getting the mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;

        yRotate += mouseX;
        xRotate -= mouseY;

        // Clamps x axis view between -90? and 90?
        xRotate = Mathf.Clamp(xRotate, -90, 90);

        // Roate camera and its orientation
        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);
        camOrientation.rotation = Quaternion.Euler(0, yRotate, 0);
    }
}
