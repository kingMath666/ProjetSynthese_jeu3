using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combinaison : MonoBehaviour
{
    //Configure un tableau avec les trois choix pour la combinaison
    static string[] _tChoix = { "Hache", "Livre", "Colier" };
    private GameObject[] _object;
    //variable pour créer une liste de mots
    private List<string> _choixListe;
    //variable pour créer une liste de mots
    private List<string> _combinaisonListe;
    //variable pour créer une liste de mots
    private List<string> _objectsListe;
    //Configure une Liste avec les emplacement de la combianaison
    [SerializeField] private List<SpriteRenderer> _spriteCombinaison;

    //Configure un tableau avec les sprite de la combianaison
    [SerializeField] private Sprite[] _tSpritesChoix;
    //variable pour créer une liste de Sprite
    private List<Sprite> _spritesChoix;
    // variable false de type boolien
    private bool _echec = false;
    //les prochaine ligne et le awake, fond en sorte de pouvoir 
    //appeler une fonction dans un autre scripe de façon plus sur.
    private static Combinaison _instance;
    public static Combinaison instance
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
    //Fonction qui va créer les liste
    //appele la fonction MelengerCombinaison
    public void ChargerCombinaison()
    {
        _choixListe = new List<string>(_tChoix);
        _spritesChoix = new List<Sprite>(_tSpritesChoix);
        _combinaisonListe = new List<string>();
        _objectsListe = new List<string>();
        MelengerCombinaison();
    }
    //Fonction qui melenge la combinaision. 
    private void MelengerCombinaison()
    {
        for (int i = 0; i < _tChoix.Length; i++)
        {
            int choix = Random.Range(0, _choixListe.Count);
            _spriteCombinaison[i].sprite = _spritesChoix[choix];
            _combinaisonListe.Add(_choixListe[choix]);
            _choixListe.RemoveAt(choix);
            _spritesChoix.RemoveAt(choix);
        }
    }

    //Fonction qui récolete le nom des object que le personnage a toucher
    public void RammasserObject(string Object)
    {
        _objectsListe.Add(Object);
        if (_objectsListe.Count == 3)
        {
            VérifierCombinaision();
        }
    }
    //Fonction qui vérifie si la combinaison 
    //et la liste de object récupérer est la meme 
    private void VérifierCombinaision()
    {
        int motBon = 0;
        for (int i = 0; i < _objectsListe.Count; i++)
        {
            if (_objectsListe[i] == _combinaisonListe[i])
            {
                motBon++;
            }
            else
            {
                _echec = true;
            }
        }
        if (motBon == 3)
        {
            Porte.instance.DesactiverPorte();
        }
        if (_echec)
        {
            Object.instance.PlacerObject();
            _choixListe.Clear();
            _combinaisonListe.Clear();
            _objectsListe.Clear();
            ChargerCombinaison();
        }
    }
}