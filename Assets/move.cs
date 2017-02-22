using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	Rigidbody rb;
	float strength = 50;
	Animation an;
	float bounciness = 50;
	public float maxSpeed;
	bool right = true;
	Vector3 ground;
	bool goingUp = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		an = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) && Mathf.Abs(rb.velocity.y) < maxSpeed && goingUp == false) {
			rb.AddForce (Vector3.up*strength * 15);
			goingUp = true;
		}
		if (Input.GetKey (KeyCode.S) && Mathf.Abs(rb.velocity.y) < maxSpeed) {
			rb.AddForce (Vector3.down * strength);
		}
		if (Input.GetKey (KeyCode.A) && (Mathf.Abs(rb.velocity.x) < 100) ){
			rb.AddForce (Vector3.left * strength);
			right = false;
		}
		if(Input.GetKey(KeyCode.D) && Mathf.Abs(rb.velocity.x) < 100){
			rb.AddForce(Vector3.right * strength);
			right = true;
		}

		if (Mathf.Abs(rb.velocity.magnitude) > 0f) {
			
				an.Play ("Walk");
		} else {
			an.Play ("Stand");
		}
	if(right == true){
		transform.localEulerAngles = new Vector3(0,90,0);

	}else{
		transform.localEulerAngles = new Vector3(0,-90,0);
	}



	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("platform") && transform.position.y > col.gameObject.transform.position.y){
			Debug.Log("hit the platform");
			rb.AddForce (new Vector3 (0, -rb.velocity.y, 0)*bounciness*3);
			Debug.Log ("teddy hit");
			goingUp = true;
		}


	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "ground"){
			ground = transform.position;
			goingUp = false;
		}


	}

}
