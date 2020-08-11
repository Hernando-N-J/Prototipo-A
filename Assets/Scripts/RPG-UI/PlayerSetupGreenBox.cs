using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.Linq.Expressions;

public class PlayerSetupGreenBox : MonoBehaviourPunCallbacks
{

    [SerializeField] GameObject PlayerCamera;

    [SerializeField] TextMeshProUGUI playerNameText;

    public GameObject canvasGO;

    //Animator animator;


    void Start()
    {
        if (photonView.IsMine)
        {
            //animator = GetComponent<Animator>();

            Debug.Log("*** Player setup/photonView. Is mine");
            //transform.GetComponent<MovementController>().enabled = true;
            PlayerCamera.GetComponent<Camera>().enabled = true;
            Debug.Log("Camera enabled by:" + photonView.Owner.NickName);
            PlayerCamera.GetComponent<Camera>().GetComponent<AudioListener>().enabled = true;
            Debug.Log("*** Audio listener enabled by:" + photonView.Owner.NickName);
            canvasGO.SetActive(true);
        }
        else
        {
            PlayerCamera.GetComponent<Camera>().enabled = false;
            Debug.Log("Camera disabled by: " + photonView.Owner.NickName);
            PlayerCamera.GetComponent<Camera>().GetComponent<AudioListener>().enabled = false;
            Debug.Log("*** Audio listener disabled by:" + photonView.Owner.NickName);
            canvasGO.SetActive(false);
        }

        SetPlayerUI();
    }

    void SetPlayerUI()
    {
        if (playerNameText != null) playerNameText.text = photonView.Owner.NickName;
    }

}
