using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour {
	Text txt ;
	float time;
	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		txt.text = "" + Mathf.Round(time);
	}
}
