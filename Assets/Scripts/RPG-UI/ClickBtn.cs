using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI
{
public class ClickBtn : MonoBehaviour
{
    public Text txtMns;
    void Start()
    {
        txtMns.text = null;
    }

    public void ChangeMessage(string txtString)
    {
            txtMns.text = txtString;
    }
}

}

