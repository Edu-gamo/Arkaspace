using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour {

    private float speed = 2;
    private float maxSpeed = 4;

    // Use this for initialization
    void Start () {

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<Enemy>().hp--;
            if (other.gameObject.GetComponent<Enemy>().hp <= 0) {
                Destroy(other.gameObject);
                FindObjectOfType<Player>().score += 10;
            }
        }
    }
}
