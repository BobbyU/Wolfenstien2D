using UnityEngine;
using System.Collections;

public class guard_actions : MonoBehaviour {

	private Rigidbody2D guard_body;
	private Rigidbody2D protac_body;
	private float turnTimer;
	private protac_movement protac;
	private SpriteRenderer guard_sprite;

	// Use this for initialization
	void Start () {
		guard_body = GetComponent<Rigidbody2D> ();
		guard_sprite = GetComponent<SpriteRenderer> ();
		protac = GameObject.Find ("protac_1").GetComponent<protac_movement>();
		turnTimer = 5; // seconds between guard turns
	}
	
	// Update is called once per frame
	void Update () {
		turnTimer -= Time.deltaTime;
		if (turnTimer > 0) {      // should not turn yet
		} else {        // guard should turn
			turnGuard();
			turnTimer = 5;
		}

		if (checkIfSeen ()) {
			// todo: game over
		}
	}

	// turns the guard from left to right or vise versa
	void turnGuard(){
		if ( guard_sprite.flipX ) {
			guard_sprite.flipX = false;
		} else {
			guard_sprite.flipX = true;
		}
	}

	// calculate if the given game object is in the line of site
	// todo: make this apply to any game object
	bool checkIfSeen(){
		Vector2 distance_components= guard_body.position - protac.GetPosition();
		float distance = Mathf.Sqrt ( Mathf.Pow(distance_components.x, 2) + Mathf.Pow(distance_components.y, 2) );
		if ( distance < 10 ) {
			float angle = Mathf.Abs( Mathf.Atan2( distance_components.y, distance_components.x ) * Mathf.Rad2Deg );
			if ( angle > 150 ) {
				Debug.Log ("Seen");
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	}
}
