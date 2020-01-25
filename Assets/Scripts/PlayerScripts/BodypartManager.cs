using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class BodypartManager : MonoBehaviourPunCallbacks
{

    [SerializeField]
    string Bodypart;

    [SerializeField]
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    [PunRPC]
    public void PartManager(bool hitted, PhotonMessageInfo info)
    {
        if(hitted)
        {
            player.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, Bodypart);
        }
    }
}
