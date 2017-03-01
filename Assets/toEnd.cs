using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class toEnd : MonoBehaviour {
	public float maxTime;
	float currentTime;
	// Use this for initialization
	void Start () {
		currentTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		Debug.Log(currentTime);
		if(currentTime >= maxTime){
			SceneManager.LoadScene("lose");
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			SceneManager.LoadScene("win");
		}


	}
}
