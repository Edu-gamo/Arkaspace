using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour {

    private float speed = 2;
    private float maxSpeed = 4;
    private float speedIncrement = 0.1f;

    // Use this for initialization
    void Start () {

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "RedEnemy") {
            other.gameObject.GetComponent<RedEnemy>().hp--;
            if (other.gameObject.GetComponent<RedEnemy>().hp <= 0) {
                Destroy(other.gameObject);
                FindObjectOfType<Player>().score += 50;
            }
            //REBOTA
        }
        else if (other.gameObject.tag == "OrangeEnemy") {
            other.gameObject.GetComponent<OrangeEnemy>().hp--;
            if (other.gameObject.GetComponent<OrangeEnemy>().hp <= 0) {
                Destroy(other.gameObject);
                FindObjectOfType<Player>().score += 30;
            }
            //REBOTA
        }
        else if (other.gameObject.tag == "YellowEnemy") {
            other.gameObject.GetComponent<YellowEnemy>().hp--;
            if (other.gameObject.GetComponent<YellowEnemy>().hp <= 0) {
                Destroy(other.gameObject);
                FindObjectOfType<Player>().score += 10;
            }
            //REBOTA
        }
        else if (other.gameObject.tag == "Barrier") {
            Vector2 playerPos = other.gameObject.GetComponentInParent<Transform>().position;
            Vector2 direction = ((Vector2)this.transform.position - playerPos).normalized;
            this.GetComponent<Rigidbody2D>().velocity = direction * speed;
            //REBOTA
        }

        //Incrementa la velocidad en cada rebote
        if (speed + speedIncrement < maxSpeed) {
            speed += speedIncrement;
        } else {
            speed = maxSpeed;
        }
        this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * speed;

        if (other.gameObject.name == "bottom_edge") {
            //PIERDE LA BOLA

            FindObjectOfType<Player>().ballState = false;
             Destroy(this.gameObject);

        }   
    }
}
