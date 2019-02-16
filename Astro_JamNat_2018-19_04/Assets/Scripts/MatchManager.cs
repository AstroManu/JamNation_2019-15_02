using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Adaptation {Aquatique, Chaud, Froid, Famine, Maladie, Secheresse}
public enum Gene { Bleu, Jaune, Mauve, Vert};

public class MatchManager : MonoBehaviour {

	#region Singleton
	public static MatchManager instance;
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}
	#endregion

	List<Match> historyMatches = new List<Match>();
	Match currentMatch;
	int nbMatch = 0;

	public void SetHazardAnswer(string[] answers)
	{
		currentMatch.SetHazardAnswer(answers);
	}

	public void NewMatch(int nbPlayers)
	{
		//Init
		Match newMatch = null;
		nbMatch++;

		//Randomly start a match
		int r = Random.Range(0, 1);
		switch(r)
		{
			case 0:
				newMatch = new MatchCold(nbMatch, nbPlayers);
				break;
		}

		//Add match to history
		currentMatch = newMatch;
		historyMatches.Add(newMatch);
	}

	public Hazard NextTurn()
	{
		return currentMatch.NextTurn();
	}
}
