using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	bool moving;
	float moveX;
	float moveY;
	public int speed;

	// Use this for initialization
	void Start () {
		moving = false;
	}

	// Update is called once per frame
	void Update () {
		//Define the forward vector using your facing direction
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 playerForward = transform.root.gameObject.transform.TransformDirection(Vector3.forward);

		if(Input.GetMouseButtonDown(0)){
			moving = true;
			moveX = Input.GetAxis("Mouse X");
			moveY = Input.GetAxis("Mouse Y");
		}

		if(Input.GetMouseButtonUp(0)) {
			moving = false;
		}

		// If the touchpad is being held down, move forward in the direction you are facing.
		if (moving)
		{

			if (moveX < 0)
			{
				transform.root.gameObject.transform.position += playerForward * Time.deltaTime * speed;
			}
			if (moveX > 0)
			{
				transform.root.gameObject.transform.position += playerForward * Time.deltaTime * speed * -1;
			}

			if (moveY < 0)
			{
				playerForward = transform.root.gameObject.transform.TransformDirection(Vector3.right);
				transform.root.gameObject.transform.position += playerForward * Time.deltaTime * speed;
			}
			if (moveY > 0)
			{
				playerForward = transform.root.gameObject.transform.TransformDirection(Vector3.right);
				transform.root.gameObject.transform.position += playerForward * Time.deltaTime * speed * -1;
			}
				
		}



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
