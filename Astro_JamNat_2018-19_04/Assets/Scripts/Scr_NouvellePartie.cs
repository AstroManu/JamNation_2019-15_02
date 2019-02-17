using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scr_NouvellePartie : MonoBehaviour {

    public TMP_InputField InputField;
    public int nbrPlayer;
    public GameObject playerIcon;
    public GridLayoutGroup playerGroup;
    public Button StartButton;


    // Use this for initialization
    void Start () {

        InputField.characterLimit = 1;
		
	}
	
	// Update is called once per frame
	void Update () {


        if (nbrPlayer > 6)
            nbrPlayer = 6;
	}

    public void NbrPlayer () {

        int.TryParse(InputField.text, out nbrPlayer);
    
    }

    public void InstancePlayerIcon () {

        for (int i = 0; i < nbrPlayer; i++) {
            Instantiate(playerIcon, playerGroup.transform);
        }

        StartButton.gameObject.SetActive(true);
    }

    public void LoadScene () {

        SceneManager.LoadScene("Match");
    }
} //fin class
