using UnityEngine;
using System.Collections;

public class Movetowards : MonoBehaviour {
    public GameObject playeris;
    public Transform player;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            this.transform.LookAt(player);
     }
 
}
