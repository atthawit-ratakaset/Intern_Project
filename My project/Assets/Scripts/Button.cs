using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Button : MonoBehaviour
{   
    GameObject obj;
    List<GameObject> objs = new List<GameObject>();
    int CurrenttIndex = 0;
    private bool hit;
    private bool end;
    public KeyCode key;
    private SpriteRenderer theSR;
    private bool subNote1;
    private bool subNote2;
    private bool subNote3;
    public GameObject goodEffect, perfectEffect, missEffect, badEffect;
    public ParticleSystem particEffect;

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
        transform.rotation = Quaternion.identity;

    }

    void Update() {
        if (Input.GetKeyDown(key)) {
            particEffect.Play();
            if (hit == true) {
                if ((subNote1 == true && subNote2 == true && subNote3 == true)) {
                    // Debug.Log("Perfect");
                    Score.instance.AddPerfectScore();
                    Score.instance.AddCombo();
                    Instantiate(perfectEffect, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
                } else if ((subNote1 == true && subNote2 == false && subNote3 == false) || 
                            (subNote3 == true && subNote2 == false && subNote3 == false)){
                    // Debug.Log("Good");
                    Instantiate(badEffect, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
                    Score.instance.AddBadScore();
                    Score.instance.AddCombo();
                } else {
                    Score.instance.AddGoodScore();
                    Score.instance.AddCombo();
                    Instantiate(goodEffect, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
                }
                
                if (end == true) {
                    this.Wait(2f, ShowScore);
                    MusicScript.instance.DestroyMusic();
                }
                DestroyNote();
                


            } else {
                // Debug.Log("Miss");
                Score.instance.AddMissScore();
                Instantiate(missEffect, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
                Score.instance.ReSetCombo();
            }            
        }
    }
 
    void OnMouseDown() {
        particEffect.Play();
        if (hit == true) {
            if ((subNote1 == true && subNote2 == true && subNote3 == true)) {
                // Debug.Log("Perfect");
                Score.instance.AddPerfectScore();
                Score.instance.AddCombo();
                Instantiate(perfectEffect, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
            } else if ((subNote1 == true && subNote2 == false && subNote3 == false) || 
                        (subNote3 == true && subNote2 == false && subNote3 == false)){
                // Debug.Log("Good");
                Instantiate(badEffect, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
                Score.instance.AddBadScore();
                Score.instance.AddCombo();
            } else {
                Score.instance.AddGoodScore();
                Score.instance.AddCombo();
                Instantiate(goodEffect, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
            }
            
            if (end == true) {
                this.Wait(2f, ShowScore);
                MusicScript.instance.DestroyMusic();
            }
            DestroyNote();
            


        } else {
            // Debug.Log("Miss");
            Score.instance.AddMissScore();
            Instantiate(missEffect, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
            Score.instance.ReSetCombo();
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
            objs.Add(obj);
            CurrenttIndex++;
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
            CurrenttIndex -= 1;
            objs.Remove(objs[0]);
            if(CurrenttIndex != 0) {
                hit = true;
            } else {
                hit = false;
                if (other.gameObject.tag == ("LastNote")) {
                    end = false;
                }

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