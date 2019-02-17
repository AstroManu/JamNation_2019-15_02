using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Match{

	public int matchId;
	public float nbPlayers;
	public float winnerId;

	protected int turnId = 0;
	protected int nextHazardTimer = 0;
	protected string matchName;
	protected Adaptation[] adaptationPoints;
	protected Gene genePoint;
	protected List<Hazard> listHazards = new List<Hazard>();
	protected List<Hazard> historyHazards = new List<Hazard>();
	protected string postHazard = "";
	protected string[] hazardAnswer = new string[] { };
	protected string historyHazardText = "";

	public Hazard NextTurn()
	{	
		//Init
		turnId++;
		nextHazardTimer--;
		Hazard hazardSummoned = null;

		//If Hazard timer == 0, Play a hazard
		if(nextHazardTimer == 0)
        { 
            //Init
            nextHazardTimer = Random.Range(1, 4);

            //End game
            if (historyHazards.Count >= 4)
                hazardSummoned = new Hazard("Ere Terminee", "Vous avez termine la partie. Vous pouvez calculer vos points. \n" + GetRules(), new Vector2(0,0), new string[] {"Continuer"}, "END");

            //Scripted Hazard
            else if (!postHazard.Equals(""))
                hazardSummoned = PlayScriptedHazard(postHazard);

            //Random Hazard
            else
                hazardSummoned = PlayRandomHazard();

			//Add in history
			historyHazards.Add(hazardSummoned);

			//Safe history text
			historyHazardText += "-[Turn " + turnId + "] <b>";
			historyHazardText += hazardSummoned.hazardName;
			historyHazardText += "</b>\n";

			//Display Hazard Page
			TextManager.instance.DisplayHazard(hazardSummoned);

			//Display history
			TextManager.instance.SetHazards(GetHazards());
			
			//Add post hazard if Hazard has one
			postHazard = hazardSummoned.postHazardTag;
		}

		return hazardSummoned;
	}

	public void SetHazardAnswer(string[] answers)
	{
		hazardAnswer = answers;
		TextManager.instance.CloseHazard();
	}

	public string GetName()
	{
		return ("Partie " + matchId + ": " + matchName);
	}

	public int GetNumber()
	{
		return matchId;
	}

	public string GetRules()
	{
        string rules = "";
        for(int i=0; i<adaptationPoints.Length; i++)
        {
            rules += "<sprite name=p" + (3-i) + ">";
            rules += "<sprite name=" + TextManager.instance.GetAdaptationCode(adaptationPoints[i]) + ">";
            rules += "   ";
        }

        rules += "                <sprite name=p1><sprite name=" + TextManager.instance.GetGeneCode(genePoint) + ">";

        return rules;
	}

	public string GetHazards()
	{
		return historyHazardText;
	}

	protected Hazard PlayRandomHazard()
	{
		Hazard hazardSummoned = null;

		//Find all possible hazard to summon
		List<Hazard> possibleHazards = new List<Hazard>();
		foreach (Hazard h in listHazards)
		{
			if (h.postHazardTag.Equals("") || (!h.postHazardTag.Equals("") && historyHazards.Count < 3))
				possibleHazards.Add(h);
		}

		//Pick one randomly
		if (possibleHazards.Count > 0)
			hazardSummoned = possibleHazards[Random.Range(0, possibleHazards.Count)];


		return hazardSummoned;
	}

	protected abstract Hazard PlayScriptedHazard(string tag);
	protected abstract void Init();	
}
