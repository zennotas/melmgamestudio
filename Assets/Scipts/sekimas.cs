using UnityEngine;
using System.Collections;

public class sekimas : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, target.position, 0.2f);
        this.transform.LookAt(target);
	}
}
