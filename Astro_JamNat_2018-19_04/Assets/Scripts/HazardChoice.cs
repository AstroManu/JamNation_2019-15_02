using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HazardChoice : MonoBehaviour {

	public TextMeshProUGUI text;

	public void Init(string t)
	{
		text.text = t;
	}

	public void OnPress()
	{
		MatchManager.instance.SetHazardAnswer(new string[] { text.text });
	}
}
