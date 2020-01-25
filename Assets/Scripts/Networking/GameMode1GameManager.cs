using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameMode1GameManager : MonoBehaviour
{

    public GameObject[] PlayerPrefabs;
    public Transform[] SpawnPositions;

    // Start is called before the first frame update
    void Start()
    {

        if(PhotonNetwork.IsConnectedAndReady)
        {
            object playerSelectionNumber;
            if(PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(MultiplayerGame.PLAYER_SELECTION_NUMBER, out playerSelectionNumber))
            {
                Transform RandomSpawn = SpawnPositions[Random.Range(0, SpawnPositions.Length)];
                PhotonNetwork.Instantiate(PlayerPrefabs[(int)playerSelectionNumber].name, RandomSpawn.transform.position, Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
