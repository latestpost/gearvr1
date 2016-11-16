using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	public int speed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//Define the forward vector using your facing direction
		Vector3 playerForward = transform.root.gameObject.transform.TransformDirection(Vector3.forward);

		if (Input.GetAxis("Vertical") > 0) {
			transform.root.gameObject.transform.position += playerForward * Time.deltaTime * speed;
		}
		if (Input.GetAxis("Vertical") < 0) {
			transform.root.gameObject.transform.position += playerForward * Time.deltaTime * speed * -1;
		}

		if (Input.GetAxis("Horizontal") > 0) {
			playerForward = transform.root.gameObject.transform.TransformDirection(Vector3.right);
			transform.root.gameObject.transform.position += playerForward * Time.deltaTime * speed;
		}
		if (Input.GetAxis("Horizontal") < 0) {
			playerForward = transform.root.gameObject.transform.TransformDirection(Vector3.right);
			transform.root.gameObject.transform.position += playerForward * Time.deltaTime * speed * -1;
		}
	}
}
