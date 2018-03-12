using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    private float speed = 0.1f;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //Movimiento lateral de la nave
        this.transform.position = new Vector2(this.transform.position.x + (Input.GetAxis("Horizontal") * speed), this.transform.position.y);

    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);
        }
    }
}
