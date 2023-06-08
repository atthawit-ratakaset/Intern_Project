using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMoveMent : MonoBehaviour
{   
    public NoteSpeed noteSpeed;
    public bool Left;
    public bool Right;

    void Start()
    {
        noteSpeed = FindObjectOfType<NoteSpeed>();
    }

    void Update()
    {   
        if (Left == true)
        {
            transform.position -= new Vector3(noteSpeed.beatTempo * Time.deltaTime, 0f, 0f);
        }
        else if (Right == true)
        {

            transform.position += new Vector3(noteSpeed.beatTempo * Time.deltaTime, 0f, 0f);
        }
    }
}
