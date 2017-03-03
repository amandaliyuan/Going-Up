using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
	Vector3 origPos;
	// Use this for initialization
	void Start () {
		origPos = gameObject.transform.position - GameObject.Find("teddy").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = GameObject.Find("teddy").transform.position + origPos;
	}
}
