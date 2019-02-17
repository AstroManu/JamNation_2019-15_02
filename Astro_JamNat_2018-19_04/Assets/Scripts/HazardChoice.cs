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
        //END
        if(text.text.Equals("Continuer"))
        {
            TextManager.instance.EndMatch();
            return;
        }

        //Continue
		MatchManager.instance.SetHazardAnswer(new string[] { text.text });
	}
}
