using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Scr_Start : MonoBehaviour {

    public RectTransform panelStart;
    public RectTransform panelNouvelle;
    public RectTransform panelContinuer;
    public RectTransform panelRegles;
    public RectTransform panelQuit;


	// Use this for initialization
	void Start () {

        //PanelStart();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PanelStart() {
        panelStart.gameObject.SetActive(true); //TRUE
        panelNouvelle.gameObject.SetActive(false);
        panelContinuer.gameObject.SetActive(false);
        panelRegles.gameObject.SetActive(false);
        panelQuit.gameObject.SetActive(false);
    }

    public void Nouvelle(){
        panelStart.gameObject.SetActive(false);
        panelNouvelle.gameObject.SetActive(true); //TRUE
        panelContinuer.gameObject.SetActive(false);
        panelRegles.gameObject.SetActive(false);
        panelQuit.gameObject.SetActive(false);


    }

    public void Continuer(){

        //rajouter un if (bool continue state)
        panelStart.gameObject.SetActive(false);
        panelNouvelle.gameObject.SetActive(false);
        panelContinuer.gameObject.SetActive(true); //TRUE
        panelRegles.gameObject.SetActive(false);
        panelQuit.gameObject.SetActive(false);
    }

    public void Regles() {

        panelStart.gameObject.SetActive(false);
        panelNouvelle.gameObject.SetActive(false);
        panelContinuer.gameObject.SetActive(false);
        panelRegles.gameObject.SetActive(true); //TRUE
        panelQuit.gameObject.SetActive(false);
    }

    public void Quit(){

        Application.Quit();
    
    }




}//fin class
