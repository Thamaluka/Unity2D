using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisoes : MonoBehaviour {

	//Ao Colidir com algum objeto
	void OnTriggerEnter2D(Collider2D obj){

		switch(obj.gameObject.tag){

		case "Hit":
			print("ai");

			break;

		case "Objeto":
			print ("Objeto");
			break;
		}

		
		
	}

	//Ao deixar de Colidir algum objeto
	void OnCollisionExit2D(Collision2D obj){
	
	}

	//Estao Colidindo com algum objeto
	void OnCollisionStay2D(Collision2D obj){
	
	}
}
