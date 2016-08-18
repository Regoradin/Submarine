using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {

	public float waviness;
	private Vector3 difference;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		difference = (Mathf.Sin (Mathf.Repeat (Time.time, 2 * Mathf.PI) * waviness) - transform.position.y) * Vector3.up;

		transform.Translate (difference);
	
	}
}
