using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManagerRPGUI : MonoBehaviourPunCallbacks
{

    [SerializeField]
    GameObject playerPrefab;

    public static GameManagerRPGUI instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        if (PhotonNetwork.IsConnected)
        {
            if (playerPrefab != null)
            {
                int randomPointX = Random.Range(-5, 15);
                int randomPointZ = Random.Range(5, -17);

                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(randomPointX, 0, randomPointZ), Quaternion.identity);
            }
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnLeftRoom()
    {
        //TODO enable when shooting system is working
        //TODO also, put a button or something like that to start the scene when needed.
        //SceneManager.LoadScene("LauncherScene");
    }


    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
