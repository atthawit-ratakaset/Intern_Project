using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButtonGame : MonoBehaviour
{
    GameObject obj;
    List<GameObject> objs = new List<GameObject>();
    public KeyCode key;
    private SpriteRenderer theSR;

    [HideInInspector]
    public bool hit;
    [HideInInspector]
    public bool subNote1;
    [HideInInspector]
    public bool subNote2;
    [HideInInspector]
    public bool subNote3;

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
            if (hit == true) {
                if ((subNote1 == true && subNote2 == true && subNote3 == true)) {
                    Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
                    Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
                } else if ((subNote1 == true && subNote2 == false && subNote3 == false) ||
                            (subNote3 == true && subNote2 == false && subNote3 == false)) {
                    Score.instance.ScoreCalculationCase(Score.GetScore.Bad);
                    Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
                } else {
                    Score.instance.ScoreCalculationCase(Score.GetScore.Good);
                    Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
                }
                DestroyNote();



            }
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "NotesLeft") {
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
        if (other.gameObject.tag == "NotesLeft") {
            objs.Remove(objs[0]);
            if (objs.Count != 0) {
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

    public void DestroyNote() {
        Destroy(objs[0]);
    }


    void ShowScore() {
        Score.instance.ShowScore();
    }



}