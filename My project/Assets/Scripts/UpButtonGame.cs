using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpButtonGame : MonoBehaviour
{

    public KeyCode key;
    private SpriteRenderer theSR;
    public GameObject Square;
    public SpriteRenderer spiteRenderer;
    public Sprite newSprite;
    public Sprite defaultSprite;
    public Sprite sp1, sp2, xTap;

    [HideInInspector]
    public enum NoteTypes
    {
        NormalNote,
        DoubleTapNote,
        DonotTap
       
    }

    [HideInInspector]
    public NoteTypes noteType;
    

    [HideInInspector]
    public bool hit, subNote1, subNote2, subNote3, noteSp1, noteSp2;

    [HideInInspector]
    public int hp = 2;

    [HideInInspector]
    public GameObject obj;

    [HideInInspector]
    public List<GameObject> objs = new List<GameObject>();

    void Awake() {

        theSR = GetComponent<SpriteRenderer>();
    }

    void Start()
    {   
       
        hit = false;
        noteSp1 = false;
        noteSp2 = false;

        subNote1 = false;
        subNote2 = false;
        subNote3 = false;
        
        theSR.color = Color.blue;
        Color color = theSR.material.color;
        color.a = 0.25f;
        theSR.material.color = color;

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
            noteType = NoteTypes.NormalNote;
            hit = true;
            Color color = spiteRenderer.material.color;
            color.a = 1f;
            spiteRenderer.material.color = color;
            spiteRenderer.sprite = newSprite;
            subNote1 = true;
            Square.transform.localScale = new Vector3(0.35f, 0.35f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
            
        } else if (other.gameObject.tag == "DoubleTapNoteUp")
        {
            noteType = NoteTypes.DoubleTapNote;
            noteSp1 = true;
            Color color = spiteRenderer.material.color;
            color.a = 1f;
            spiteRenderer.material.color = color;
            spiteRenderer.sprite = sp1;
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);
            
        } else if (other.gameObject.tag == "DonotTapUp")
        {
            noteType = NoteTypes.DonotTap;
            noteSp2 = true;
            Color color = spiteRenderer.material.color;
            color.a = 1f;
            spiteRenderer.material.color = color;
            spiteRenderer.sprite = xTap;
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);

        }


        if ((hit == true && subNote1 == true) || (noteSp1 == true && subNote1 == false))
        {
            switch (noteType)
            {
                case NoteTypes.NormalNote:
                    if (other.gameObject.tag == "SubNote2Left")
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

                case NoteTypes.DoubleTapNote:
                    if (other.gameObject.tag == "SubNote2Left")
                    {
                        
                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Left")
                    {

                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    break;

                case NoteTypes.DonotTap:
                    if (other.gameObject.tag == "SubNote2Left")
                    {

                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Left")
                    {

                        Square.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    break;
            }
        }


    }


    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "NotesLeft") {
            objs.Remove(objs[0]);
            
            if (objs.Count != 0) {
                hit = true;
            } else {
                hit = false;
                noteType = NoteTypes.NormalNote;
                spiteRenderer.sprite = defaultSprite;
                Square.transform.localScale = new Vector3(0f, 0f, 1f);

            }
        } else if (other.gameObject.tag == "DoubleTapNoteUp")
        {
            objs.Remove(objs[0]);
            hp = 2;
            noteType = NoteTypes.DoubleTapNote;
            
            if (objs.Count != 0)
            {
                noteSp1 = true;
            }
            else
            {
                noteSp1 = false;
                spiteRenderer.sprite = defaultSprite;
                Square.transform.localScale = new Vector3(0f, 0f, 1f);

            }
        }
        else if (other.gameObject.tag == "DonotTapUp")
        {
            objs.Remove(objs[0]);
            
            noteType = NoteTypes.DonotTap;

            if (objs.Count != 0)
            {
                noteSp2 = true;
            }
            else
            {
                noteSp2 = false;
                spiteRenderer.sprite = defaultSprite;
                Square.transform.localScale = new Vector3(0f, 0f, 1f);

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

            case NoteTypes.DoubleTapNote:
                if (other.gameObject.tag == "SubNote1Left")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Left")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Left")
                {
                    subNote3 = false;
                    spiteRenderer.sprite = defaultSprite;
                    Color color = spiteRenderer.material.color;
                    color.a = 1f;
                    spiteRenderer.material.color = color;
                    Square.transform.localScale = new Vector3(0f, 0f, 1f);

                }
                break;

            case NoteTypes.DonotTap:
                if (other.gameObject.tag == "SubNote1Left")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Left")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Left")
                {
                    subNote3 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 1f;
                    spiteRenderer.material.color = color;
                    spiteRenderer.sprite = defaultSprite;
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
        else if (noteSp1 == false)
        {
            spiteRenderer.sprite = defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
        } else if (noteSp2 == false)
        {
            spiteRenderer.sprite = defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
        }
    }


    void ShowScore() {
        Score.instance.ShowScore();
    }



}