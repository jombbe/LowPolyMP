using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviourPunCallbacks
{
    public float HeadDamage;
    public float ChestDamage;
    public float LegsDamage;

    [SerializeField]
    Text HpText;

    [SerializeField]
    GameObject Cam;

    [SerializeField]
    GameObject PauseGameCanvas;

    [SerializeField]
    GameObject RespawnPanel;
    [SerializeField]
    Text RespawnTimeText;

    [SerializeField]
    GameObject[] spawnPoints;

    [SerializeField]
    GameObject playerGraphics;


    [SerializeField]
    Image healtBar;

    [SerializeField]
    Image powerBar;

    
    public float respawnTimer;

    public bool isdead;
    
    public float respawnTime = 5f;


    public float Power;
    public float StartPower = 100f;

    public float Health;
    public float StartHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Health = StartHealth;
        respawnTimer = respawnTime;
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");

    }

    // Update is called once per frame
    void Update()
    {
        if(isdead)
        {
            respawnTimer -= Time.deltaTime;
            RespawnTimeText.text = respawnTimer.ToString("0");
        }

        if(respawnTimer < 0f)
        {
            Respawn();
        }
            

        healtBar.fillAmount = Health / StartHealth;
        HpText.text = Health.ToString();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGameCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }       
    }

    [PunRPC]
    public void TakeDamage(string bodypart, PhotonMessageInfo info)
    {
        if (bodypart == "Head" && Health > 0f)
        {
            Health -= HeadDamage;
        }

        if (bodypart == "Chest" && Health > 0f)
        {
            Health -= ChestDamage;
        }

        if (bodypart == "Legs" && Health > 0f)
        {
            Health -= LegsDamage;
        }

        if (Health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        isdead = true;
        RespawnPanel.SetActive(true);
        this.gameObject.GetComponent<PlayerMovementV2>().enabled = false;
        Cam.GetComponent<MouseLook>().enabled = false;
    }

    public void Respawn()
    {
        GameObject RandomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        this.gameObject.transform.position = RandomSpawnPoint.transform.position;
        respawnTimer = respawnTime;
        this.gameObject.GetComponent<PlayerMovementV2>().enabled = true;
        Cam.GetComponent<MouseLook>().enabled = true;  
        RespawnPanel.SetActive(false);
        isdead = false;
        Health = StartHealth;
    }

}
