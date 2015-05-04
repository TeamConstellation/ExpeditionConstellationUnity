using UnityEngine;
using System.Collections;

public class uPlanet : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,Time.deltaTime/4f));
		transform.GetChild(0).Rotate(new Vector3(0,Time.deltaTime/4f));	
	}
}
