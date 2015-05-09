using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class uPlayer : MonoBehaviour {

	public static uPlayer instance;
	private Vector3 localCoordinates;

	public bool isPiloting;

	private MouseLook m_look;

	public float xSensitivity, ySensitivity;
	public float walkSpeed;

	// Use this for initialization
	void Start () {
		if(instance == null) {
			instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if(transform.position.x > 1000) {
//			localCoordinates = new Vector3(localCoordinates.x + 1, localCoordinates.y, localCoordinates.z);
//			transform.position = new Vector3(-999, transform.position.y, transform.position.z);
//		} else if(transform.position.x < -1000) {
//			localCoordinates = new Vector3(localCoordinates.x - 1, localCoordinates.y, localCoordinates.z);
//			transform.position = new Vector3(999, transform.position.y, transform.position.z);
//		}
//
//		if(transform.position.y > 1000) {
//			localCoordinates = new Vector3(localCoordinates.x, localCoordinates.y + 1, localCoordinates.z);
//			transform.position = new Vector3(transform.position.x, -999, transform.position.z);
//		} else if(transform.position.y < -1000) {
//			localCoordinates = new Vector3(localCoordinates.x, localCoordinates.y - 1, localCoordinates.z);
//			transform.position = new Vector3(transform.position.x, 999, transform.position.z);
//		}
//
//		if(transform.position.z > 1000) {
//			localCoordinates = new Vector3(localCoordinates.x, localCoordinates.y, localCoordinates.z + 1);
//			transform.position = new Vector3(transform.position.x, transform.position.y, -999);
//		} else if(transform.position.z < -1000) {
//			localCoordinates = new Vector3(localCoordinates.x, localCoordinates.y, localCoordinates.z - 1);
//			transform.position = new Vector3(transform.position.x, transform.position.y, 999);
//		}
		if(transform.parent != null) {
			if(transform.position.x > 1000) {
				localCoordinates = new Vector3(localCoordinates.x + 1, localCoordinates.y, localCoordinates.z);
				transform.parent.position = new Vector3(0, transform.position.y, transform.position.z);
			} else if(transform.position.x < -1000) {
				localCoordinates = new Vector3(localCoordinates.x - 1, localCoordinates.y, localCoordinates.z);
				transform.parent.position = new Vector3(0, transform.position.y, transform.position.z);
			}
			
			if(transform.position.y > 1000) {
				localCoordinates = new Vector3(localCoordinates.x, localCoordinates.y + 1, localCoordinates.z);
				transform.parent.position = new Vector3(transform.position.x, 0, transform.position.z);
			} else if(transform.position.y < -1000) {
				localCoordinates = new Vector3(localCoordinates.x, localCoordinates.y - 1, localCoordinates.z);
				transform.parent.position = new Vector3(transform.position.x, 0, transform.position.z);
			}
			
			if(transform.position.z > 1000) {
				localCoordinates = new Vector3(localCoordinates.x, localCoordinates.y, localCoordinates.z + 1);
				transform.parent.position = new Vector3(transform.position.x, transform.position.y, 0);
			} else if(transform.position.z < -1000) {
				localCoordinates = new Vector3(localCoordinates.x, localCoordinates.y, localCoordinates.z - 1);
				transform.parent.position = new Vector3(transform.position.x, transform.position.y, 0);
			}
		}

		if(!isPiloting) {
			if(Input.GetKey(KeyCode.W)) {
				GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.S)) {
				GetComponent<Rigidbody>().MovePosition(transform.position - transform.forward*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.D)) {
				GetComponent<Rigidbody>().MovePosition(transform.position + transform.right*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.A)) {
				GetComponent<Rigidbody>().MovePosition(transform.position - transform.right*Time.deltaTime);
			}

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;

			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + Input.GetAxis("Mouse X")*xSensitivity, transform.localEulerAngles.z);
			if(transform.GetChild(0).localEulerAngles.x < 365 && transform.GetChild(0).localEulerAngles.x > 300) {
				transform.GetChild(0).localEulerAngles = new Vector3(Mathf.Max(transform.GetChild(0).localEulerAngles.x - Input.GetAxis("Mouse Y")*ySensitivity, 305), 0, transform.GetChild(0).localEulerAngles.z);
			} else if(transform.GetChild(0).localEulerAngles.x >= 0 && transform.GetChild(0).localEulerAngles.x < 60) {
				transform.GetChild(0).localEulerAngles = new Vector3(Mathf.Min(transform.GetChild(0).localEulerAngles.x - Input.GetAxis("Mouse Y")*ySensitivity, 55), 0, transform.GetChild(0).localEulerAngles.z);
			}
			GetComponent<Rigidbody>().isKinematic = true;

		} else {
			if(transform.GetChild(0).localEulerAngles.y < 365 && transform.GetChild(0).localEulerAngles.y > 300) {
				transform.GetChild(0).localEulerAngles = new Vector3(transform.GetChild(0).localEulerAngles.x, Mathf.Max(transform.GetChild(0).localEulerAngles.y + Input.GetAxis("Mouse X")*xSensitivity, 305), transform.GetChild(0).localEulerAngles.z);
			} else if(transform.GetChild(0).localEulerAngles.y >= 0 && transform.GetChild(0).localEulerAngles.y < 60) {
				transform.GetChild(0).localEulerAngles = new Vector3(transform.GetChild(0).localEulerAngles.x, Mathf.Min(transform.GetChild(0).localEulerAngles.y + Input.GetAxis("Mouse X")*xSensitivity, 55), transform.GetChild(0).localEulerAngles.z);
			}
			if(transform.GetChild(0).localEulerAngles.x < 365 && transform.GetChild(0).localEulerAngles.x > 300) {
				transform.GetChild(0).localEulerAngles = new Vector3(Mathf.Max(transform.GetChild(0).localEulerAngles.x - Input.GetAxis("Mouse Y")*ySensitivity, 305), transform.GetChild(0).localEulerAngles.y, transform.GetChild(0).localEulerAngles.z);
			} else if(transform.GetChild(0).localEulerAngles.x >= 0 && transform.GetChild(0).localEulerAngles.x < 60) {
				transform.GetChild(0).localEulerAngles = new Vector3(Mathf.Min(transform.GetChild(0).localEulerAngles.x - Input.GetAxis("Mouse Y")*ySensitivity, 55), transform.GetChild(0).localEulerAngles.y, transform.GetChild(0).localEulerAngles.z);
			}
			GetComponent<Rigidbody>().isKinematic = true;
		}

	}

	public static Vector3 getPos() {
		return instance.transform.position + (1000*instance.localCoordinates);
	}

	public static Quaternion getRot() {
		return Quaternion.Euler(instance.transform.GetChild(0).eulerAngles.x,instance.transform.GetChild(0).eulerAngles.y,instance.transform.GetChild(0).eulerAngles.z);
//		return Quaternion.identity;
	}

	void OnTriggerStay(Collider other) {
		if(other.GetComponent<uChair>() != null) {
			if(Input.GetKeyDown(KeyCode.E)) {
				isPiloting = !isPiloting;
			}
		}
	}
}
