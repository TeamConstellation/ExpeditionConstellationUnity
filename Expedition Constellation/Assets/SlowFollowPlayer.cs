using UnityEngine;
using System.Collections;

public class SlowFollowPlayer : MonoBehaviour {

	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position-uPlayer.pos.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = uPlayer.pos.position*transform.parent.localScale.x/100f;
		transform.rotation = uPlayer.pos.rotation;
	}
}
