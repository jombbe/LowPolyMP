using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{


    public float Sensitivy;
    public float aimSensitivy = 50f;
    public float NormalSensitivy = 100f;

    public Transform player;

    [SerializeField]
    public float xRotation  = 0f;


    public void Start()
    {  
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
    }

    void Update()
    {
        {
            float mouseX = Input.GetAxis("Mouse X") * Sensitivy * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Sensitivy * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.Rotate(Vector3.up * mouseX);
        }

        if(Input.GetKey(KeyCode.Mouse1))
        {
            Sensitivy = aimSensitivy;
        }
        else
        {
            Sensitivy = NormalSensitivy;
        }
    }
}
