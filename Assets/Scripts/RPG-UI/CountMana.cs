using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountMana : MonoBehaviour
{

  public Image circleMana ;
  float minMana = 0;
  float maxMana = 200f;
  public static float mana;

  public Text textMana;
  public Text textGlobal;

  butonsAction botonsAction;

 
  void Start()
  {
      textGlobal.text = "";
      textMana.text = ""+mana;
      mana = maxMana;
      botonsAction = GetComponent<butonsAction>();
      
  }
  
  public void ResetMana()
  {
      minMana = 0;
      textMana.text = ""+minMana;
      textGlobal.text = "";
  }

void Update()
{
    circleMana.fillAmount = minMana;
}

public void GetMana()
{
    if(minMana < 1)
    {
        minMana += 0.1f;
        textMana.text = ""+minMana;
            if(minMana >= 0.2 && minMana <= 0.29 )
            {
                textGlobal.text =  "Habilidad de MOVIMIENTO Habilitada";
                botonsAction.move.interactable = true;
            }
            else if(minMana >= 0.5 && minMana <= 0.59)
            {
                textGlobal.text =  "Habilidad de ARMAS habilitada";
                botonsAction.armas.interactable = true;
            }
            else if (minMana >= 0.9 && minMana <= 1)
            {
                textGlobal.text =  "Habilidad de DISPARO habilitada";
                botonsAction.shoot.interactable = true;
            }


        }
    else
    {
        textGlobal.text = "Tiene el maximo de mana";
    }
   
}

}
