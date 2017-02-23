using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
    enum Direction { RIGHT,LEFT};

	Rigidbody rb;
    Animation an;

    float walkingSpeed = 8000;
    float jumpStrength = 40, downJumpForce = 20;
    public static int jumps = 3;
    int jumpsRemaining = jumps;
	
	float bounciness = 50;
    Direction direction = Direction.RIGHT;
    Vector3 newVelocity;
	Vector3 ground;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		an = GetComponent<Animation> ();
		newVelocity = rb.velocity;
	}
	
	// Update is called once per frame
	void Update () {

        newVelocity = rb.velocity;

        if (Input.GetKeyDown (KeyCode.W) && jumpsRemaining > 0) {
            jumpsRemaining--;
            newVelocity.y = jumpStrength;
		}

		if (Input.GetKeyDown (KeyCode.S)) {
            newVelocity.y -= downJumpForce;
		}

		if (Input.GetKey (KeyCode.A) && (Mathf.Abs(rb.velocity.x) < 100) ){
            if(direction != Direction.RIGHT)
            {
                newVelocity.x = 0;
            }
			rb.AddForce (Vector3.left * walkingSpeed);
            direction = Direction.RIGHT;
		}

		if(Input.GetKey(KeyCode.D) && Mathf.Abs(rb.velocity.x) < 100){
            if (direction != Direction.LEFT)
            {
                newVelocity.x = 0;
            }
            rb.AddForce(Vector3.right * walkingSpeed);
            direction = Direction.LEFT;
		}

		if (Mathf.Abs(rb.velocity.x) > 1f) {
			
				an.Play ("Walk");
		} else {
			an.Play ("Stand");
		}


        rb.velocity = newVelocity;

        if (direction == Direction.RIGHT){
		    transform.localEulerAngles = new Vector3(0,-90,0);

	    }else{
		    transform.localEulerAngles = new Vector3(0,90,0);
	    }



	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("platform") && transform.position.y > col.gameObject.transform.position.y){
			Debug.Log("hit the platform");
			//newVelocity.y = 0;
			rb.AddForce (new Vector3 (0, 1, 0)*bounciness*10000);
			Debug.Log ("teddy hit");
            jumpsRemaining = jumps;
		}


	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "ground"){
			ground = transform.position;
            jumpsRemaining = jumps;
		}


	}

}
