using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
	public PhysicMaterial friction;
	public PhysicMaterial frictionless;
	public Animator anim;
	public bool tempAnimEnabled = false;
	private GroundChecker groundChecker;
	private bool connected;
	Rigidbody rigidbody;
	
	public virtual bool CanJump() {
		return false;
	}
	
	// Use this for initialization
	void Start () {
		if (tempAnimEnabled) {
			anim = GetComponent<Animator> ();
			anim.Play ("RobotDead");
		}
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
		if (connected && tempAnimEnabled) {
			if (groundChecker.IsGrounded () && Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.2f) {
				anim.Play ("RobotRoll");
			} else {
				anim.Play ("RobotAir");
			}
		}
	}
	
	public virtual void SetParent(GameObject go) {
		connected = true;
		if (tempAnimEnabled) {
			anim.Play ("RobotAir");
		}
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
		if (tempAnimEnabled) {
			anim.Play ("RobotDead");
		}
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
