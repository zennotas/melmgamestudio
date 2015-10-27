using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour {

	void Start () {
		Player.PlayerObject = this.gameObject;
		Player.Speed = 5;
		GameObject gunObject = GameObject.FindGameObjectWithTag ("MainGun");
		GameObject flashLights = gunObject.transform.GetChild (0).gameObject;
		Gun gun = new Gun (200, gunObject, flashLights, false);
		Player.gun = gun;
		/////
		TimeSystem.Hours = 12;
		TimeSystem.Minutes = 0;
		TimeSystem.GlobalLight = GameObject.Find ("Sun");
		InvokeRepeating ("IncreaseTime", 0, 0.125f);
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		Ray cameraRay;
		RaycastHit[] cameraRayHits;
		cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		// If the ray strikes an object...
		cameraRayHits = Physics.RaycastAll (cameraRay, 100);
		Vector3 targetPosition = Vector3.zero;
		foreach (RaycastHit cameraRayHit in cameraRayHits) {
			if (cameraRayHit.transform.tag == "Ground" && (targetPosition - this.gameObject.transform.position).magnitude > 2)
			{
				// ...make the cube rotate (only on the Y axis) to face the ray hit's position 
				targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
				transform.LookAt(targetPosition);
			}
		}
		Vector3 direction = (targetPosition - this.gameObject.transform.position).normalized;
		if (Input.GetKey (KeyCode.A)) {
			this.gameObject.transform.Translate((Quaternion.AngleAxis(-90, Vector3.up) * direction) * Time.deltaTime * Player.Speed, Space.World);
		}
		else if (Input.GetKey (KeyCode.D)) {
			this.gameObject.transform.Translate((Quaternion.AngleAxis(90, Vector3.up) * direction) * Time.deltaTime * Player.Speed, Space.World);
		}
		else if (Input.GetKey (KeyCode.W)) {
			this.gameObject.transform.Translate(direction * Time.deltaTime * Player.Speed, Space.World);
		}
		if (Input.GetKey (KeyCode.S)) {
			this.gameObject.transform.Translate(-direction * Time.deltaTime * Player.Speed/2, Space.World);
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S)) {
			Player.PlayerObject.GetComponent<Animator>().SetBool("isRunning", true);
		} 
		else {
			Player.PlayerObject.GetComponent<Animator>().SetBool("isRunning", false);
		}
	}
	
	void Update() {
		Debug.Log (TimeSystem.ToStringTime ());
	}

	void IncreaseTime() {
		TimeSystem.AddMinute (1);
	}
}

