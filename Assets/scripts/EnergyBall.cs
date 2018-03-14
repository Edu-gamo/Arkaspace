using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour {

    public  Rigidbody2D rig;
    private float speed = 2;
    private float maxSpeed = 4;

    public float velocidadInicial = 600f;
    bool enJuego;

    private GameObject player;


    void Awake() {

        //rig = GetComponent<Rigidbody2D>();
        

    }

    // Use this for initialization
    void Start () {

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
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

        if (other.gameObject.name == "bottom_edge") {
            //PIERDE LA BOLA

            FindObjectOfType<Player>().ballState = false;
             Destroy(this.gameObject);

        }   
    }
}
