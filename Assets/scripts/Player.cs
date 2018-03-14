using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    
    private float speed = 0.1f;
    private float halfWidth = 3.3f;

    public Object energyBall;
    public Object barrier;
    public bool barrierState, ballState;

    private GameObject ball, bar;

    public Text scoreText;
    public int score;

    public Slider energySlider;
    public int energy = 100;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))        {
            SceneManager.LoadScene("Menu");
        }

        //Movimiento lateral de la nave
        this.transform.position = new Vector2(this.transform.position.x + (Input.GetAxis("Horizontal") * speed), this.transform.position.y);
        if(this.transform.position.x > halfWidth) {
            this.transform.position = new Vector2(halfWidth, this.transform.position.y);
        } else if(this.transform.position.x < -halfWidth) {
            this.transform.position = new Vector2(-halfWidth, this.transform.position.y);
        }

        

        if (!barrierState && Input.GetAxis("Vertical") < 0 && energy > 0) {
            bar = (GameObject)Instantiate(barrier, new Vector2(this.transform.position.x, this.transform.position.y + .2f), Quaternion.identity);
            bar.transform.SetParent(this.transform);
            barrierState = true;
            StartCoroutine(BarrierTimer());
        } else if(barrierState && Input.GetAxis("Vertical") == 0 || energy <= 0)  {
            Destroy(bar);
            barrierState = false;
        }

        if (!ballState && Input.GetAxis("Vertical") > 0 && energy >= 20) {
            ball = (GameObject) Instantiate(energyBall, new Vector2(this.transform.position.x, this.transform.position.y + .5f), Quaternion.identity);
            ballState = true;
            energy -= 20;
        }

        //Actualiza la barra de energia
        energySlider.value = energy;

        scoreText.text = score.ToString();

        if(energy < 20 && !ballState) SceneManager.LoadScene("Menu");

    }

    IEnumerator BarrierTimer() {
        yield return new WaitForSeconds(1);
        energy--;
        if (barrierState) {
            StartCoroutine(BarrierTimer());
        } else {
            StopCoroutine(BarrierTimer());
        }
    }
}
