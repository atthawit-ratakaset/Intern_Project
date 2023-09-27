using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoteData : MonoBehaviour
{
    public List<NoteNode> noteNodes = new List<NoteNode>();
    internal bool activeInHierarchy;

    private void Start()
    {
        noteNodes = gameObject.GetComponentsInParent<NoteNode>().ToList();
    }
}
