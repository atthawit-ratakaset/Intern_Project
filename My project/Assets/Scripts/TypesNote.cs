using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TypesNoteData", menuName = "My project/TypesNote", order = 0)]
public class TypesNote : ScriptableObject
{
    public Sprite defaultSprite;
    public Sprite OneTap;
    public Sprite sp1, sp2, xTap, multiTap;
}
