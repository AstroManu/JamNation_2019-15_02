using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCold : Match
{
	public MatchCold(int id, float nbPlayers)
	{
		matchId = id;
		this.nbPlayers = nbPlayers;

		Init();
	}

	protected override void Init()
	{
		//Init
		nextHazardTimer = Random.Range(1, 6);
		string n = "";
		string d = "";

		//Match rules
		matchName = "Ere Glaciale";
		adaptationPoints = new Adaptation[] {Adaptation.Froid, Adaptation.Aquatique, Adaptation.Famine, Adaptation.Chaud};
		genePoint = Gene.Bleu;

		//All hazards possibles
		n = "Avalanche";
		d = "Oh no, ya une grosse boule de neige qui va maybe vous tuer." +
			"Pour partir a temps, vous pouvez depenser 4 cubes jaunes. Avez vous depensee 4 cubes jaunes?";
		listHazards.Add(new Hazard(n, d, new Vector2(1, 50), new string[] { "Damn Right", "Fuck no"}, "Avalanche Fallout"));

		n = "Blizzard";
		d = "Un gros nuage de poudre neigeuse limite votre vision. Vous ne pouvez donc pas vous reproduire pendant ce tour.";
		listHazards.Add(new Hazard(n, d, new Vector2(1, 50), new string[] { }, ""));
	}

	protected override Hazard PlayScriptedHazard(string tag)
	{
		Hazard hazard = null;
		string d = "";

		switch(tag)
		{
			case "Avalanche Fallout":
				if (hazardAnswer[0].Equals("Damn Right"))
				{
					d = "Vous avez reussit a eviter une big old catastrophe. Well played. Y'all get a cookie.";
					hazard = new Hazard(tag, d, new Vector2(0, 50), new string[] { }, "");
				}
				else
				{
					d = "Naughty boys. Le momentum des milliers kilogrammes de neiges vous snap le cou. Vous perdez donc chacun une evolution";
					hazard = new Hazard(tag, d, new Vector2(0, 50), new string[] { }, "");
				}
				break;
		}

		return hazard;
	}
}
