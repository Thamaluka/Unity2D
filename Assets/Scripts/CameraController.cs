using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Player player;
	public Transform L, R;
	// Use this for initialization
	void Start () {

		player = FindObjectOfType(typeof (Player)) as Player;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > L.position.x && transform.position.x < R.position.x || player.transform.position.x < L.position.x && transform.position.x > R.position.x ) {
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);

			print ("aqui");
		}
	}
}
