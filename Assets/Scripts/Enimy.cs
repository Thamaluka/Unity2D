using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimy : MonoBehaviour {
	private Player player;
	public float velocity;
	private bool lookAtRight;
	public Sprite [] sprite;
	private SpriteRenderer enimiBack;



	// Use this for initialization
	void Start () {
		player = FindObjectOfType(typeof (Player)) as Player;
		enimiBack = GetComponent<SpriteRenderer> ();


	}
	
	// Update is called once per frame
	void Update () {
		

		if (player.transform.position.x <transform.position.x && player.lookAtLeft) {
			GetComponent<SpriteRenderer> ().flipX = true;
			Follow ();

		} else if (player.transform.position.x>transform.position.x && !player.lookAtLeft) {
			GetComponent<SpriteRenderer> ().flipX = false;
			Follow();
		} else {
			enimiBack.sprite = sprite [1];
		}

	}


	void Follow(){
		enimiBack.sprite = sprite [0];
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, velocity * Time.deltaTime);
	}

}
