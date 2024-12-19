using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;

public class Porte : MonoBehaviour
{
    //les prochaine ligne et le awake, fond en sorte de pouvoir 
    //appeler une fonction dans un autre scripe de façon plus sur.
    private static Porte _instance;
    public static Porte instance
    {
        get
        {
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Fonction qui va désactiver la porte
    public void DesactiverPorte()
    {
        gameObject.SetActive(false);
        //Appelle de fonctions sur le script Boss pour l'activer
        Boss.instance.ActiverBoss();
    }
}
