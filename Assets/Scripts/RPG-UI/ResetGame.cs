using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{

   public MovePlayer movePlayer;
   public butonsAction bottonAction;
   public CountMana countMana;

  
   void Start()
   {
       //movePlayer = GetComponent<MovePlayer>();
       bottonAction = GetComponent<butonsAction>();
       countMana = GetComponent<CountMana>();
   }
   
   public void ResetAll()
   {
       movePlayer.RestPositionPlayer();
       Press_Space_to_Fire.shootStatic = false;
       bottonAction.ArmsPlayerOff();
       bottonAction.BtnsActionsOff();
       countMana.ResetMana();
   }
}
