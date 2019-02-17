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

	public GameObject HazardChoicePrefab;
	public GameObject hazardWindow;
	public TextMeshProUGUI hazardTitle;
	public TextMeshProUGUI HazardDescription;
	public Transform choiceLocation;

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
}
