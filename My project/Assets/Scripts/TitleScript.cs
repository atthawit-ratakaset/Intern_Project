using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{   

    void Update() {
        MenuScene();
    }

    void MenuScene() {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(1);
        } 
    }
}
