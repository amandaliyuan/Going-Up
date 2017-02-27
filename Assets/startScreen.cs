using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class startScreen : MonoBehaviour {
	Button btn;
	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (toGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void toGame(){
		SceneManager.LoadScene ("main");

	}
}
