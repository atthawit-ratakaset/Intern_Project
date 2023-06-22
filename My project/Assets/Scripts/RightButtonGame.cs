using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButtonGame : MonoBehaviour
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

    void Awake()
    {

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
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (hit == true)
            {
                if ((subNote1 == true && subNote2 == true && subNote3 == true))
                {
                    Score.instance.ScoreCalculationCase(Score.GetScore.Perfect);
                    Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
                }
                else if ((subNote1 == true && subNote2 == false && subNote3 == false) ||
                          (subNote3 == true && subNote2 == false && subNote3 == false))
                {
                    Score.instance.ScoreCalculationCase(Score.GetScore.Bad);
                    Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
                }
                else
                {
                    Score.instance.ScoreCalculationCase(Score.GetScore.Good);
                    Score.instance.ScoreCalculationCase(Score.GetScore.Combo);
                }
                DestroyNote();



            }

        }


    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesRight")
        {
            hit = true;

            obj = other.gameObject;
            objs.Add(obj);

        }


        if (other.gameObject.tag == "SubNote1Right")
        {
            subNote1 = true;
            theSR.color = Color.white;
            Color color = theSR.material.color;
            color.a = 0.5f;
            theSR.material.color = color;
        }
        else if (other.gameObject.tag == "SubNote2Right")
        {
            subNote2 = true;
            Color color = theSR.material.color;
            color.a = 0.75f;
            theSR.material.color = color;
        }
        else if (other.gameObject.tag == "SubNote3Right")
        {
            subNote3 = true;
            Color color = theSR.material.color;
            color.a = 1f;
            theSR.material.color = color;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesRight")
        {
            objs.Remove(objs[0]);
            if (objs.Count != 0)
            {
                hit = true;
            }
            else
            {
                hit = false;
                
            }

        }

        if (other.gameObject.tag == "SubNote1Right")
        {
            subNote1 = false;
            Color color = theSR.material.color;
            color.a = 0.75f;
            theSR.material.color = color;
        }
        else if (other.gameObject.tag == "SubNote2Right")
        {
            subNote2 = false;
            Color color = theSR.material.color;
            color.a = 0.5f;
            theSR.material.color = color;
        }
        else if (other.gameObject.tag == "SubNote3Right")
        {
            subNote3 = false;
            theSR.color = Color.blue;
            Color color = theSR.material.color;
            color.a = 0.25f;
            theSR.material.color = color;
        }

    }

    public void DestroyNote()
    {
        Destroy(objs[0]);
        if (hit == false)
        {
            theSR.color = Color.blue;
            Color color = theSR.material.color;
            color.a = 0.25f;
            theSR.material.color = color;
        }
    }

    void ShowScore()
    {
        Score.instance.ShowScore();
    }


}
