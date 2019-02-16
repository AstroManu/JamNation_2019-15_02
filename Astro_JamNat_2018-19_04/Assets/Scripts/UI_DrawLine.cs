using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DrawLine : MonoBehaviour {

	public Transform pointA;
	public Transform pointB;
	private void Start()
	{
		Vector3 differenceVector = pointB.position - pointA.position;
		RectTransform imageRectTransform = GetComponent<RectTransform>();
		imageRectTransform.sizeDelta = new Vector2(differenceVector.magnitude, lineWidth);
		imageRectTransfom.pivot = new Vector2(0, 0.5f);
		imageRectTransform.position = pointA;
		float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
		imageRectTransform.Rotation = Quaternion.Euler(0, 0, angle);
	}
}
