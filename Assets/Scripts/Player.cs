using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public Rigidbody2D playerRigibory;
	private float horizontal;
	private float vertical;
	public float velocityPlayer, jumpVelocity, knifeVelocity;
	public Transform grounCheck, hand;
	private bool grounded, walk, gravityChange;
	public bool lookAtLeft;
	public LayerMask whatIsGround;
	private Animator playerAnimator;
	public GameObject knife, interPlayer;
	public Text score;
	public int points;


	// Use this for initialization
	void Start () {
		playerRigibory = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator> ();

	
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + points.ToString ();
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


		if(Input.GetButtonDown("Fire1")){
			if (interPlayer == null) {
				troughKnife ();
			} else {
				interPlayer.SendMessage ("interaction",SendMessageOptions.DontRequireReceiver);
			}

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
		knifeVelocity *= -1;
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

	void troughKnife(){
		GameObject knifeTemp = Instantiate (knife, hand.position, transform.rotation);
		if (lookAtLeft) {
			knifeTemp.GetComponent<SpriteRenderer> ().flipX = true;
		}

		knifeTemp.GetComponent<Rigidbody2D>().velocity = new Vector2 (knifeVelocity,0.0f);

		Destroy (knifeTemp, 5);

		}

	void OnCollisionEnter2D(Collision2D col){
		switch (col.gameObject.tag) {
		case "MovePlataform":
			transform.SetParent (col.transform);
			break;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		switch (col.gameObject.tag) {
		case "MovePlataform":
			transform.SetParent (null);
			break;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		switch (col.gameObject.tag) {

		case "Inter":
			interPlayer = col.gameObject;
			break;

		case "Gold":
			Destroy (col.gameObject);
			points += 15;
			break;

		}
	}

	void OnTriggerExit2D(Collider2D col){
		switch (col.gameObject.tag) {
		case "Inter":
			interPlayer = null;
			break;
		}
	}

		

	
	}

