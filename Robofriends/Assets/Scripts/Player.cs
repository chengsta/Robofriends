using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float moveSpeed;
	public float jumpSpeed;
	public float jumpTime;
	bool jumping = false;
	public float gravity;
	public Animator anim;
	public Camera camera;

	public AudioClip walkSound;
	private float walktimer = 5.0f;
	void playSound(AudioClip sound, float vol){
		GetComponent<AudioSource>().clip = sound;
		GetComponent<AudioSource>().volume = vol;
		GetComponent<AudioSource>().Play();
	}

	private GroundChecker groundChecker;
	private GameObject SpriteChild;
	private GameObject Gun;
	//private FixedJoint PlayerJoint;
	private GameObject GunSpriteChild;

	private float timer;
	IEnumerator Jump() {
		while (timer > 0) {
			setVertSpeed(jumpSpeed);
			timer -= Time.deltaTime;
			yield return null;
		}
		setVertSpeed (jumpSpeed/4);
	}
	
//	IEnumerator SwapCheck() {
//		while (true) {
//			if (Input.GetButtonDown("Action")) {
//				Camera.main.GetComponent<LockController>().swapPosition();
//				break;
//			}
//			yield return null;
//		}
//	}
	
	// Use this for initialization
	void Start () {
		Gun = transform.Find ("Gun").gameObject;
		GunSpriteChild = Gun.transform.Find("GunSprite").gameObject;
		SpriteChild = transform.Find ("PlayerSprite").gameObject;
		//PlayerJoint = GetComponent<FixedJoint> ();
		groundChecker = GetComponent<GroundChecker>();
		anim = this.GetComponentInChildren<Animator>();
		camera = Camera.main;
//		Camera.main.GetComponent<LockController> ().players.Add (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation != Quaternion.identity) {
			transform.rotation = Quaternion.identity;
		}
		float h = Input.GetAxis ("Horizontal");
		if (!groundChecker.IsGrounded ()) {	
			playSound(walkSound, 1.0f);
			anim.Play ("PlayerJump");
		} else if (GetComponent<Rigidbody>().velocity.x == 0) {
			anim.Play ("PlayerStand");
		} else {			
			anim.Play ("PlayerWalk");
			if (walktimer > 0.3f) {
				GetComponent<AudioSource>().PlayOneShot(walkSound, 0.5f);
				walktimer = 0;
			}
		}
		walktimer += Time.fixedDeltaTime;

		Vector3 temp = SpriteChild.transform.localScale;
		Vector3 gunTemp= GunSpriteChild.transform.localScale;
		Vector3 charPos = camera.WorldToScreenPoint (transform.position);

		if (Input.mousePosition.x < charPos.x && temp.x > 0) {
			gunTemp.y *= -1;
			temp.x *= -1;
		} else if (Input.mousePosition.x > charPos.x && temp.x < 0) {
			temp.x *= -1;
			gunTemp.y *= -1;
		}
		SpriteChild.transform.localScale = temp;
		GunSpriteChild.transform.localScale = gunTemp;
		
		if (Input.GetButtonDown("Jump")) {
			if (CanJump()) {
				timer = jumpTime;
				StartCoroutine("Jump");
				setVertSpeed(jumpSpeed);
			}
		}
		
		setHorizSpeed (h * moveSpeed);

	}
	
	void OnTriggerEnter(Collider coll) {
//		if (coll.GetComponent<LockSwitch>()) {
//			lock_movement();
//		}
//		else if (coll.GetComponent<UnlockSwitch>()) {
//			unlock_movement();
//		}
//		else if (coll.GetComponent<ReverseSwitch>()) {
//			Camera.main.GetComponent<LockController> ().reverse_gravity();
//		}
//		else if (coll.GetComponent<SwapSwitch>()) {
//			StartCoroutine("SwapCheck");
//		}

//		if (coll.GetComponent<Bullet>()) {
//			Destroy (this.gameObject);
//		}
	}

	void OnTriggerStay(Collider coll) {
//		if (coll.GetComponent<GravityWell>()) {
//			Vector3 direction = new Vector3(0,0,coll.transform.rotation.z);
//			rigidbody.AddForce (coll.transform.up* 80.0f, ForceMode.Acceleration);
//		}
	}

	void OnTriggerExit(Collider coll) {
//		if (coll.GetComponent<SwapSwitch>()) {
//			StopCoroutine("SwapCheck");
//		}
	}
	
	bool CanJump() {
		bool canJump = groundChecker.IsGrounded();

		Robot r;
		if (r = GetComponentInChildren<RobotJump> ()) {
			return r.CanJump() || canJump;
		}
		else if (r = GetComponentInChildren<Robot>() ) {
			return false;
		}
		else 
			return canJump;
	}
	
	public void ReleaseRobot () {
		Robot r;
		if (r = GetComponentInChildren<Robot> ()) {
			r.GetComponent<Robot>().ReleaseParent();
		}
	}

	void setHorizSpeed(float x) {
		GetComponent<Rigidbody>().velocity = new Vector3(x, GetComponent<Rigidbody>().velocity.y, 0);
	}
	
	void setVertSpeed(float y) {
		GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, y, 0);
	}
	
	void lock_movement() {
		Camera.main.GetComponent<LockController> ().lock_movement ();
	}
	
	void unlock_movement() {
		Camera.main.GetComponent<LockController> ().unlock_movement ();
	}


//	public void reverse_gravity() {
//		StopCoroutine("Jump");
//		gravity = -gravity;
//		jumpSpeed = -jumpSpeed;
//		jumping = false;
//		Physics.gravity = new Vector3(0, gravity, 0);
//		//		Quaternion newRotation;
//		//		if (gravity > 0)
//		//			newRotation = Quaternion.Euler(0,180,0);
//		//		else
//		//			newRotation = Quaternion.Euler(0,0,0);
//		//transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime);
//	}
	
}
