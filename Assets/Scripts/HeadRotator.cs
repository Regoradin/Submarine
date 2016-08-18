using UnityEngine;
using System.Collections;

public class HeadRotator : MonoBehaviour {

	public float looksensitivity;
	private float verticalmouse;
	private Vector3 Rotation;
	private float yRotation;

	public float maxY;
	public float minY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (-Input.GetAxis("Mouse Y")* looksensitivity, Input.GetAxis("Mouse X") * looksensitivity, 0.0f, Space.Self);
		yRotation = Mathf.Clamp (transform.eulerAngles.x, minY, maxY);
//		Debug.Log (yRotation);
		transform.eulerAngles = new Vector3 (yRotation, transform.eulerAngles.y, 0f);

	}
}
