﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public void Salir() {
        Application.Quit();
    }

    public void Jugar() {
        SceneManager.LoadScene("Scene1");
    }

}
