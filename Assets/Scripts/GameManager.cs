using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //va chercher le son pour les bouton
    [SerializeField] private AudioClip _sonBouton;
    //les prochaine ligne et le awake, fond en sorte de pouvoir 
    //appeler une fonction dans un autre scripe de façon plus sur.
    private static GameManager _instance;
    public static GameManager instance
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
    //Fonction pour changer de scene
    public void Aller(string nomScene)
    {
        SoundManager.instance.Jouer(_sonBouton);
        SceneManager.LoadScene(nomScene);
    }

}