using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Rigidbody2D playerRigibory;
	private float horizontal;
	public float velocityPlayer, jumpVelocity;

	// Use this for initialization
	void Start () {
		playerRigibory = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxisRaw ("Horizontal");

		if(Input.GetButtonDown("Run")){
			velocityPlayer = 4;
		}
		if(Input.GetButtonUp("Run")){
			velocityPlayer = 2;
		}
		if(Input.GetButtonDown("Jump")){
			playerRigibory.AddForce (new Vector2(0,jumpVelocity));
		}
	}

	void FixedUpdate(){
		playerRigibory.velocity = new Vector2 (horizontal*velocityPlayer,playerRigibory.velocity.y);
	}
}
