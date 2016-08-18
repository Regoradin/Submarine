using UnityEngine;
using System.Collections;

public class BodyRotator : MonoBehaviour {

	public HeadRotator headRotator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (0.0f, Input.GetAxis("Mouse X") * headRotator.looksensitivity, 0.0f, Space.World);

	}
}
