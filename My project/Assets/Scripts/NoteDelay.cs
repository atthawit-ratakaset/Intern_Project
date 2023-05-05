using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDelay : MonoBehaviour
{
    public float DelayTime;
    public float BeatTempo;
    // Start is called before the first frame update
    void Start()
    {
        BeatTempo = BeatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DelayNote", DelayTime);
    }

    void DelayNote() {
        transform.position -= new Vector3(0f, BeatTempo * Time.deltaTime, 0f);
    }
}
