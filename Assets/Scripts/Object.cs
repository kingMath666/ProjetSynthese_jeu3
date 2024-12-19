using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //les prochaine ligne et le awake, fond en sorte de pouvoir 
    //appeler une fonction dans un autre scripe de façon plus sur.
    private static Object _instance;
    public static Object instance
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
    }
    //Fonction qui vérifie si le personnage rentre en colision avec un des objects
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Perso")
        {
            //Appelle de fonctions sur le script Combinaison pour créer un tableau de vérification
            Combinaison.instance.RammasserObject(gameObject.name);
            //désactivie l'object
            gameObject.SetActive(false);
        }
    }


    void Start()
    {
        //appele de fonction PlacerObject
        PlacerObject();
    }

    public void PlacerObject()
    {
        //Fonction qui réactive les object
        //place aussi aléatoirment en Y
        gameObject.SetActive(true);
        float posY = Random.Range(3.5f, 7.5f);
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }

}