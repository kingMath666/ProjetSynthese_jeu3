using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Vitesse de projectile de 20f
    private float _vitesse = 20f;
    //Varriable vector 3 pour la cible
    private Vector3 _target;

    //Fonction pour définir la cible
    void Awake()
    {
        _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Start()
    {
        //appele de fonction pour détruir le projectil au 2sec
        Invoke("DetruirProjectil", 2f);
    }
    //fonction qui fait le déplacement. 
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, _vitesse * Time.deltaTime);
        if (Vector2.Distance(transform.position, _target) < 0.1f) DetruirProjectil();
    }
    //Fonction qui vérifie si le personnage rentre en colision avec le Boss
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Boss")
        {
            Boss.instance.RetierVie();
            DetruirProjectil();
        }
    }
    //Fonction pour détruir le projectile. 
    private void DetruirProjectil()
    {
        Destroy(gameObject);
    }
}