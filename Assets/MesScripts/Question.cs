using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question 
{
    

    public string Continant{get; set;}
    
    public List<Pays> PaysQst{get; set;}
   
    public bool BonneRep{get; set;}
    public  Question(string nomCont, Pays pays1, Pays pays2, Pays pays3)
    {
        Continant=nomCont;
        PaysQst= new List<Pays>();
        PaysQst.Add(pays1);
        PaysQst.Add(pays2);
        PaysQst.Add(pays3);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //aide a verifier si le joueur a choisi le pays correspondant a celui de la question
    public bool checkBonneReponse(Pays paysChoisi){
        return Continant==paysChoisi.NomContinant ? true:false;
    }


}
