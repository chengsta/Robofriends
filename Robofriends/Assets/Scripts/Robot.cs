using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
	public PhysicMaterial friction;
	public PhysicMaterial frictionless;
	public Animator anim;
	public Transform sprite;
	private GroundChecker groundChecker;
	public bool connected;
	Rigidbody rigidbody;
	
	public virtual bool CanJump() {
		return false;
	}
	
	// Use this for initialization
	void Start () {
		anim = this.GetComponentInChildren<Animator>();
		anim.Play ("RobotDead");
		sprite = this.GetComponentInChildren<Transform>();
		
		rigidbody = gameObject.GetComponent<Rigidbody>();
		GetComponent<Collider>().material = friction;
		groundChecker = GetComponent<GroundChecker>();
		connected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation != Quaternion.identity) {
			transform.rotation = Quaternion.identity;
		}
		if (connected) {
			Vector3 tmpScale = sprite.localScale;
			if (Input.GetAxis("Horizontal") < -0.1f) {
				tmpScale.x = 1;
			} else if (Input.GetAxis("Horizontal") > 0.1f) {
				tmpScale.x = -1;
			}
			sprite.localScale = tmpScale;
		}

		if (connected) {
			if (groundChecker.IsGrounded () && Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.2f) {
				anim.Play ("RobotRoll");
			} else {
				anim.Play ("RobotAir");
			}
		}
	}
	
	public virtual void SetParent(GameObject go) {
		connected = true;
		anim.Play ("RobotAir");
		Vector3 _posRobot = transform.position;
		Vector3 _posGo = go.transform.position;
		
		Destroy(gameObject.GetComponent<Rigidbody>());
		transform.parent = go.transform;
		
		GetComponent<Collider>().material = frictionless;
		transform.position = _posRobot;
		go.transform.position = _posGo;
		go.transform.rotation = Quaternion.identity;
		transform.rotation = Quaternion.identity;
	}
	
	public virtual void ReleaseParent() {
		connected = false;
		anim.Play ("RobotDead");
		Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
		
		rb.freezeRotation = true;
		rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionZ;
		
		rb.velocity = transform.parent.GetComponent<Rigidbody>().velocity;
		GetComponent<Collider>().material = friction;
		
		transform.parent = null;
		
	}
	
	public virtual void hitBySpikes() {
		Destroy(this.gameObject);
	}
	
}
