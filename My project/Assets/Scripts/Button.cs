using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Button : MonoBehaviour
{   
    GameObject obj;
    private bool hit;
    private bool end;
    private SpriteRenderer theSR;
    private bool subNote1;
    private bool subNote2;
    private bool subNote3;
    public GameObject goodEffect, perfectEffect, missEffect;

    void Awake() {
        theSR = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        hit = false;
        end = false;
        subNote1 = false;
        subNote2 = false;
        subNote3 = false;

    }

    void Update() {
        
    }

 
    void OnMouseDown() {  
        if (hit == true) {
            if ((subNote1 == true && subNote2 == true && subNote3 == true)) {
                // Debug.Log("Perfect");
                Score.instance.AddPerfectScore();
                Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
            } else {
                // Debug.Log("Good");
                Score.instance.AddGoodScore();
                
                Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
            }
            
            if (end == true) {
                this.Wait(2f, ShowScore);
                MusicScript.instance.DestroyMusic();
            }
            DestroyNote();

        } else {
            // Debug.Log("Bad");
            Score.instance.AddMissScore();
            
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }

    // void OnMouseUp() {
    //     }
    // }



    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Notes" || other.gameObject.tag == "LastNote") {
            hit = true;
            if (other.gameObject.tag == ("LastNote")) {
                end = true;
            }
            obj = other.gameObject;
        }

        if (other.gameObject.tag == "SubNote1") {
            subNote1 = true;
        } else if (other.gameObject.tag == "SubNote2") {
            subNote2 = true;
        } else if (other.gameObject.tag == "SubNote3") {
            subNote3 = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Notes" || other.gameObject.tag == "LastNote") {
            hit = false;
            if (other.gameObject.tag == ("LastNote")) {
                end = false;
            }
        }

        if (other.gameObject.tag == "SubNote1") {
            subNote1 = false;
        } else if (other.gameObject.tag == "SubNote2") {
            subNote2 = false;
        } else if (other.gameObject.tag == "SubNote3") {
            subNote3 = false;
        }
        
    }

    void DestroyNote() {
        Destroy(obj);
    }

    void ShowScore() {
        Score.instance.ShowScore();
    }

}
