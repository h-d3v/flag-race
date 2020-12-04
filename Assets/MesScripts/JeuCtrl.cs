using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class JeuCtrl : MonoBehaviour
{
    private bool partieEnCours;
    private int nbBonneRep;
    private int nbMauvaiseRep;

    private GameObject imgAfrique;
    private GameObject imgAsie;
    private GameObject imgAmeriqueN;
    private GameObject imgAmeriqueS;
    private GameObject imgOceanie;
    private GameObject imgEurope;
    private GameObject panelMsgDebutPartie, panelMsgBonneRep;
    private AudioSource audioSource;
    private Text txtTmpRestant;

    private Text txtNbQstRestantes;
    [SerializeField] GameObject hud; //Canvas qui va permettre d'afficher des infos importantes au joueur.

    [SerializeField] GameObject ecranPartieGagnee;

    //Represente l'ensemble des groupes de drapeaux pour les questions de chaque partie
    //il est a noter que dans un groupe de drapeaux, il doit y avoir 3 pays de diferrents continents
    //aussi, je ne veut pas que le meme pays se repete dans la carte deux fois pour des raisons d'apprendtissage
    
    [SerializeField] List<GameObject> listeGpDrapeaux;
    [SerializeField] GameObject ecranPartiePerdue;

    [SerializeField] AudioClip sonErreur;

    [SerializeField] AudioClip sonBonneRep;
    
    //secondes pour le timer
    [SerializeField] float secondesPartie;
 


    // Start is called before the first frame update
    void Start()
    {
        InitialiserPartie();
        StartCoroutine("DebuterPartieCoroutine");

    }

    // Update is called once per frame
    void Update()
    {
       
        //verifie si le compteur atteint sa fin
        if(secondesPartie<=0)
        {
            GameOver();
            txtTmpRestant.text="0";
        }

         txtNbQstRestantes.text=(listeGpDrapeaux.Count-nbBonneRep-nbMauvaiseRep).ToString();

    }



    //initiliase les variables necessaires au jeu
    private void InitialiserPartie()
    {
        audioSource=this.GetComponent<AudioSource>();
        //initialise tous les GameObject fesant partie du ui
        //si je fait GameObject.Find("nom de l'objet, ca me fait un Object not found exception")
        //appart pour les champs de text
        txtNbQstRestantes=GameObject.Find("TxtQstRestante").GetComponent<Text>();
        txtTmpRestant= GameObject.Find("TxtTempsRestant").GetComponent<Text>();
        panelMsgDebutPartie = hud.transform.Find("PanelMsgDebutPartie").gameObject;
        panelMsgBonneRep = hud.transform.Find("PanelMsgBonneRep").gameObject;
        imgAfrique=hud.transform.Find("ImgAfrique").gameObject;
        imgAsie=hud.transform.Find("ImgAsie").gameObject;
        imgAmeriqueN=hud.transform.Find("ImgAmeriqueNord").gameObject;
        imgOceanie=hud.transform.Find("ImgOceanie").gameObject;
        imgAmeriqueS=hud.transform.Find("ImgAmeriqueSud").gameObject;
        imgEurope=hud.transform.Find("ImgEurope").gameObject;
    }
    

    private IEnumerator DebuterPartieCoroutine()
    {
        //TODO initialiser le compteur de temps
        
        partieEnCours=true;
        panelMsgDebutPartie.SetActive(true);
        yield return new WaitForSeconds(8f);
        panelMsgDebutPartie.SetActive(false);

        txtTmpRestant.text=secondesPartie.ToString();
        StartCoroutine("DecrementTimer");

        //on montre la premier groupe de drapeeaux avec son continent
        imgAfrique.SetActive(true);
        listeGpDrapeaux[0].SetActive(true);

        nbBonneRep = 0;
    }

    private void GagnerPartie()
    {
        partieEnCours=false;
        //todo jouer une musique de gagnant
        ecranPartieGagnee.SetActive(true);
    }

    //lorsque la partie est perdue
    public void GameOver()
    {
        partieEnCours=false;
        ecranPartiePerdue.SetActive(true);
    }


    //pour chaque question, on affiche le set de drapeaux et l'image du continent
    public IEnumerator BonneRepCoroutine()
    {
        if(partieEnCours){
        audioSource.clip=sonBonneRep;
        audioSource.Play();
        
        nbBonneRep += 1;
        switch (nbBonneRep)
        {
            case 1:
                imgAfrique.SetActive(false); //desactive l'image du continent courrant
                listeGpDrapeaux[0].SetActive(false); //deasactive le groupe de drapeaux de la question courrant
                panelMsgBonneRep.SetActive(true); //active le msg de bonne reponse
                yield return new WaitForSeconds(6f); //attends 6 seconde
                panelMsgBonneRep.SetActive(false); //desactive le msg de bonne rep
                imgAsie.SetActive(true); //active l'image du nouveau continant
                listeGpDrapeaux[1].SetActive(true); //active le groupe de drapeaux de la nouvelle question
                break;

            case 2: 
                imgAsie.SetActive(false); //desactive l'image du continent courrant
                listeGpDrapeaux[1].SetActive(false); //deasactive le groupe de drapeaux de la question courrant
                panelMsgBonneRep.SetActive(true);
                yield return new WaitForSeconds(6f);
                panelMsgBonneRep.SetActive(false);
                imgAmeriqueN.SetActive(true); //active l'image du nouveau continant
                listeGpDrapeaux[2].SetActive(true); //active le groupe de drapeaux de la nouvelle question
                break;

             case 3: 
                imgAmeriqueN.SetActive(false); //desactive l'image du continent courrant
                listeGpDrapeaux[2].SetActive(false); //deasactive le groupe de drapeaux de la question courrant
                panelMsgBonneRep.SetActive(true);
                yield return new WaitForSeconds(6f);
                panelMsgBonneRep.SetActive(false);
                imgOceanie.SetActive(true); //active l'image du nouveau continant
                listeGpDrapeaux[3].SetActive(true); //active le groupe de drapeaux de la nouvelle question
                break;

            case 4: 
                imgOceanie.SetActive(false); //desactive l'image du continent courrant
                listeGpDrapeaux[3].SetActive(false); //deasactive le groupe de drapeaux de la question courrant
                panelMsgBonneRep.SetActive(true);
                yield return new WaitForSeconds(6f);
                panelMsgBonneRep.SetActive(false);
                imgAmeriqueS.SetActive(true); //active l'image du nouveau continant
                listeGpDrapeaux[4].SetActive(true); //active le groupe de drapeaux de la nouvelle question
                break;

            case 5: 
                imgAmeriqueS.SetActive(false); //desactive l'image du continent courrant
                listeGpDrapeaux[4].SetActive(false); //deasactive le groupe de drapeaux de la question courrant
                panelMsgBonneRep.SetActive(true);
                yield return new WaitForSeconds(6f);
                panelMsgBonneRep.SetActive(false);
                imgEurope.SetActive(true); //active l'image du nouveau continant
                listeGpDrapeaux[5].SetActive(true); //active le groupe de drapeaux de la nouvelle question
                break;

            case 6: 
                imgEurope.SetActive(false); //desactive l'image du continent courrant
                listeGpDrapeaux[5].SetActive(false); //deasactive le groupe de drapeaux de la question courrant
                GagnerPartie();
                break;
        }
    }

    }

//pour l'insatant, une seule mauvaise reponse suffit pour perdre la partie
//donc pour l'insatant cette methode ne sert pas a grand chose.
//possibilit de tolerer plusieurs mauvaises réponses
    public void MauvaiseRep()
    {
        if(partieEnCours){
            audioSource.clip=sonErreur;
            audioSource.Play();
            GameOver();
        }
    }

    public IEnumerator DecrementTimer()
    {
        while(partieEnCours){
            yield return new WaitForSeconds(0.1f);
            secondesPartie-=0.1f;
            txtTmpRestant.text=Math.Round(secondesPartie, 1).ToString();
        }
    }
}
