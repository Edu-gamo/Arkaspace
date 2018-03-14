using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedEnemy : MonoBehaviour {


    private int contadorVueltasA = 0, contadorVueltasB = 0;
    int sentidoMovimiento = 0;
    private float speed = 0.5f;
    public int hp = 3;
    private float iter = 1.8f;
    private float maxIter = 1.0f;
    private int contadorSec = 0;
    bool bolean;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(BlinkTimer());
    }

    // Update is called once per frame
    void Update()
    {

        //Movimiento descendente de la nave
    }

    IEnumerator BlinkTimer() {
        if(!bolean && contadorSec > 8) {
            iter -= 0.4f;
            bolean = true;
        }  else if (bolean && contadorSec > 20) {
            iter = maxIter;
        }
        contadorSec++;

        yield return new WaitForSeconds(iter);
        if (contadorVueltasA == 2) {
            if (contadorVueltasB == 0) {
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - speed);
                contadorVueltasB++;
            }
            else {
                if (sentidoMovimiento == 1) {
                    if (contadorVueltasB == 4) {
                        sentidoMovimiento = 0;
                        this.transform.position = new Vector2(this.transform.position.x + speed, this.transform.position.y);
                        contadorVueltasB = 0;
                    }
                    else {
                        this.transform.position = new Vector2(this.transform.position.x + speed, this.transform.position.y);
                        contadorVueltasB++;
                    }
                } else {
                    if (contadorVueltasB == 4)  {
                        sentidoMovimiento = 1;
                        this.transform.position = new Vector2(this.transform.position.x - speed, this.transform.position.y);
                        contadorVueltasB = 0;
                    }
                    else {
                        this.transform.position = new Vector2(this.transform.position.x - speed, this.transform.position.y);
                        contadorVueltasB++;
                    }
                }
            }
            StartCoroutine(BlinkTimer());
        }
        else {
            this.transform.position = new Vector2(this.transform.position.x + speed, this.transform.position.y);
            contadorVueltasA++;

            StartCoroutine(BlinkTimer());

        }
    }
}
