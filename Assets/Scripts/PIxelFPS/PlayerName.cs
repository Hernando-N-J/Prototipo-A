using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public InputField nameInpF;
    public Button setNameBtn;

    public void OnNameInpFChanged(string name)
    {

    }

    public void OnClick_SetName()
    {
        PhotonNetwork.NickName = nameInpF.text;
    }
}
