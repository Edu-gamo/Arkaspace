using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    private float speed = 0.1f;
    private float halfWidth = 3.3f;

    public Object energyBall;
    public Object barrier;
    public bool barrierState, ballState;

    private GameObject ball, bar;

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

        

        if (!barrierState && Input.GetAxis("Vertical") < 0) {
            bar = (GameObject)Instantiate(barrier, new Vector2(this.transform.position.x, this.transform.position.y + .2f), Quaternion.identity);
            bar.transform.SetParent(this.transform);
            barrierState = true;
        } else if(barrierState && Input.GetAxis("Vertical") == 0)  {
            Destroy(bar);
            barrierState = false;
        }

        if (!ballState && Input.GetAxis("Vertical") > 0) {
            ball = (GameObject) Instantiate(energyBall, new Vector2(this.transform.position.x, this.transform.position.y + .5f), Quaternion.identity);
            ballState = true;
        }
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);
        }
    }
}
