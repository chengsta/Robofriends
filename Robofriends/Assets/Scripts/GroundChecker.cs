using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {
	private float distToGround;
	private Vector3 width;
	// Use this for initialization
	void Start () {
		distToGround = GetComponent<Collider>().bounds.extents.y;
		width = new Vector3(GetComponent<Collider>().bounds.extents.x, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawLine (transform.position, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Color.red);
	}
	
	public bool IsGrounded() {

		RaycastHit hit;
		int lm = LayerMask.GetMask("Platform", "Glass");
		//if (GetComponentInParent<PlayerMovement>().gravity < 0) {
			// print("on ground/normal gravity");
			if (Physics.Raycast(transform.position + width, -Vector3.up, out hit, distToGround + 0.1f, lm))
				return true;
			if (Physics.Raycast(transform.position - width, -Vector3.up, out hit, distToGround + 0.1f, lm))
				return true;
//		}
//		else {
//			//print("on ground/reverse gravity");
//			// print (Vector3.up + transform.position);
//			//print (Physics.Raycast(transform.position + width, transform.TransformDirection(Vector3.up), distToGround + 0.1f) ||
//			//	Physics.Raycast(transform.position - width, transform.TransformDirection(Vector3.up), distToGround + 0.1f));
//			if (Physics.Raycast(transform.position + width, Vector3.up, out hit, distToGround + 0.1f) 
//			    && (hit.transform.gameObject.tag == "Platform"))
//				return true;
//			if (Physics.Raycast(transform.position - width, Vector3.up, out hit, distToGround + 0.1f) 
//			    && (hit.transform.gameObject.tag == "Platform"))
//				return true;
//		}

		return false;
	}
	

}
