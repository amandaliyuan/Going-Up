using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class backToStart : MonoBehaviour {
	Button btn;
	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (start);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}

	}
	void start(){
		SceneManager.LoadScene ("start");

	}
}
