using UnityEngine;

public class DialogueBrancher : MonoBehaviour
{
    public DialogueNode baseNode;
    public DialogueNode[] itemNodes;
    public DialogueNode[] talkNodes;
    [HideInInspector] public int itemID;
    [HideInInspector] public int questState = 0; // 0 = start quest dialogue, 1 = mid quest dialogue, 2 = finished quest dialogue
    public int[] questItem;
    

    [SerializeField] private int questDay;
    [SerializeField] private QuestStarter starter;
    [SerializeField] private bool childRoom;



    private DialogueTrigger trigger;
    
    private void Start()
    {
        

        trigger = GetComponent<DialogueTrigger>();

    }

    public void TriggerDialogueQuest()
    {
        if (TimeManagerScript.Instance.currentDay != questDay && !childRoom)
        {
            trigger.startingNode = baseNode;
        }
        else
        {
            trigger.startingNode = talkNodes[questState];
            trigger.TriggerDialogue();
        }
        

    }

    public void TriggerDialogueItem()
    {
        if (itemID == questItem[0])
        {
            trigger.startingNode = itemNodes[1];
            trigger.TriggerDialogue();
        }
        else if(itemID == questItem[1])
        {
            trigger.startingNode = itemNodes[2];
            trigger.TriggerDialogue();
        }
        else
        {
            trigger.startingNode = itemNodes[0];
            trigger.TriggerDialogue();
        }
    }


}
