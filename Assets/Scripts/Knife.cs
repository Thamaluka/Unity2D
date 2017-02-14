using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(){
		GetComponent<Rigidbody2D> ().gravityScale = 1;
		Destroy (this.gameObject);
	}


	void OnTriggerEnter2D(Collider2D col){
		switch (col.gameObject.tag) {

		case "Hit":
			Destroy (col.gameObject);
			Destroy (this.gameObject);
			break;


		}
	}
}
