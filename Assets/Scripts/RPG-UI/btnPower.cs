using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.UI;

public class btnPower : MonoBehaviour
{
 
 public Text txtbtn;

 public Text myText;



void Start()
{
    myText = GetComponentInChildren<Text>();
   
}
 
public void ChangeMessage()
{
    txtbtn.text = myText.text;

}

public void ActivarDisparo()
{
   
}

  
}
