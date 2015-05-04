using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;

	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward*speed*Time.deltaTime);
	}

	void OnCollisionEnter(Collision other) {
		if(other.rigidbody != null) {
			other.rigidbody.AddExplosionForce(100f, transform.position, 100f);
		}
		Instantiate(explosion, transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}
}
