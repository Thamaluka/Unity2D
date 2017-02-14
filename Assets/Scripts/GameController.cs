using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text playerScore;

	void Start(){
		playerScore.text = PlayerPrefs.GetInt ("playerScore").ToString ();
	}

	public void play(){
		SceneManager.LoadScene ("Lvl01");
	}


}
