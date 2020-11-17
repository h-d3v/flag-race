using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonVehiculeCtrl : MonoBehaviour
{
    private JeuCtrl jeuCrtl;
    //Le script qui s'occupe de a physqiue et de tout le mechanisme de la voiture est dans MSVehiculeSystem
    //Ce script servira a ce que je veux ajouter a la voiture
    // Start is called before the first frame update
    void Start()
    {
        jeuCrtl=GameObject.Find("JeuCtrl").GetComponent<JeuCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider objet)
    {

        if (objet.tag == "BonPays") {
            print("bonne rep");
            Debug.Log("bonne rep!!");
            jeuCrtl.StartCoroutine("BonneRepCoroutine");
        }

        else if(objet.tag=="Pays"){
            Debug.Log("mauvaise rep");
            jeuCrtl.MauvaiseRep();
        }
    }
}
