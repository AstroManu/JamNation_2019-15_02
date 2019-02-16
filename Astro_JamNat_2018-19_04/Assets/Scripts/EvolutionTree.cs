using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvolutionTree : MonoBehaviour {

	public GameObject nodePrefab;
	public GameObject linePrefab;
	public Color winnerColor;
	public Color defaultColor;
	public Color looserColor;
	public float maxDistanceX;
	public float distanceY;

	private int nbMatch = 0;
	private float totalDistanceY = 0;
	private Vector2[] contestantsPosition = new Vector2[] { new Vector2(0,0)};
	private GameObject[] contestantsLine = new GameObject[] {};

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			Next(0, Random.Range(2, 7));
		if (Input.GetKeyDown(KeyCode.Alpha2))
			Next(1, Random.Range(2, 7));
		if (Input.GetKeyDown(KeyCode.Alpha3))
			Next(2, Random.Range(2, 7));
		if (Input.GetKeyDown(KeyCode.Alpha4))
			Next(3, Random.Range(2, 7));
	}

	void Next(int winnerId, int nbPlayer)
	{
		//Init
		nbMatch++;
		Vector2 initPos = contestantsPosition[winnerId];

		//Add knob to winner branch
		GameObject n = Instantiate(nodePrefab, transform);
		n.transform.localPosition = initPos;

		//Color line & node
		n.GetComponent<Image>().color = winnerColor;
		if(contestantsLine.Length >= (winnerId + 1))
			contestantsLine[winnerId].GetComponent<Image>().color = winnerColor;

		//Gray out other lines
		for (int i=0; i < contestantsLine.Length; i++)
		{
			if (i != winnerId)
			{
				GameObject line = contestantsLine[i];
				line.GetComponent<Image>().color = looserColor;
			}
		}

		//Find new position for contestants
		float distanceBetween = maxDistanceX / (nbPlayer + 1);
		totalDistanceY += distanceY * Random.Range(0.85f, 1.2f);
		float posY = totalDistanceY;

		Vector2[] allPos = new Vector2[nbPlayer];

		for(int i=0; i<allPos.Length; i++)
		{
			allPos[i] = new Vector2( distanceBetween * (i + 1), posY);
		}

		contestantsPosition = allPos;

		//Spawn new lines from knob
		GameObject[] allLines = new GameObject[nbPlayer];
		for(int i=0; i<contestantsPosition.Length; i++)
		{
			//Create line
			GameObject line = Instantiate(linePrefab, transform);
			line.transform.localPosition = initPos;
			line.GetComponent<Image>().color = defaultColor;
			allLines[i] = line;

			//Rotate
			Vector2 vectorToTarget = contestantsPosition[i] - initPos;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
			line.transform.rotation = q;

			//Scale
			float distance = Vector3.Distance(contestantsPosition[i], initPos);
			Vector3 scale = line.transform.localScale;
			scale.y = distance;
			line.transform.localScale = scale;

		}

		contestantsLine = allLines;
	}
}
