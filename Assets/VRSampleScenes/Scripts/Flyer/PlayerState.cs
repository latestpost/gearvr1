using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	public Vector3 oldLocation;

	// Use this for initialization
	void Start () {
		oldLocation = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setOldLocation(Vector3 oldLocation) {
		this.oldLocation = oldLocation;
	}
}
