using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //va chercher l'audio source
    private AudioSource _audio;
    //les prochaine ligne et le awake, fond en sorte de pouvoir 
    //appeler une fonction dans un autre scripe de façon plus sur.
    private static SoundManager _instance;
    public static SoundManager instance
    {
        get { return _instance; }
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
        //va chercher le getcomponent de l'audisource
        _audio = GetComponent<AudioSource>();
        //empeche la destruction de l'objet d'une scene a l'autre
        DontDestroyOnLoad(gameObject);
    }
    //la fonction fait jouer toute les sons du jeux avec l'apelle de dautre scripte
    public void Jouer(AudioClip clip, float volume = 1f)
    {
        _audio.PlayOneShot(clip, volume);
    }


}
