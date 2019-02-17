using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvolutionTree : MonoBehaviour {

    #region Singleton
    public static EvolutionTree instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        contestantsPosition = new Vector2[] { new Vector2(maxDistanceX / 2, 0) };
    }
    #endregion

    public GameObject nodePrefab;
	public GameObject linePrefab;
	public Color winnerColor;
	public Color defaultColor;
	public Color looserColor;
	public float maxDistanceX;
	public float distanceY;

	private int nbMatch = 0;
	private Vector2 scrollVelocity = new Vector2(0,0);
	private float totalDistanceY = 0;
    private Vector2[] contestantsPosition;
	private GameObject[] contestantsLine = new GameObject[] {};
	private float intensity = 0;
    private bool isZoomed = false;
    private List<GameObject> allNodes = new List<GameObject>();
    private List<GameObject> allLines = new List<GameObject>();
    private List<Vector3> allNodesPosition = new List<Vector3>();
    private List<Vector3> allNodesPositionZoomed = new List<Vector3>();

	private void Update()
	{
		//Scroll
		if (Input.mouseScrollDelta[0] > 0 && transform.localPosition.y < 0) { }
		else
		{
			scrollVelocity += Input.mouseScrollDelta * 10;
			transform.position += (Vector3)scrollVelocity;
			scrollVelocity /= 1.15f;
		}

        //Zoom animation
        if (isZoomed)
        {
            //Nodes
            for(int i=0; i<allNodes.Count; i++)
            {
                allNodes[i].transform.localPosition = Vector3.Lerp(allNodes[i].transform.localPosition, allNodesPositionZoomed[i], 0.1f);
            }

            //Lines
            float time = Time.deltaTime;
            foreach(GameObject l in allLines)
            {
                Image img = l.GetComponent<Image>();
                Color c = img.color;
                c.a = Mathf.Max(c.a - time * 5, 0);
                img.color = c;
            }
        }

        else
        {
            //Nodes
            for (int i = 0; i < allNodes.Count; i++)
            {
                allNodes[i].transform.localPosition = Vector3.Lerp(allNodes[i].transform.localPosition, allNodesPosition[i], 0.1f);
            }

            //Lines
            float time = Time.deltaTime;
            foreach (GameObject l in allLines)
            {
                Image img = l.GetComponent<Image>();
                Color c = img.color;
                c.a = Mathf.Min(c.a + time, 1);
                img.color = c;
            }
        }


    }

	public void Next(int winnerId, int nbPlayer)
	{
		//Init
		nbMatch++;
		Vector2 initPos = contestantsPosition[winnerId];

		//Add knob to winner branch
		GameObject n = Instantiate(nodePrefab, transform);
        n.transform.localPosition = initPos;
        n.transform.SetAsLastSibling();
        allNodes.Add(n);
        allNodesPosition.Add(n.transform.localPosition);
        allNodesPositionZoomed.Add(new Vector3(maxDistanceX/2, 55 * nbMatch, 0));
		n.GetComponent<CustomButton>().id = nbMatch - 1;

        //Write Initial in node
        if(nbMatch == 1)
            n.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        else
            n.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = MatchManager.instance.GetPlayerName(winnerId);

		//Color line & node
		n.GetComponent<Image>().color = winnerColor;
        if (contestantsLine.Length >= (winnerId + 1))
        {
            contestantsLine[winnerId].GetComponent<Image>().color = winnerColor;
            contestantsLine[winnerId].GetComponent<Image>().sprite = null;
        }

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
		GameObject[] allNewLines = new GameObject[nbPlayer];
		for(int i=0; i<contestantsPosition.Length; i++)
		{
			//Create line
			GameObject line = Instantiate(linePrefab, transform);
			line.transform.localPosition = initPos;
			line.GetComponent<Image>().color = defaultColor;
			allNewLines[i] = line;
            line.transform.SetAsFirstSibling();
            allLines.Add(line);

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

		contestantsLine = allNewLines;
	}

    public void ToggleZoom()
    {
        isZoomed = !isZoomed;
    }
}
