using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

	public float speed;
	private Vector3 movement = Vector3.zero;
	public float looksensitivity;
	private GameObject chair;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		chair = GameObject.Find ("Steering Wheel");
		controller = GetComponent<CharacterController> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!chair.GetComponent<SteeringWheel> ().seated) {
			movement = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
			movement = transform.GetChild (1).TransformDirection (movement);
			movement.y = 0.0f;
		}


		if (!controller.isGrounded)
			movement += Vector3.down;

		controller.Move (movement * speed);

	}
}
