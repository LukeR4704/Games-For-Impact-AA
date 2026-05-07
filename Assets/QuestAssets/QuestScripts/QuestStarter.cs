using UnityEngine;

public class QuestStarter : MonoBehaviour
{

    public QuestData data;
    private TextBox textBox;
    

    private void Start()
    {
        textBox = GameObject.FindGameObjectWithTag("RoomBrain").GetComponent<RoomBrain>().textBox;
    }



    public void StartQuest()
    {
        if (!QuestBrain.instance.activeQuests.Contains(data))
        {
            textBox.onDialogueComplete.RemoveListener(AddQuest);
            textBox.onDialogueComplete.AddListener(AddQuest);
            return;
        }
        else
        {
            return;
        }


    }

    private void AddQuest()
    {
        data.questStep = 0;
        QuestBrain.instance.StartQuest(data);
        gameObject.GetComponent<DialogueBrancher>().questState++;
        textBox.onDialogueComplete.RemoveListener(AddQuest);

    }

}
