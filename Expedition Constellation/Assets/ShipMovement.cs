using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public float speed;

	public float thrustFactor;

	private float accel = 1f;

	public float turnSpeed;

	public float rollSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
			if(Input.GetKey(KeyCode.W)) {
				DirectUp();
			}
			
			if(Input.GetKey(KeyCode.S)) {
				DirectDown();
			}
			
			if(Input.GetKey(KeyCode.A)) {
				StrafeLeft();
			}
			
			if(Input.GetKey(KeyCode.D)) {
				StrafeRight();
			}
		} else {
			if(Input.GetKey(KeyCode.W)) {
				accel += 0.001f;
				GetComponent<Rigidbody>().AddForce(transform.forward * speed * thrustFactor * accel, ForceMode.Acceleration);
			} else {
				accel = 1f;
			}
			if(Input.GetKey(KeyCode.S)) {
				GetComponent<Rigidbody>().AddForce(-transform.forward * speed * thrustFactor * accel, ForceMode.Acceleration);
			}

			if(Input.GetKey(KeyCode.D)) {
				YawRight();
			}

			if(Input.GetKey(KeyCode.A)) {
				YawLeft();
			}
		}

		if(Input.GetKey(KeyCode.UpArrow)) {
			PitchUp();
		}

		if(Input.GetKey(KeyCode.DownArrow)) {
			PitchDown();
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			RollLeft();
		}
		
		if(Input.GetKey(KeyCode.RightArrow)) {
			RollRight();
		}
	}

	void RollRight() {
		GetComponent<Rigidbody>().AddRelativeTorque(0,0,-speed/rollSpeed, ForceMode.Acceleration);
	}

	void RollLeft() {
		GetComponent<Rigidbody>().AddRelativeTorque(0,0,speed/rollSpeed, ForceMode.Acceleration);
	}

	void PitchUp() {
		GetComponent<Rigidbody>().AddRelativeTorque(-speed/turnSpeed,0,0, ForceMode.Acceleration);
	}

	void PitchDown() {
		GetComponent<Rigidbody>().AddRelativeTorque(speed/turnSpeed,0,0, ForceMode.Acceleration);
	}

	void YawRight() {
		GetComponent<Rigidbody>().AddRelativeTorque(0,speed/turnSpeed,0, ForceMode.Acceleration);
	}

	void YawLeft() {
		GetComponent<Rigidbody>().AddRelativeTorque(0,-speed/turnSpeed,0, ForceMode.Acceleration);
	}

	void DirectUp() {
		GetComponent<Rigidbody>().AddForce(transform.up * speed * 4, ForceMode.Acceleration);
	}

	void DirectDown() {
		GetComponent<Rigidbody>().AddForce(-transform.up * speed * 4, ForceMode.Acceleration);
	}

	void StrafeLeft() {
		GetComponent<Rigidbody>().AddForce(-transform.right * speed* 4, ForceMode.Acceleration);
	}

	void StrafeRight() {
		GetComponent<Rigidbody>().AddForce(transform.right * speed * 4, ForceMode.Acceleration);
	}

}