using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    //configure la vitesse a 5f
    private float _vitesse = 5f;
    //créer une variable pour le Rigidbody2D
    private Rigidbody2D _rb2D;
    //créer une variable pour le Vector3
    private Vector3 _axis;
    //créer une variable pour le Animator
    private Animator _anim;
    //Fonction qui va chercher le Rigidbody2D et le Animator du personnage
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    //Fonction qui configure le mouvement et les animation
    //Fait les animation
    void Update()
    {
        _axis.x = Input.GetAxisRaw("Horizontal");
        _axis.y = Input.GetAxisRaw("Vertical");
        _axis.Normalize();

        _anim.SetFloat("Horizontal", _axis.x);
        _anim.SetFloat("Vertical", _axis.y);
        _anim.SetFloat("Magnitude", _axis.magnitude);

        if (_axis.magnitude != 0)
        {
            _anim.SetFloat("LastHorizontal", _axis.x);
            _anim.SetFloat("LastVertical", _axis.y);
        }

    }
    //Fonction qui fait le mouvement
    void FixedUpdate()
    {
        _rb2D.MovePosition(transform.position + _axis * _vitesse * Time.fixedDeltaTime);
    }

}