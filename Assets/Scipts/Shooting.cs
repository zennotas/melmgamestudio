using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	private bool canShoot;
	LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
		canShoot = true;
		lineRenderer = this.gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && canShoot) {
			Ray ray = new Ray(transform.position, this.gameObject.transform.forward);
			RaycastHit[] hits;
			hits = Physics.RaycastAll(ray, 1000);
			foreach(RaycastHit hit in hits) {
				if (hit.transform.gameObject.tag != "MainGun") {
					lineRenderer.SetPosition(0, this.gameObject.transform.position);
					lineRenderer.SetPosition(1, hit.point);
					canShoot = false;
					StartCoroutine(WaitForShooting());
					//StartCoroutine(DestroyLines());
					Player.PlayerObject.GetComponent<Animator>().SetBool("isShooting", true);
				}
			}
		}
	}

	IEnumerator WaitForShooting() {
		yield return new WaitForSeconds(2f);
		canShoot = true;
	}

	IEnumerator DestroyLines() {
		yield return new WaitForSeconds(0.03f);
		lineRenderer.SetPosition (0, Vector3.zero);
		lineRenderer.SetPosition (1, Vector3.zero);
		Player.PlayerObject.GetComponent<Animator>().SetBool("isShooting", false);
	}
}
