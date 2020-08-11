using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Animator ani;
    bool abc = false;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void  MostrarShoop()
    {
        ani.SetBool("mostrar", true);
        ani.SetBool("ocultar", false);
        
    }

    public void OcultarShoop()
    {
        ani.SetBool("mostrar", false);
        ani.SetBool("ocultar", true);
        
    }

    public void ShoopItems()
    {
        abc = !abc;
        if(abc)
        {
            MostrarShoop();
            print("ACTIVADO");
        }
        else
        {
            OcultarShoop();
            print("DESACTIVADO");
        }
    }
}
