using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Adaptation {Aquatique, Chaud, Froid, Famine, Maladie, Secheresse, Predator}
public enum Gene { Bleu, Orange, Mauve, Vert};

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

    public int playerWinner = 0;

	List<Match> historyMatches = new List<Match>();
	Match currentMatch;
	int nbMatch = 0;
	string[] playerNames = new string[] { "Mx", "Al", "Mb", "Fx"};

    private void Start()
    {
        NewMatch(playerNames.Length);
    }

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

        //Branch Tree
        EvolutionTree.instance.Next(playerWinner, playerNames.Length);

		//Add match to history
		currentMatch = newMatch;
		historyMatches.Add(newMatch);

		//Text
		DisplayText(newMatch);
    }

	public Hazard NextTurn()
	{
		return currentMatch.NextTurn();
	}

	public void Init(bool continueGame, string[] playerNames)
	{

	}

    public string GetPlayerName(int i)
    {
        return playerNames[i];
    }

    public string[] GetPlayerName()
    {
        return playerNames;
    }

	public void SetWinner(int id)
	{
		currentMatch.SetWinnerId(id, GetPlayerName(id));
	}

	public Match GetMatch(int i)
	{
		return historyMatches[i];
	}

	public int GetNbMatch()
	{
		return nbMatch;
	}

	public int GetNbTurn()
	{
		return currentMatch.turnId;
	}

	public void DisplayText(Match m)
	{
		TextManager.instance.SetTitle(m.GetName());
		TextManager.instance.SetRules(m.GetRules());
		TextManager.instance.SetHazards(m.GetHazards());
		TextManager.instance.SetDescription(m.GetDescription());
	}
}
