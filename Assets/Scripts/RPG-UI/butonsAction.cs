using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class butonsAction : MonoBehaviour
{
    //botones que pertenecen a la barra inferior
   public Button btnMove;
   public Button btnArms;
   public Button btnShoot;

    //botones que pertenecen al menu de compra habilidades
    public Button move;
    public Button armas;
    public Button shoot;

    //elementos del player
    public GameObject arm1;
    public GameObject arm2;
  
   void Start()
   {
    BtnsActionsOff();
    ArmsPlayerOff();
   }

   public void BtnsActionsOff()
   {
       btnMove.interactable = false;
       btnArms.interactable = false;
       btnShoot.interactable = false;

       move.interactable = false;
       armas.interactable = false;
       shoot.interactable = false;
   }

   public void ArmsPlayerOff()
   {
       arm1.SetActive(false);
       arm2.SetActive(false);
   }

  public void OnMovement()
    {
        btnMove.interactable = true;
        MovePlayer.movementStatic = true;
    }

    public void OnActiveArmas()
    {
        btnArms.interactable = true;
        arm1.SetActive(true);
        arm2.SetActive(true);
    }

    public void OnActiveShoot()
    {
        btnShoot.interactable = true;
        Press_Space_to_Fire.shootStatic = true;
    }



}
