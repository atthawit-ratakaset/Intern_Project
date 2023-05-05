using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Button : MonoBehaviour
{   
    GameObject obj;
    private bool hit;
    private SpriteRenderer theSR;
    public float pos1;
    public float pos2;

    void Awake() {
        theSR = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        hit = false;

    }

    void Update() {
        
    }

 
    void OnMouseDown() {  
        if (hit == true) {
            Debug.Log(obj.transform.position.y);
            if (obj.transform.position.y > pos1 && obj.transform.position.y < pos2) {
                // Debug.Log("Perfect");
                Score.instance.AddPerfectScore();
            } else {
                Debug.Log("Good");
                Score.instance.AddGoodScore();
            }
            DestoryNote();
        }else {
            // Debug.Log("Miss");
            Score.instance.AddMissScore();
        }
    }

    // void OnMouseUp() {
    //     if (hit == true) {
    //         if (Mathf.Abs(obj.transform.position.y) > pos) {
    //             Debug.Log("Good");
    //         } else {
    //             Debug.Log("Perfect");
    //         }
    //         DestoryNote();
    //     }
    // }



    void OnTriggerEnter2D(Collider2D other) {
        hit = true;
        if (other.gameObject.tag == "Notes") {
            obj = other.gameObject;
        }
    }
    
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Notes") {
            hit = false;
        }
        
    }

    void DestoryNote() {
        Destroy(obj);
    }


}
