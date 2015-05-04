using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space) && Time.frameCount % 20 == 0) {
			GameObject spawnedBullet = (GameObject)Instantiate(bullet, transform.position + transform.forward - transform.up, transform.rotation);
			spawnedBullet.GetComponent<Rigidbody>().velocity += this.transform.parent.GetComponent<Rigidbody>().velocity;
		}
	}
}
