using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NoteMissDestroy : MonoBehaviour
{   
    GameObject obj;
   
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Notes" || other.gameObject.tag == "LastNote") {
            obj = other.gameObject;
            Score.instance.AddMissNotePoint();
            GameControl.instance.CheckScene();
            Score.instance.ReSetCombo();
            if (other.gameObject.tag == "LastNote") {
                this.Wait(2f, ShowScore);
                MusicScript.instance.StopMusic();
            }
            Destroy(obj);
            // Debug.Log("Miss Notes");
        }
    }

    void ShowScore() {
        Score.instance.ShowScore();
    }

}
