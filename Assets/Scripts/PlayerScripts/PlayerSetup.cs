using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviourPunCallbacks
{

    [SerializeField]
    GameObject cam;
    [SerializeField]
    Camera camera;

    [SerializeField]
    GameObject PlayerStatsCanvas;

    [SerializeField]
    GameObject Weapon;

    [SerializeField]
    GameObject SoldierGrahics;

 

    // Start is called before the first frame update
    void Start()
    {


        if (photonView.IsMine)
        {
            PlayerStatsCanvas.SetActive(true);
            transform.GetComponent<PlayerMovementV2>().enabled = true;
            transform.GetComponent<CharacterController>().enabled = true;
            camera.enabled = true;
            cam.GetComponent<MouseLook>().enabled = true;
            camera.GetComponent<AudioListener>().enabled = true;
            Weapon.GetComponent<Weapon>().enabled = true;
            transform.GetComponent<PlayerStats>().enabled = true;
            SoldierGrahics.GetComponent<PlayerAnimController>().enabled = true;




        }
        else
        {
            PlayerStatsCanvas.SetActive(false);
            transform.GetComponent<PlayerMovementV2>().enabled = false;
            transform.GetComponent<CharacterController>().enabled = false;
            camera.enabled = false;
            transform.GetComponent<PlayerStats>().enabled = false;
            Weapon.GetComponent<Weapon>().enabled = false;
            camera.GetComponent<AudioListener>().enabled = false;
            cam.GetComponent<MouseLook>().enabled = false;
            SoldierGrahics.GetComponent<PlayerAnimController>().enabled = false;
        }

    }

    private void Update()
    {

    }
}
