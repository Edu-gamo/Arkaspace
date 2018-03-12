using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    private float speed = 0.01f;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        //Movimiento descendente de la nave
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - speed);

    }
}
