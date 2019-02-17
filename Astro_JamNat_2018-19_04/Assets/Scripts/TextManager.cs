using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour {

	#region Singleton
	public static TextManager instance;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
	#endregion

	public TextMeshProUGUI title;
	public TextMeshProUGUI rules;
	public TextMeshProUGUI hazards;
	public TextMeshProUGUI description;

	public GameObject HazardChoicePrefab;
	public GameObject hazardWindow;
    public TextMeshProUGUI hazardTitle;
	public TextMeshProUGUI HazardDescription;
	public Transform choiceLocation;
    public GameObject PlayerButtonPrefab;
    public GameObject endGameWindow;
    public Transform playerWinnerLocation;
	public GameObject nextTurnButton;
	public GameObject evolutionsGenesWindow;

	public void SetTitle(string text)
	{
		title.text = text;
	}

	public void SetRules(string text)
	{
		rules.text = text;
	}

	public void SetHazards(string text)
	{
		hazards.text = text;
	}

	public void SetDescription(string text)
	{
		description.text = text;
	}

	public void DisplayHazard(Hazard hazard)
	{
		hazardWindow.SetActive(true);
		hazardTitle.text = hazard.hazardName;
		HazardDescription.text = hazard.hazardDescription;

		//Choice
		if (hazard.inputChoice.Length > 0)
		{
			for (int i = 0; i < hazard.inputChoice.Length; i++)
			{
				HazardChoice hc = Instantiate(HazardChoicePrefab, choiceLocation).GetComponent<HazardChoice>();
				hc.Init(hazard.inputChoice[i]);
			}
		}

		//Else continue button\
		else
		{
			HazardChoice hc = Instantiate(HazardChoicePrefab, choiceLocation).GetComponent<HazardChoice>();
			hc.Init("Got it");
		}
	}

	public void CloseHazard()
	{
		//Destroy all old choices
		foreach (Transform t in choiceLocation)
		{
			Destroy(t.gameObject);
		}

		hazardWindow.SetActive(false);

	}

    public void EndMatch()
    {
        //Init
        CloseHazard();

        //Open
        endGameWindow.SetActive(true);

        //Create player button
        string[] names = MatchManager.instance.GetPlayerName();
        for (int i = 0; i < names.Length; i++)
        {
            CustomButton cb = Instantiate(PlayerButtonPrefab, playerWinnerLocation).GetComponent<CustomButton>();
            cb.id = i;
            cb.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = names[i];
        }
    }

    public void CloseEndMatch()
    {
        //Destroy all old choices
        foreach (Transform t in playerWinnerLocation)
        {
            Destroy(t.gameObject);
        }

        endGameWindow.SetActive(false);

    }

	public void EvolutionWindow()
	{
		evolutionsGenesWindow.SetActive(true);
	}

	public void CloseEvolutionWindow()
	{
		evolutionsGenesWindow.SetActive(false);
		ShowHideNextTurnButton(true);
	}

    public string GetAdaptationCode(Adaptation a)
    {
        switch(a)
        {
            case Adaptation.Aquatique:
                return "ain";

            case Adaptation.Chaud:
                return "ach";

            case Adaptation.Famine:
                return "afa";

            case Adaptation.Froid:
                return "afr";

            case Adaptation.Maladie:
                return "ama";

            case Adaptation.Secheresse:
                return "ase";

            case Adaptation.Predator:
                return "apr";
        }

        return "";
    }

    public string GetGeneCode(Gene g)
    {
        switch (g)
        {
            case Gene.Bleu:
                return "gb";

            case Gene.Orange:
                return "go";

            case Gene.Mauve:
                return "gm";

            case Gene.Vert:
                return "gv";
        }

        return "";
    }

	public void ShowHideNextTurnButton(bool show)
	{
		nextTurnButton.SetActive(show);
		nextTurnButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Fin du Tour " + (MatchManager.instance.GetNbTurn() + 1);
	}
}
