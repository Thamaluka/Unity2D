using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Rigidbody2D playerRigibory;
	private float horizontal;
	private float vertical;
	public float velocityPlayer, jumpVelocity;
	public Transform grounCheck;
	private bool grounded, walk, lookAtLeft, gravityChange;
	public LayerMask whatIsGround;
	private Animator playerAnimator;

	// Use this for initialization
	void Start () {
		playerRigibory = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		horizontal = Input.GetAxisRaw ("Horizontal");

		if (horizontal != 0) {
			walk = true;	
		} else {
			walk = false;
		}
		// Where the players is looking for
		if (horizontal > 0 && lookAtLeft || horizontal<0 && !lookAtLeft) {
			Flip ();
		} 


		//Change de Gravity to walk in the roof
		vertical = Input.GetAxisRaw ("Vertical");
		if (vertical > 0 && !gravityChange || vertical<0 && gravityChange) {
			Gravity ();
		}

		//Jump and Walk
		grounded=Physics2D.OverlapCircle (grounCheck.position, 0.02f,whatIsGround);

		if(Input.GetButtonDown("Run")){
			velocityPlayer = 4;
		}
		if(Input.GetButtonUp("Run")){
			velocityPlayer = 2;
		}
		if(Input.GetButtonDown("Jump")&& grounded){
			playerRigibory.AddForce (new Vector2(0,jumpVelocity));
		}


		//Animator
		playerAnimator.SetBool("walkAnimator",walk);
		if (gravityChange) {
			playerAnimator.SetFloat ("VelocityY", playerRigibory.velocity.y);
		} else {
			playerAnimator.SetFloat ("VelocityY", playerRigibory.velocity.y * -1);
		}


		playerAnimator.SetBool ("Grounded",grounded);
	}

	void FixedUpdate(){
		playerRigibory.velocity = new Vector2 (horizontal*velocityPlayer,playerRigibory.velocity.y);
	}

	void Flip(){
		lookAtLeft = !lookAtLeft;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Gravity(){
		gravityChange = !gravityChange;

		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;

		playerRigibory.gravityScale *= -1;
		jumpVelocity *= -1;
	}
}
