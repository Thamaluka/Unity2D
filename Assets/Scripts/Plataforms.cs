using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforms : MonoBehaviour {

	public Transform plataform,a,b;
	public float velocity;
	private Vector3 destiny;

	// Use this for initialization
	void Start () {
		plataform.position = a.position;
		destiny = b.position;
	}
	
	// Update is called once per frame
	void Update () {
		plataform.position = Vector3.MoveTowards (plataform.position,destiny,velocity*Time.deltaTime);

		if(plataform.position == destiny){
			if (destiny == a.position) {
				destiny = b.position;
			} else {
				destiny = a.position;
			}
		}
	}
}
