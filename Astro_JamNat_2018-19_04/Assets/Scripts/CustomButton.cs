using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomButton : MonoBehaviour {

    public int id;

	public void NextTurn()
    {
        MatchManager.instance.NextTurn();
    }

    public void SetWinner()
    {
        MatchManager.instance.playerWinner = id;
        TextManager.instance.CloseEndMatch();
        MatchManager.instance.NewMatch(4);
    }
}
