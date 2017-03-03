using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teddyUp : MonoBehaviour {
	Animation an;
	// Use this for initialization
	void Start () {
		an = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			if (an.isPlaying == false) {
				an.Play ("Walk");
			}
		}
	}
}
