using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Button : MonoBehaviour
{   
    GameObject obj;
    List<GameObject> objs = new List<GameObject>();
    private bool hit;
    public KeyCode key;
    private SpriteRenderer theSR;
    private bool subNote1;
    private bool subNote2;
    private bool subNote3;

    public ParticleSystem particEffect;
    public AudioSource soundFX;

    void Awake() {
        theSR = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        hit = false;
        subNote1 = false;
        subNote2 = false;
        subNote3 = false;

    }

    void Update() {
        if (Input.GetKeyDown(key)) {
            soundFX.Play();
            particEffect.Play();
            if (hit == true) {
                if ((subNote1 == true && subNote2 == true && subNote3 == true)) {
                    //Score.instance.ScoreCalculationCase("Perfect");
                    //Score.instance.ScoreCalculationCase("Combo");
                } else if ((subNote1 == true && subNote2 == false && subNote3 == false) || 
                            (subNote3 == true && subNote2 == false && subNote3 == false)){
                    //Score.instance.ScoreCalculationCase("Bad");
                    //Score.instance.ScoreCalculationCase("Combo");
                } else {
                    //Score.instance.ScoreCalculationCase("Good");
                    //Score.instance.ScoreCalculationCase("Combo");
                }
                DestroyNote();
                


            } else {
                GameControl.instance.HpDecrease();
                //Score.instance.ScoreCalculationCase("Miss");
                //Score.instance.ScoreCalculationCase("ResetCombo");
            }            
        }
    }
 
    void OnMouseDown() {
        soundFX.Play();
        particEffect.Play();
        if (hit == true) {
            if ((subNote1 == true && subNote2 == true && subNote3 == true)) {
                //Score.instance.ScoreCalculationCase("Perfect");
                //Score.instance.ScoreCalculationCase("Combo");
            } else if ((subNote1 == true && subNote2 == false && subNote3 == false) || 
                        (subNote3 == true && subNote2 == false && subNote3 == false)){
                //Score.instance.ScoreCalculationCase("Bad");
                //Score.instance.ScoreCalculationCase("Combo");
            } else {
                //Score.instance.ScoreCalculationCase("Good");
                //Score.instance.ScoreCalculationCase("Combo");
            }
            
            DestroyNote();
            


        } else {
            GameControl.instance.HpDecrease();
            //Score.instance.ScoreCalculationCase("Miss");
            //Score.instance.ScoreCalculationCase("ResetCombo");
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Notes" || other.gameObject.tag == "LastNote") {
            hit = true;
            
            obj = other.gameObject;
            objs.Add(obj);

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
            objs.Remove(objs[0]);
            if(objs.Count != 0) {
                hit = true;
            } else {
                hit = false;
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
        Destroy(objs[0]);
    }

    void ShowScore() {
        Score.instance.ShowScore();
    }

}