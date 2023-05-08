using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDelay : MonoBehaviour
{
    public float DelayTime;
    public float BeatTempo;
    public bool Down;
    public bool Up;
    public bool LeftUp;
    public bool LeftDown;
    public bool RightUp;
    public bool RightDown;
    // Start is called before the first frame update
    void Start()
    {
        BeatTempo = BeatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Down == true) {
            Invoke("DelayNoteDown", DelayTime);
        } else if (Up == true) {
            Invoke("DelayNoteUp", DelayTime);
        } else if (LeftUp == true) {
            Invoke("DelayNoteLeftUp", DelayTime);
        } else if (LeftDown == true) {
            Invoke("DelayNoteLeftDown", DelayTime);
        } else if (RightUp == true) {
            Invoke("DelayNoteRightUp", DelayTime);
        } else if (RightDown == true) {
            Invoke("DelayNoteRightDown", DelayTime);
        }
    }

    void DelayNoteDown() {
        transform.position -= new Vector3(0f, BeatTempo * Time.deltaTime, 0f);
    }

    void DelayNoteUp() {
        transform.position += new Vector3(0f, BeatTempo * Time.deltaTime, 0f);
    }

    void DelayNoteLeftUp() {
        transform.position -= new Vector3((BeatTempo * Time.deltaTime), -(BeatTempo * Time.deltaTime), 0f);
    }

    void DelayNoteLeftDown() {
        transform.position += new Vector3(-(BeatTempo * Time.deltaTime), -(BeatTempo * Time.deltaTime), 0f);
    }
    
    void DelayNoteRightUp() {
        transform.position -= new Vector3(-(BeatTempo * Time.deltaTime), -(BeatTempo * Time.deltaTime), 0f);
    }

    void DelayNoteRightDown() {
        transform.position += new Vector3((BeatTempo * Time.deltaTime), -(BeatTempo * Time.deltaTime), 0f);
    }
}
