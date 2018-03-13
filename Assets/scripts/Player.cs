using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    private float speed = 0.1f;
    private float halfWidth = 3.3f;

    public Object energyBall;
    public Object barrier;

    private GameObject ball;

    public int score;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //Movimiento lateral de la nave
        this.transform.position = new Vector2(this.transform.position.x + (Input.GetAxis("Horizontal") * speed), this.transform.position.y);
        if(this.transform.position.x > halfWidth) {
            this.transform.position = new Vector2(halfWidth, this.transform.position.y);
        } else if(this.transform.position.x < -halfWidth) {
            this.transform.position = new Vector2(-halfWidth, this.transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            ball = (GameObject) Instantiate(energyBall, new Vector2(this.transform.position.x, this.transform.position.y + .5f), Quaternion.identity);
        }

    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);
        }
    }
}
