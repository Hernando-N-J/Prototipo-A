using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject EnterGamePanel;
    public GameObject ConnectionStatusPanel;
    public GameObject LobbyPanel;


    #region Unity Methods
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        EnterGamePanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
        LobbyPanel.SetActive(false);
    }

    #endregion

    #region Public Methods
    public void ConnectToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // Find a random room to join. if there is not available room, a callback method - OnJoinRandomFailed - will be called
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    #endregion


    #region Photon Callbacks
    public override void OnConnected()
    {
        Debug.Log("--- OnConnected() --- Connected to Internet --- (low level connection)");
    }

    public override void OnConnectedToMaster()
    {
        LobbyPanel.SetActive(true);
        ConnectionStatusPanel.SetActive(false);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Scene-RPG-UI");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateAndJoinRoom();
    }

    #endregion


    #region Private methods
    void CreateAndJoinRoom()
    {
        string randomRoomName = "Room: " + Random.Range(0, 1000);
        var roomOptions = new RoomOptions { IsOpen = true, IsVisible = true, MaxPlayers = 20 };

        PhotonNetwork.CreateRoom(randomRoomName,roomOptions);
    }

    #endregion
}
      