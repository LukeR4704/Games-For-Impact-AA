using UnityEngine;

[System.Serializable]
public class DialogueNode
{
    [TextArea(3, 10)]
    public string[] dialogue;

    public DialogueChoice[] choices;
}