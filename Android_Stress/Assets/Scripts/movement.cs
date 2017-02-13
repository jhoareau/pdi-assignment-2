using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	RaycastHit2D hit;

	Vector3 direction;
	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
		direction = new Vector3 (Random.Range(-1f,1f), Random.Range(-1f,1f), 0);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp(transform.position, transform.position + direction, speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){

		Debug.Log (other.gameObject.name);

		if (other.gameObject.name == "leftWall") {
			direction = Vector3.Reflect (direction, Vector3.right);
		}
		if (other.gameObject.name == "rightWall") {
			direction = Vector3.Reflect (direction, Vector3.left);
		}
		if (other.gameObject.name == "topWall") {
			direction = Vector3.Reflect (direction, Vector3.down);
		}
		if (other.gameObject.name == "bottomWall") {
			direction = Vector3.Reflect (direction, Vector3.up);
		}
	}

	void OnCollisionEnter(Collision col){

		ContactPoint con = col.contacts[0];

		direction = Vector3.Reflect (direction, con.normal); 

	}
}
