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
    GameObject playerAudios;

    [SerializeField]
    GameObject AimTarget;

    [SerializeField]
    GameObject ImpactEffectBlood;

    [SerializeField]
    GameObject player;

    PlayerStats playerStats;


    public ParticleSystem MuzzleFlash = null;

    private float nextTimeToFire = 0f;

    public GameObject RaycastPoint;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip WeaponSound;

    // Start is called before the first frame update
    void Start()
    {
        playerAudios = GameObject.FindWithTag("playerAudio");
        playerStats = FindObjectOfType<PlayerStats>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            if (!playerStats.isdead)
            {
                audioSource.clip = WeaponSound;
                audioSource.PlayOneShot(audioSource.clip);
                playerAudios.GetComponent<PhotonView>().RPC("weaponSound", RpcTarget.All, true);
                Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        MoveAimTarget();
    }

    void Shoot()
    {
        RaycastHit hit;
        MuzzleFlash.Play();
        this.GetComponent<PhotonView>().RPC("PlayEffects", RpcTarget.All, true);
        if (Physics.Raycast(RaycastPoint.transform.position, RaycastPoint.transform.forward, out hit, Range))
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

    public void MoveAimTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(RaycastPoint.transform.position, RaycastPoint.transform.forward, out hit, Range))
        {
            if (hit.collider)
            {
                AimTarget.transform.position = hit.transform.position;
            }
        }
    }

    [PunRPC]
    public void PlayEffects(bool firing, PhotonMessageInfo info)
    {
        if(firing)
        {
            MuzzleFlash.Play();
            audioSource.Play();
        }
    }
}
