using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class UModule : MonoBehaviour {

    //TODO: Create some data representing which cubes in an (X by Y by Z) cube space that this module takes up. Probably should be modifiable in the inspector.

    public string name = "";
    public float maxHealth = 100f;
    private float health;

    private Vector3 shipPos;

    [HideInInspector]
    public UShip parentShip;

	// Use this for initialization
	void Start () {
        health = maxHealth; //Starting health will default to maxHealth on startup.
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //TODO: check to see if the other is a projectile.
    }

    void OnDestroy()
    {
        //TODO: Do some checks to see if other modules are breaking off.
        //TODO: Do some special effects!
    }
}
