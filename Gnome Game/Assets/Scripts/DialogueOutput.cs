using System.Collections;
using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using UnityEngine;

public class DialogueOutput : MonoBehaviour, IDialogueActor
{
    public string outputString;
    public Texture2D portrait
    {
        get;
    }
    public Sprite portraitSprite
    {
        get;
    }
    public Color dialogueColor
    {
        get;
    }
    public Vector3 dialoguePosition
    {
        get;
    }
}
