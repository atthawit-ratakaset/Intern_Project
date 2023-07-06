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
            hit = true;
            noteType = NoteTypes.NormalNote;
            obj = other.gameObject;
            objs.Add(obj);

        }


        switch (noteType)
        {
            case NoteTypes.NormalNote:
                if (other.gameObject.tag == "SubNote1Right")
                {
                    subNote1 = true;

                    Square.transform.localScale = new Vector3(0.35f, 0.35f, 1f);
                }
                else if (other.gameObject.tag == "SubNote2Right")
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

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "NotesRight")
        {
            objs.Remove(objs[0]);
            noteType = NoteTypes.NormalNote;
            if (objs.Count != 0)
            {
                hit = true;
            }
            else
            {
                hit = false;
                
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

        }

    }

}
