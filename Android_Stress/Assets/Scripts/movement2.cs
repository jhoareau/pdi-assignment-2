using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
{

	RaycastHit2D hit;
	Vector3 direction;

	public float speed = 5.0f;
	public GameObject con;

	// Use this for initialization
	void Start ()
	{
		// The sum of x and y is not always 1, that is why the special's have different speeds
		direction = new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f), 0);
		direction = direction.normalized;

		control cont = con.GetComponent<control> ();


		Rigidbody rb = GetComponent<Rigidbody> ();

		int number = Random.Range (1, 5);
		rb.AddForce (direction * 300f);
		//transform.position = Vector3.Lerp (transform.position, transform.position + direction, speed * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update ()
	{
		control cont = con.GetComponent<control> ();

		Debug.Log ("From movement: " + cont.moving);

		if (!cont.moving) {
			Rigidbody rb = GetComponent<Rigidbody> ();
			Vector3 v = rb.velocity;
			v.y = 0;
			v.x = 0;

			rb.velocity = v;
		}
			
	}

	public void SetController (GameObject con)
	{
		this.con = con;
	}

	void OnTriggerEnter (Collider other)
	{

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
}
