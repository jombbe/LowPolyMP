using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraHitTarget : MonoBehaviourPunCallbacks
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
        if (photonView.IsMine)
        {
            RaycastHit hit;
            Vector3 point = new Vector3();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                this.transform.position = hit.point;
            }
        }
    }
}
