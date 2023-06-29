using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoteGameObject : MonoBehaviour
{
    public string targetID;

    public List<NoteInNode> noteInNodes = new List<NoteInNode>();

    public void Start()
    {
        noteInNodes = gameObject.GetComponentsInParent<NoteInNode>().ToList();
    }
}
