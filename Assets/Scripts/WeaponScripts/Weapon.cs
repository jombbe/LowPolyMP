using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Weapon : MonoBehaviourPunCallbacks
{

    public float Range = 100f;
    public float fireRate = 15f;



    [SerializeField]
    GameObject ImpactEffect;

    [SerializeField]
    GameObject ImpactEffectBlood;

    [SerializeField]
    GameObject player;

    PlayerStats playerStats;


    public ParticleSystem MuzzleFlash = null;

    private float nextTimeToFire = 0f;

    public Camera RaycastCam;

    public AudioClip impact;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        player = GameObject.FindWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            if (!playerStats.isdead)
            {
                audioSource.Play();
                Shoot();
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        MuzzleFlash.Play();
        this.GetComponent<PhotonView>().RPC("PlayEffects", RpcTarget.All, true);
        if (Physics.Raycast(RaycastCam.transform.position, RaycastCam.transform.forward, out hit, Range))
        {
            Debug.Log(hit.transform.gameObject.name);

            if (!hit.collider.gameObject.CompareTag("BodyPart"))
            {
                PhotonNetwork.Instantiate(ImpactEffect.name, hit.point, Quaternion.LookRotation(hit.normal));
            }

            if (hit.collider.gameObject.CompareTag("BodyPart") && !hit.collider.gameObject.GetComponent<PhotonView>().IsMine)
            {
                hit.collider.gameObject.GetComponent<PhotonView>().RPC("PartManager", RpcTarget.All, true);
                PhotonNetwork.Instantiate(ImpactEffectBlood.name, hit.point, Quaternion.LookRotation(hit.normal));
            }

        }
    }

    [PunRPC]
    public void PlayEffects(bool firing, PhotonMessageInfo info)
    {
        if(firing)
        {
            MuzzleFlash.Play();
        }
    }
}
