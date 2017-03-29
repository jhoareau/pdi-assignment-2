using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

	RaycastHit2D hit;
	Vector3 direction;

	public float speed = 5.0f;
	public GameObject con;

	// Use this for initialization
	void Start ()
	{
		// Get random start direction in x and y.
		direction = new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f), 0);
		direction = direction.normalized;

		// Add initial force to the object
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.AddForce (direction * 300f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		control cont = con.GetComponent<control> ();
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
		
}
