using UnityEngine;

public class DialogueBrancher : MonoBehaviour
{
    public DialogueNode[] itemNodes;
    public DialogueNode[] talkNodes;
    public int itemID;
    public int questState = 0;

    private DialogueTrigger trigger;
    
    private void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
    }

    public void TriggerDialogueQuest()
    {
        trigger.startingNode = talkNodes[questState];
        trigger.TriggerDialogue();
    }

    public void TriggerDialogueItem()
    {
        trigger.startingNode = itemNodes[itemID];
        trigger.TriggerDialogue();
    }


}
