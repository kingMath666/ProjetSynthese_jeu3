using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    // varriable pour allez chercher mon personnage
    [SerializeField] private Personnage _perso;
    //configure la vie a 3
    private int _vie = 3;
    //fait un tableau de SpriteRenderer pour les vie
    [SerializeField] private SpriteRenderer[] _spriteRendererVie;
    //fait une variable de Sprite pour les vie
    [SerializeField] private Sprite _spritesVie;
    //créer une variable pour le Vector3
    private Vector3 _targetPerso;
    //configure la vitesse a 2f
    private float _vitesse = 2f;
    //les prochaine ligne et le awake, fond en sorte de pouvoir 
    //appeler une fonction dans un autre scripe de façon plus sur.
    private static Boss _instance;
    public static Boss instance
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

    void Start()
    {
        //désactivie le boss
        gameObject.SetActive(false);
    }
    //Fonction qui réactive le boss
    public void ActiverBoss()
    {
        gameObject.SetActive(true);
    }
    //Fonction qui fait le mouvement
    void Update()
    {
        _targetPerso = _perso.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, _targetPerso, _vitesse * Time.deltaTime);
    }
    //Fonction qui vérifie si le personnage rentre en colision avec le boss
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Perso")
        {
            //appelle la fonction pour retirer de la vie
            Personnage.instance.RetierVie();
        }
    }

    //La fonction va retier les vie, va changer le sprite des vies, 
    //Va lancer la fin du jeu 
    public void RetierVie()
    {
        _vie = _vie - 1;
        _spriteRendererVie[_vie].sprite = _spritesVie;
        if (_vie == 0)
        {
            SceneManager.LoadScene("Fin");
        }
    }
}
