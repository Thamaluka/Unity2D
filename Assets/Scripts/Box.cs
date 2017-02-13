using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	public GameObject [] boxState;
	private bool isOpen;
	private Player player;

	// Use this for initialization
	void Start () {
		boxState [0].SetActive (true);
		boxState [1].SetActive (false);

	
		player = FindObjectOfType(typeof (Player)) as Player;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void interaction(){
		if(!isOpen){
			isOpen = !isOpen;
			boxState [0].SetActive (!boxState [0].activeSelf);
			boxState [1].SetActive (!boxState [1].activeSelf);
			player.points += 50;
		}
	
	}
}
