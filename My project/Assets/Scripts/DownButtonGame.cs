using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownButtonGame : UpButtonGame
{
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesRight")
        {
            noteType = NoteTypes.NormalNote;
            hit = true;

            spiteRenderer.sprite = newSprite;
            subNote1 = true;
            Square.transform.localScale = new Vector3(0.35f, 0.35f, 1f);
            obj = other.gameObject;
            objs.Add(obj);

        }
        else if (other.gameObject.tag == "DoubleTapNote")
        {
            noteType = NoteTypes.DoubleTapNote;
            noteSp1 = true;

            spiteRenderer.sprite = sp1;
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);

        }
        else if (other.gameObject.tag == "DonotTap")
        {
            noteType = NoteTypes.DonotTap;
            noteSp2 = true;

            spiteRenderer.sprite = xTap;
            Square.transform.localScale = new Vector3(1f, 1f, 1f);
            obj = other.gameObject;
            objs.Add(obj);

        }


        if (hit == true || noteSp1 == true)
        {
            switch (noteType)
            {
                case NoteTypes.NormalNote:
                    if (other.gameObject.tag == "SubNote2Right")
                    {
                        subNote2 = true;

                        Square.transform.localScale = new Vector3(0.65f, 0.65f, 1f);
                    }
                    else if (other.gameObject.tag == "SubNote3Right")
                    {
                        subNote3 = true;

                        spiteRenderer.sprite = defaultSprite;
                        Square.transform.localScale = new Vector3(4.5f, 4.5f, 1f);
                    }
                    break;

                case NoteTypes.DoubleTapNote:

                    break;

                case NoteTypes.DonotTap:
                    break;
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesRight")
        {
            objs.Remove(objs[0]);
            noteType = NoteTypes.NormalNote;
            spiteRenderer.sprite = defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
            if (objs.Count != 0)
            {
                hit = true;
            }
            else
            {
                hit = false;

            }
        }
        else if (other.gameObject.tag == "DoubleTapNote")
        {
            objs.Remove(objs[0]);
            hp = 2;
            noteType = NoteTypes.DoubleTapNote;
            spiteRenderer.sprite = defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
            if (objs.Count != 0)
            {
                noteSp1 = true;
            }
            else
            {
                noteSp1 = false;
                

            }
        }
        else if (other.gameObject.tag == "DonotTap")
        {
            objs.Remove(objs[0]);

            noteType = NoteTypes.DonotTap;
            spiteRenderer.sprite = defaultSprite;
            Square.transform.localScale = new Vector3(0f, 0f, 1f);
            if (objs.Count != 0)
            {
                noteSp2 = true;
            }
            else
            {
                noteSp2 = false;
                

            }
        }

        switch (noteType)
        {
            case NoteTypes.NormalNote:
                if (other.gameObject.tag == "SubNote1Right")
                {
                    subNote1 = false;
                    spiteRenderer.sprite = newSprite;
                    Square.transform.localScale = new Vector3(0.65f, 0.65f, 1f);

                }
                else if (other.gameObject.tag == "SubNote2Right")
                {
                    subNote2 = false;

                    Square.transform.localScale = new Vector3(0.35f, 0.35f, 1f);
                }
                else if (other.gameObject.tag == "SubNote3Right")
                {
                    subNote3 = false;

                    Square.transform.localScale = new Vector3(0f, 0f, 1f);
                }
                break;

            case NoteTypes.DoubleTapNote:
                if (other.gameObject.tag == "SubNote1Right")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Right")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Right")
                {
                    subNote3 = false;
                    spiteRenderer.sprite = defaultSprite;
                    Square.transform.localScale = new Vector3(0f, 0f, 1f);

                }
                break;

            case NoteTypes.DonotTap:
                if (other.gameObject.tag == "SubNote1Right")
                {
                    subNote1 = false;
                    Color color = spiteRenderer.material.color;
                    color.a = 0.75f;
                    spiteRenderer.material.color = color;

                }
                else if (other.gameObject.tag == "SubNote2Right")
                {
                    subNote2 = false;

                    Color color = spiteRenderer.material.color;
                    color.a = 0.35f;
                    spiteRenderer.material.color = color;
                }
                else if (other.gameObject.tag == "SubNote3Right")
                {
                    subNote3 = false;
                    spiteRenderer.sprite = defaultSprite;
                    Color color = spiteRenderer.material.color;
                    color.a = 1f;
                    spiteRenderer.material.color = color;
                    spiteRenderer.sprite = defaultSprite;
                    Square.transform.localScale = new Vector3(0f, 0f, 1f);

                }
                break;
        }

    }

}
