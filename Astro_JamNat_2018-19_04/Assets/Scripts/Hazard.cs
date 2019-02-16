using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard{

	public string hazardName;
	public string hazardDescription;
	public Vector2 hazardTimeRange;
	public string[] hazardInput;
	public string postHazardTag;
	public string[] inputChoice;

	public Hazard(string name, string description, Vector2 timeRange, string[] inputChoice, string postHazardTag)
	{
		hazardName = name;
		hazardDescription = description;
		hazardTimeRange = timeRange;
		this.postHazardTag = postHazardTag;
		this.inputChoice = inputChoice;
	}

	//Set inputs
	public void SetHazardInput(string[] values)
	{
		hazardInput = values;
	}

	//Get inputs
	public string[] GetHazardInput()
	{
		return hazardInput;
	}

		
}
