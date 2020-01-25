using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PauseGameHandler : MonoBehaviourPunCallbacks
{

    public void LeaveGame()
    {
        PhotonNetwork.LoadLevel("LobbyScene");
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.LeaveRoom();
    }

    public void ReturnGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.gameObject.SetActive(false);
    }
}
