using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    [SerializeField] private GameObject questLogPrefab;
    [SerializeField] private Transform questLogGrid;
    public bool logOpen;

    public void ToggleQuestList()
    {
        if (logOpen)
        {
            CloseList();
        }
        else
        {
            OpenList();
        }
    }

    public void OpenList()
    {
        int logNumber = 0;
        foreach(QuestData quest in QuestBrain.instance.activeQuests)
        {
            logNumber++;
            TextMeshProUGUI logEntry;
            logEntry = Instantiate(questLogPrefab, questLogGrid).GetComponentInChildren<TextMeshProUGUI>();
            logEntry.text = logNumber + ": " + quest.questStepDesc[quest.questStep];
        }
        logOpen = true;
    }

    public void CloseList()
    {
        foreach(Transform child in questLogGrid)
        {
            Destroy(child.gameObject);
        }
        logOpen = false;
    }




}
