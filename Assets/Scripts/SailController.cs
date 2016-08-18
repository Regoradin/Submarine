using UnityEngine;
using System.Collections;

public class SailController : MonoBehaviour {

	private Animator anim;
	private GameObject chair;
	public bool sailUp;

	void Start(){
	
		anim = GetComponentInChildren<Animator> ();

	}

	void OnTriggerStay( Collider other){
		if (other.tag == "Player") {

			if (Input.GetButtonDown ("Submit")) {
				Debug.Log ("sail switching");
				anim.SetTrigger ("Sail Switch");

				}
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sail Up")){

				sailUp = true;

			}
			if (!anim.GetCurrentAnimatorStateInfo(0).IsName ("Sail Up")) {

				sailUp = false;
			}
		}
	}
	
	void Update () {

	}
}
