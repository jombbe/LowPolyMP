using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : MonoBehaviour
{

    [SerializeField]
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 point = new Vector3(0, 0, 0);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 300))
        {
            this.transform.position = hit.point;
        }
    }
}
