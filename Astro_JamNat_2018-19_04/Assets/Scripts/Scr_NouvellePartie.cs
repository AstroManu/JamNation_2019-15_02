using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scr_NouvellePartie : MonoBehaviour {

    public Button enter;
    public TMP_InputField InputField;
    public int nbrPlayer;
    public GameObject playerIcon;
    public GridLayoutGroup playerGroup;
    public Button StartButton;


    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
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
