using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Parallax : MonoBehaviour {

	public Transform backGround, camera;
	public float parallaxScale, velocity;

	private Vector3 destiny, previewCamPos;
	// Use this for initialization
	void Start () {
		previewCamPos = camera.position;
	}
	
	// Update is called once per frame
	void Update () {
		float paraX= (previewCamPos.x - camera.position.x)* parallaxScale;

		destiny = new Vector3 (backGround.position.x + paraX,backGround.position.y, backGround.position.z);

		backGround.position = Vector3.Lerp (backGround.position, destiny, velocity * Time.deltaTime);

		previewCamPos = camera.position;
	}
}
