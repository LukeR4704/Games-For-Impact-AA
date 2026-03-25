using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueNode startingNode;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(startingNode);
    }
}