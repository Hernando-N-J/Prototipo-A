using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovePlayer : MonoBehaviour
{
    public static bool movementStatic = false;


  public float speed = 10f;
  public float speedRot = 20f;

[SerializeField]
  private Vector3 positionStartPlayer ;


  void Start()
  {
      positionStartPlayer = transform.position;
      print(positionStartPlayer);
  }

  public void RestPositionPlayer()
  {
    transform.position = positionStartPlayer;
    movementStatic = false;
  }

     void Update()
     {
         if(movementStatic)
         {
            if(Input.GetKey(KeyCode.W)) 
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
         
            if(Input.GetKey(KeyCode.S)) 
            transform.Translate( -1 * Vector3.forward * Time.deltaTime * speed);
         
            if(Input.GetKey(KeyCode.A)) 
            transform.Rotate(0,-speedRot,0); 
         
            if(Input.GetKey(KeyCode.D)) 
            transform.Rotate(0,speedRot,0); 
         }
         
     }
   
}

