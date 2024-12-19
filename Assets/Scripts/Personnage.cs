using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personnage : MonoBehaviour
{
    //configure la vie a 3
    private int _vie = 3;
    //fait un tableau de GameObject pour les différente position
    [SerializeField] private GameObject[] _position;
    //fait un tableau de SpriteRenderer pour les vie
    [SerializeField] private SpriteRenderer[] _spriteRendererVie;
    //fait une variable de Sprite pour les vie
    [SerializeField] private Sprite _spritesVie;
    [SerializeField] private GameObject _projectile;
    //créer une variable pour le Rigidbody2D
    private Rigidbody2D _rb2D;
    //va chercher le son pour les attaque
    [SerializeField] private AudioClip _sonAttaque;
    //va chercher le son pour les raccourci
    [SerializeField] private AudioClip _sonRaccourci;

    //les prochaine ligne et le awake, fond en sorte de pouvoir 
    //appeler une fonction dans un autre scripe de façon plus sur.
    private static Personnage _instance;
    public static Personnage instance
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
        //Appelle de fonctions sur le script Combinaison pour Charger la Combinaison
        Combinaison.instance.ChargerCombinaison();
        _rb2D = GetComponent<Rigidbody2D>();
    }
    //Fonction qui vérifie si le personnage rentre en colision avec un des piege
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Piege")
        {
            //appelle la fonction pour retirer de la vie
            RetierVie();
        }
    }
    //La fonction va retier les vie, va changer le sprite des vies, 
    //jouer le sons de la colison,va lancer lanimation de la voiture
    //Va lancer la fin du jeu 
    public void RetierVie()
    {
        _vie = _vie - 1;
        _spriteRendererVie[_vie].sprite = _spritesVie;
        if (_vie == 0)
        {
            SceneManager.LoadScene("Jeu");
        }
    }

    void Update()
    {
        Racourcie();
    }
    //Fonction vérifie si le prof triche pour sauter des salle
    //Fonction qui change la position du personne selon la touche appuier
    //Fonction qui vérifier la sourit pour l'attaque et fait jouer le sons
    private void Racourcie()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager.instance.Jouer(_sonRaccourci);
            SceneManager.LoadScene("Jeu");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            SoundManager.instance.Jouer(_sonRaccourci);
            transform.position = _position[0].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            SoundManager.instance.Jouer(_sonRaccourci);
            transform.position = _position[1].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            SoundManager.instance.Jouer(_sonRaccourci);
            transform.position = _position[2].transform.position;
            //Appelle de fonctions sur le script Boss pour l'activer
            Boss.instance.ActiverBoss();
        }
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.instance.Jouer(_sonAttaque);
            Attaquer();
        }
    }

    //Fonction qui fait l'attaque
    private void Attaquer()
    {
        Instantiate(_projectile, transform.position, Quaternion.identity);
    }
}
