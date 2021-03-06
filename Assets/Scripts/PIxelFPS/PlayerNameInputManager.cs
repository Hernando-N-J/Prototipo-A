using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInputManager : MonoBehaviour
{
    public bool hasPlayerName;
    public void SetPlayerName(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Player name is empty");
            hasPlayerName = false;
        }

        PhotonNetwork.NickName = playerName;
        hasPlayerName = true;
    }

    //public static string Name;
    //private GameObject Dings;

    //public void Run()
    //{
    //    print(PhotonNetwork.player.NickName);
    //    Name = gameObject.GetComponent().text;
    //    PhotonNetwork.player.NickName = Name;
    //    print(PhotonNetwork.player.NickName);
    //}

}
