using UnityEngine;
using System.Collections;

public class SteeringWheel : MonoBehaviour {

	private Renderer rend;
	private Color red =  new Color (1, 0, 0, 1);
	public Color boat;
	public bool seated = false;
	private Vector3 oldPosition;

	private Vector3 movement;
	private Vector3 forwardMovement;
	private Vector3 rotation;
	public float speed;
	public float rotationSpeed;
	private GameObject sail;


	void Start(){

		rend = GetComponent<Renderer> ();
		sail = GameObject.Find ("Mast");

	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player")
		{
			rend.material.color = red;

			if (Input.GetButtonDown( "Submit"))
			{
				Debug.Log ("buttonDown");
				if (seated)
				{
					seated = false;
					other.transform.localPosition = oldPosition;
					other.transform.SetParent (null);
					return;
				}
				else if (!seated) 
				{
					seated = true;
					other.transform.SetParent (transform);
					oldPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
					other.transform.position = transform.position - new Vector3 (0f, 0f, 0.1f);
					return;
				}
			}

			if (seated && sail.GetComponent<SailController>().sailUp) {

				movement = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
				movement = transform.TransformDirection (movement);

				forwardMovement = new Vector3 (0f, 0f, Input.GetAxis("Vertical"));
				rotation = new Vector3 (0f, Input.GetAxis ("Horizontal"), 0f);

				GetComponentInParent<Rigidbody> ().AddRelativeForce (forwardMovement * speed);
				GetComponentInParent<Rigidbody> ().AddTorque(rotation * rotationSpeed);

				Debug.Log (GetComponentInParent<Rigidbody> ().angularVelocity);
			}
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "Player") 
		{
			rend.material.color = boat;
		}
	}

}
