using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    
    private float speed = 0.2f;
    private float halfWidth = 3.3f;

    public Object energyBall;
    public Object barrier;
    public bool barrierState, ballState, canShoot = false;

    private GameObject ball, bar;

    public Text scoreText, comboText;
    public int score;

    public Slider energySlider;
    public int energy = 100;

    public int combo = 1;
    public int maxCombo = 5;

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

        if (canShoot && Input.GetAxis("Vertical") > 0 && energy >= 25) {
            if(ballState) Destroy(ball);
            ball = (GameObject)Instantiate(energyBall, new Vector2(this.transform.position.x, this.transform.position.y + .5f), Quaternion.identity);
            ballState = true;
            energy -= 25;
            canShoot = false;
            combo = 1;
        }

        if (Input.GetAxis("Vertical") <= 0) canShoot = true;

        //Actualiza la barra de energia
        energySlider.value = energy;

        switch (combo) {
            case 1:
                comboText.fontSize = 16;
                comboText.color = new Color(1.0f, 1.0f, 1.0f);
                break;
            case 2:
                comboText.fontSize = 20;
                comboText.color = new Color(1.0f, 0.96f, 0.75f);
                break;
            case 3:
                comboText.fontSize = 24;
                comboText.color = new Color(1.0f, 0.92f, 0.5f);
                break;
            case 4:
                comboText.fontSize = 28;
                comboText.color = new Color(1.0f, 0.88f, 0.25f);
                break;
            case 5:
                comboText.fontSize = 32;
                comboText.color = new Color(1.0f, 0.84f, 0.0f);
                break;
        }
        scoreText.text = score.ToString();
        comboText.text = "X " + combo.ToString();

        if (energy < 25 && !ballState) SceneManager.LoadScene("Menu");

    }

    IEnumerator BarrierTimer() {
        yield return new WaitForSeconds(1);
        if (energy - 5 > 0) {
            energy -= 5;
        } else {
            energy = 0;
        }
        if (barrierState) {
            StartCoroutine(BarrierTimer());
        } else {
            StopCoroutine(BarrierTimer());
        }
    }
}
