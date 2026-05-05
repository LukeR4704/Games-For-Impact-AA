using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

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
        TextMeshProUGUI logEntry;
        int logNumber = 0;
        //check if theres a main quest active
        switch (QuestBrain.instance.mainQuestState)
        {
            case 0:
                logEntry = Instantiate(questLogPrefab, questLogGrid).GetComponentInChildren<TextMeshProUGUI>();
                logEntry.text = "Check up on your son.";
                break;

            case 1:
                break;

                case 2:
                logEntry = Instantiate(questLogPrefab, questLogGrid).GetComponentInChildren<TextMeshProUGUI>();
                logEntry.text = "Turn in for the night.";
                break;
        }

        foreach(QuestData quest in QuestBrain.instance.activeQuests)
        {
            logNumber++;
            
            logEntry = Instantiate(questLogPrefab, questLogGrid).GetComponentInChildren<TextMeshProUGUI>();
            try
            {
                if (quest.isOptional)
                {
                    logEntry.text = "Optional: " + quest.questStepDesc[quest.questStep];
                }
                else
                {
                    logEntry.text = quest.questStepDesc[quest.questStep];

                }
            }
            catch
            {
                logEntry.text = quest.questName;
            }
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
