using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    [TextArea(3, 10)]
    public string text;

    public GameObject faceToShow; // assign the face used here
}
