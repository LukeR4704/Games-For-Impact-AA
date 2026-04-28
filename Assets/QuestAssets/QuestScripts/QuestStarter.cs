using UnityEngine;

public class QuestStarter : MonoBehaviour
{

    public QuestData data;
    public TextBox textBox;
    public GameObject questObject;

    private void Start()
    {
        if (QuestBrain.instance.questsStarted[data.questID])
        {
            Destroy(gameObject);
        }
        textBox = GameObject.FindGameObjectWithTag("RoomBrain").GetComponent<RoomBrain>().textBox;
    }



    public void StartQuest()
    {
        if (!QuestBrain.instance.questsStarted[data.questID])
        {
            textBox.onDialogueComplete.AddListener(AddQuest);
        }
    }

    private void AddQuest()
    {
        data.questStep = 0;
        Instantiate(questObject, QuestBrain.instance.transform);
        Debug.Log("Quest started" + data.questName);
        QuestBrain.instance.activeQuests.Add(data);
        QuestBrain.instance.questsStarted[data.questID] = true;
        textBox.onDialogueComplete.RemoveListener(AddQuest);
        
        gameObject.SetActive(false);

    }

}
