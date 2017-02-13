using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWay : MonoBehaviour {
	public Transform superficie, ground;
	private float posY;
	private Collider2D col;


	// Use this for initialization
	void Start () {
		ground = GameObject.Find ("GroundCheck").transform;

		col = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		posY = ground.position.y;

		if (posY > superficie.position.y) {
			col.enabled = true;
		} else {
			col.enabled = false;
		}
	}
}
