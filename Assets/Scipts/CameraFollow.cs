using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	Vector3 camPoz;
	Vector3 playerPoz;
	Vector3 diff;
	// Use this for initialization
	void Start () {
		camPoz = this.gameObject.transform.position;
		playerPoz = Player.PlayerObject.transform.position;
		diff = camPoz - playerPoz;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 poz = Player.PlayerObject.transform.position;
		Vector3 newCamPoz = this.gameObject.transform.position;
		newCamPoz.x = poz.x + diff.x;
		newCamPoz.z = poz.z + diff.z;
		this.gameObject.transform.position = newCamPoz;
	}
}
