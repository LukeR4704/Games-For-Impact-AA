using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueNode startingNode;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(startingNode);
    }
}