using UnityEngine;

public class QuestStarter : MonoBehaviour
{

    public QuestData data;
    public TextBox textBox;

    public void StartQuest()
    {
        if (!QuestBrain.instance.questsStarted[data.questID])
        {
            textBox.onDialogueComplete.AddListener(AddQuest);
        }
    }

    private void AddQuest()
    {
        Debug.Log("Quest started" + data.questName);
        QuestBrain.instance.activeQuests.Add(data);
        QuestBrain.instance.questsStarted[data.questID] = true;
        textBox.onDialogueComplete.RemoveListener(AddQuest);
        gameObject.SetActive(false);

    }

}
