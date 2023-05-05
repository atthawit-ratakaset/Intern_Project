using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NoteMissDestroy : MonoBehaviour
{   
    GameObject obj;
   

    private void Start() {
        
    }

    private void Update() {

    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Notes") {
            obj = other.gameObject;
            Destroy(obj);
            Score.instance.AddMissNotePoint();
            // Debug.Log("Miss Notes");
        }
    }

}
