using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomButton : MonoBehaviour {

    public int id;

	public void NextTurn()
    {
		GetComponent<Animator>().SetTrigger("click");
        MatchManager.instance.NextTurn();
		transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Fin du Tour " + (MatchManager.instance.GetNbTurn() + 1);
	}

    public void SetWinner()
    {
        MatchManager.instance.playerWinner = id;
        TextManager.instance.CloseEndMatch();
		TextManager.instance.EvolutionWindow();

	}

	public void DisplayOldMatch()
	{
		if (id == MatchManager.instance.GetNbMatch() - 1)
			TextManager.instance.ShowHideNextTurnButton(true);
		else
			TextManager.instance.ShowHideNextTurnButton(false);
		MatchManager.instance.DisplayText(MatchManager.instance.GetMatch(id));
	}

	public void NewGame()
	{
		MatchManager.instance.NewMatch(MatchManager.instance.GetPlayerName().Length);
		TextManager.instance.CloseEvolutionWindow();
	}

	public void GoToMenu()
	{

	}
}
