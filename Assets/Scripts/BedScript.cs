using UnityEngine;

public class BedScript : MonoBehaviour
{
    public DialogueNode[] bedText;


    public void BedClick()
    {
        DialogueTrigger trigger = gameObject.GetComponent<DialogueTrigger>();
        int c = QuestBrain.instance.mainQuestState;
        
        trigger.startingNode = bedText[c];
        trigger.TriggerDialogue();

    }


}
