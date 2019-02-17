using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Scr_Start : MonoBehaviour {

    public RectTransform panelStart;
    public RectTransform panelNouvelle;
    public RectTransform panelRegles;
    public RectTransform panelQuit;

    public bool isContinue = false;
    public GameObject lockImage;
    public Button continuerPartie;


	// Use this for initialization
	void Start () {


        PanelStart();

        //Determine si on peux acceder au continuer
        if (isContinue == false) {
            lockImage.SetActive(true);
            continuerPartie.IsInteractable();
            continuerPartie.transition = Selectable.Transition.None;
        } else {
            lockImage.SetActive(false);
            continuerPartie.IsInteractable();
            continuerPartie.transition = Selectable.Transition.ColorTint;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PanelStart() {
        panelStart.gameObject.SetActive(true); //TRUE
        panelNouvelle.gameObject.SetActive(false);
        panelRegles.gameObject.SetActive(false);
        panelQuit.gameObject.SetActive(false);
    }

    public void Nouvelle(){
        panelStart.gameObject.SetActive(false);
        panelNouvelle.gameObject.SetActive(true); //TRUE
        panelRegles.gameObject.SetActive(false);
        panelQuit.gameObject.SetActive(false);


    }


    public void Regles() {

        panelStart.gameObject.SetActive(false);
        panelNouvelle.gameObject.SetActive(false);
        panelRegles.gameObject.SetActive(true); //TRUE
        panelQuit.gameObject.SetActive(false);
    }

    public void Quit(){

        Application.Quit();
    
    }




}//fin class
