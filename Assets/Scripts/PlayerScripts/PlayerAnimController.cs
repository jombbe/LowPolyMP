using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerAnimController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    GameObject Soldier;

    [SerializeField]
    Animator anim;

    PlayerStats playerStats;

    PlayerMovementV2 playerMovementV2;

    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerMovementV2 = FindObjectOfType<PlayerMovementV2>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveVertical = Input.GetAxis("Vertical");
        anim.SetFloat("moveVertical", moveVertical);

        float moveHorizontal = Input.GetAxis("Horizontal");
        anim.SetFloat("moveHorizontal", moveHorizontal);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("Crouch", true);
        }
        else
        {
            anim.SetBool("Crouch", false);
        }

        if (Input.GetButtonDown("Jump") && playerMovementV2.isGrounded)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }
}


