using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Button : MonoBehaviour
{   
    GameObject obj;
    private bool hit;
    private SpriteRenderer theSR;
    private bool subNote1;
    private bool subNote2;
    private bool subNote3;

    void Awake() {
        theSR = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        subNote1 = false;
        subNote2 = false;
        subNote3 = false;

    }

    void Update() {
        
    }

 
    void OnMouseDown() {  
        if (hit == true) {
            if ((subNote1 == true && subNote2 == true && subNote3 == true)) {
                Debug.Log("Perfect");
                Score.instance.AddPerfectScore();
            } else {
                Debug.Log("Good");
                Score.instance.AddGoodScore();
            }
            DestroyNote();
        } else {
            Debug.Log("Bad");
            Score.instance.AddMissScore();
        }
    }

    // void OnMouseUp() {
    //     }
    // }



    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Notes") {
            hit = true;
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
        if (other.gameObject.tag == "Notes") {
            hit = false;
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


}
