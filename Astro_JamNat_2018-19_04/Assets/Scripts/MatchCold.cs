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
		nextHazardTimer = Random.Range(2, 6);
		string n = "";
		string d = "";

		//Match rules
		matchName = "Paléozoïque";
		matchDescription = "Le PaléozoÏque est une ère géologique qui s'étend de -541 à -252,2 millions d'années. " +
			"Cette ère est parfois appelée Ère Primaire (ou Ère des Poissons). ";
		adaptationPoints = new Adaptation[] {Adaptation.Aquatique, Adaptation.Predator, Adaptation.Chaud};
		genePoint = Gene.Bleu;

		//All hazards possibles
		n = "Tremblement de Terre";
		d = "Chaque espèce (joueur) doit immédiatement dépenser trois gènes ou perdre une évolution de son choix.";
		listHazards.Add(new Hazard(n, d, new Vector2(1, 50), new string[] { "Okay!"}, ""));

		n = "L’appel de la Terre";
		d = "Vous devrez bientôt vous adapter à la vie sur la terre ferme. Trouvez les évolutions Amphibie, Système immunitaire ou Pied Palmés.";
		listHazards.Add(new Hazard(n, d, new Vector2(1, 50), new string[] { "Parfait!"}, "Résolution"));
	}

	protected override Hazard PlayScriptedHazard(string tag)
	{
		Hazard hazard = null;
		string d = "";

		switch(tag)
		{
			case "Résolution":
				d = "Perdez immédiatement un gène de votre choix si vous n’avez pas l’évolution Amphibie, Système immunitaire ou Pied Palmés";
				hazard = new Hazard(tag, d, new Vector2(0, 50), new string[] { }, "");
				break;
		}

		return hazard;
	}
}
