using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege : MonoBehaviour
{

    void Start()
    {
        //appelle la fonction pour désactiver le piege
        DispationPiege();
    }
    //Fonction qui va activer le piege
    private void ApparitonPiege()
    {
        gameObject.SetActive(true);
        //appelle la fonction pour désactiver le piege au 2sec
        Invoke("DispationPiege", 2f);
    }
    //Fonction qui va désactiver le piege
    private void DispationPiege()
    {
        gameObject.SetActive(false);
        //appelle la fonction pour activer le piege au 2sec
        Invoke("ApparitonPiege", 2f);
    }
}
