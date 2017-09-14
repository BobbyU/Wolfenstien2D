using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class protac_movement : MonoBehaviour {

	private Rigidbody2D player_body;
	private SpriteRenderer player_sprite;
	public float speed;
	public Text winText;

	// Use this for initialization
	void Start () {
		player_body = GetComponent<Rigidbody2D> ();
		player_sprite = GetComponent<SpriteRenderer> ();
		speed = 0.25F;
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//player.AddForce (movement * speed);
		player_body.MovePosition( player_body.position + (movement * speed));
	}

	public Vector2 GetPosition() {
		return player_body.position;
	}

	public Vector2 GetSize() {
		return player_sprite.size;
	}
}
