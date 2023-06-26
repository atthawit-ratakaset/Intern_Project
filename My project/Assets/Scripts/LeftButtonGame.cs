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
    public GameObject Square;
    public SpriteRenderer spiteRenderer;
    public Sprite newSprite;
    public Sprite defaultSprite;

    enum NoteTypes
    {
        NormalNote
       
    }
    NoteTypes noteType = NoteTypes.NormalNote;
    

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
        
        theSR.color = Color.blue;
        Color color = theSR.material.color;
        color.a = 0.25f;
        theSR.material.color = color;

        spiteRenderer.sprite = newSprite;
        Square.transform.localScale = new Vector3(0f, 0f, 1f);

    }

    void Update() {
        if (Input.GetKeyDown(key)) {
            if (hit == true) {
                if ((subNote1 == true && subNote2 == true && subNote3 == true)) {
                    Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
                    Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
                } else if ((subNote1 == true && subNote2 == false && subNote3 == false) ||
                            (subNote3 == true && subNote2 == false && subNote1 == false)) {
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
            noteType = NoteTypes.NormalNote;
            obj = other.gameObject;
            objs.Add(obj);

        }

        switch (noteType)
        {
            case NoteTypes.NormalNote:
                if (other.gameObject.tag == "SubNote1Left")
                {
                    subNote1 = true;

                    Square.transform.localScale = new Vector3(0.35f, 0.35f, 1f);
                }
                else if (other.gameObject.tag == "SubNote2Left")
                {
                    subNote2 = true;

                    Square.transform.localScale = new Vector3(0.65f, 0.65f, 1f);
                }
                else if (other.gameObject.tag == "SubNote3Left")
                {
                    subNote3 = true;

                    spiteRenderer.sprite = defaultSprite;
                    Square.transform.localScale = new Vector3(4.5f, 4.5f, 1f);
                }
                break;

        }

    
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "NotesLeft") {
            objs.Remove(objs[0]);
            noteType = NoteTypes.NormalNote;
            if (objs.Count != 0) {
                hit = true;
            } else {
                hit = false;
                
            }
        }

        switch (noteType)
        {
            case NoteTypes.NormalNote:
                if (other.gameObject.tag == "SubNote1Left")
                {
                    subNote1 = false;
                    spiteRenderer.sprite = newSprite;
                    Square.transform.localScale = new Vector3(0.65f, 0.65f, 1f);

                }
                else if (other.gameObject.tag == "SubNote2Left")
                {
                    subNote2 = false;

                    Square.transform.localScale = new Vector3(0.35f, 0.35f, 1f);
                }
                else if (other.gameObject.tag == "SubNote3Left")
                {
                    subNote3 = false;

                    Square.transform.localScale = new Vector3(0f, 0f, 1f);
                }
                break;

        }
        

    }

    public void DestroyNote() {
        Destroy(objs[0]);
        if (hit == false)
        {
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
        }
    }


    void ShowScore() {
        Score.instance.ShowScore();
    }



}