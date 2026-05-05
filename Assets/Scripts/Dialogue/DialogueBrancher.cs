using UnityEngine;

public class DialogueBrancher : MonoBehaviour
{
    public DialogueNode[] itemNodes;
    public DialogueNode[] talkNodes;
    public int itemID;
    public int questState = 0;
    [Header("Does talking initiate a quest?")]
    [SerializeField] private bool questOrigin;
    [SerializeField] private QuestStarter starter;

    private DialogueTrigger trigger;
    
    private void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
    }

    public void TriggerDialogueQuest()
    {
        trigger.startingNode = talkNodes[questState];
        trigger.TriggerDialogue();
        if (questState == 0)
        {
            starter.StartQuest();
            questState++;
        }
        

    }

    public void TriggerDialogueItem()
    {
        trigger.startingNode = itemNodes[itemID];
        trigger.TriggerDialogue();
    }


}
