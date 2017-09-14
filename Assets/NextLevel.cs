using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public Text winText;

	void OnTriggerEnter2D(Collider2D other)
	{
		winText.text = "You Win";
		Destroy (other.gameObject);
	}
}
