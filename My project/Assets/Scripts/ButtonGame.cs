using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonGame : MonoBehaviour
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

        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
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
                    Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
                    Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
                } else if ((subNote1 == true && subNote2 == false && subNote3 == false) || 
                            (subNote3 == true && subNote2 == false && subNote3 == false)){
                    Score.instance.ScoreCalculationCase(Score.GetScore.Bad);
                    Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
                } else {
                    Score.instance.ScoreCalculationCase(Score.GetScore.Good);
                    Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
                }
                DestroyNote();
                


            } else {
                GameControl.instance.HpDecrease();
                Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
                Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
            }            
        }


    }


    public void OnPointerDownDelegate(PointerEventData data)
    {
        soundFX.Play();
        particEffect.Play();
        if (hit == true) {
            if ((subNote1 == true && subNote2 == true && subNote3 == true)) {
                Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
                Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            } else if ((subNote1 == true && subNote2 == false && subNote3 == false) || 
                        (subNote3 == true && subNote2 == false && subNote3 == false)){
                Score.instance.ScoreCalculationCase(Score.GetScore.Bad);
                Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            } else {
                Score.instance.ScoreCalculationCase(Score.GetScore.Good);
                Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
            }
            
            DestroyNote();
            


        } else {
            GameControl.instance.HpDecrease();
            Score.instance.ScoreCalculationCase(Score.GetScore.Miss);
            Score.instance.ScoreCalculationCase(Score.GetScore.ResetCombo);
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