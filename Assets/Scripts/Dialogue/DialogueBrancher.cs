using UnityEngine;

public class DialogueBrancher : MonoBehaviour
{
    public DialogueNode baseNode;
    public DialogueNode[] itemNodes;
    public DialogueNode[] talkNodes;
    [HideInInspector] public int itemID;

    public int questStep = 0;
    public int[] questItem;
    

    [SerializeField] private int questDay;
    [SerializeField] private QuestStarter starter;
    [SerializeField] private bool childRoom;
    [SerializeField] private QuestData quest;


    private DialogueTrigger trigger;
    
    private void Start()
    {

        if (QuestBrain.instance.activeQuests.Contains(quest))
        {
            questStep++;
        }
        trigger = GetComponent<DialogueTrigger>();

    }

    public void TriggerDialogueQuest()
    {
        if (TimeManagerScript.Instance.currentDay < questDay && !childRoom)
        {
            trigger.startingNode = baseNode;
            trigger.TriggerDialogue();
        }
        else
        {
            trigger.startingNode = talkNodes[questStep];
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
