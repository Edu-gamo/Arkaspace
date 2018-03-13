using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    private float speed = 0.5f;

    public int hp = 1;

    // Use this for initialization
    void Start () {
        StartCoroutine(BlinkTimer());
    }
	
	// Update is called once per frame
	void Update () {

        //Movimiento descendente de la nave
    }

    IEnumerator BlinkTimer() {
        yield return new WaitForSeconds(1);
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - speed);
        StartCoroutine(BlinkTimer());
    }
}
