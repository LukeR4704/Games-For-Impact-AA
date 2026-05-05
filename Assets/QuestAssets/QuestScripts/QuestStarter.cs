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
            textBox.onDialogueComplete.AddListener(AddQuest);

    }

    private void AddQuest()
    {
        data.questStep = 0;
        QuestBrain.instance.StartQuest(data);
        textBox.onDialogueComplete.RemoveListener(AddQuest);

    }

}
