using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNotesSong : MonoBehaviour
{
    public List<GameObject> Notes;
    public static GetNotesSong instance;

    void Awake() {
        instance = this;    
    }
    
    public void NotesSong () {
        GetValue.Notes = Notes;
    }
}
