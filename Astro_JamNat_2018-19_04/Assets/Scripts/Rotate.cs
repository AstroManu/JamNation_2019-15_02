using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float rotateSpeed = 1.0f;
    public Transform ADN;

    // Update is called once per frame
    void Update () {
		
        ADN.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);

    }
}
