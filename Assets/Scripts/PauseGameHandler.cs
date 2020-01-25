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
        Time.timeScale = 1;
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.gameObject.SetActive(false);
    }
}
