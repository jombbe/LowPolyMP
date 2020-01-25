using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AudioHandler : MonoBehaviourPunCallbacks
{

    [SerializeField]
    AudioSource remoteAudios;


    [SerializeField]
    AudioClip Shoot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void weaponSound(bool isFiring)
    {
        if(isFiring)
        {
            remoteAudios.clip = Shoot;
            remoteAudios.PlayOneShot(remoteAudios.clip);
        }
    }


}
