using UnityEngine;
using System.Collections.Generic;

public class QuestBrain : MonoBehaviour
{
    
    public static QuestBrain instance;
    public List<QuestData> activeQuests = new List<QuestData>();
    public List<GameObject> activeQuestObjs = new List<GameObject>();
    public bool[] StartedQuests;
    public GameObject[] questCatalogue;
    public int mainQuestState = 0; //0 = not started, 1 = active, 2 = finished
    public bool[] optionalQuestsCleared; 



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            
        }

        else if (instance != this)
        {
            Destroy(this);
        }

        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        TimeManagerScript.Instance.passDay.AddListener(ClearLog);
    }

    private void ClearLog()
    {
        mainQuestState = 0;
        activeQuestObjs.Clear();
        activeQuests.Clear();

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void StartQuest(QuestData quest)
    {
        activeQuests.Add(quest);
        StartedQuests[quest.questID] = true;
        Instantiate(questCatalogue[quest.questID], transform);
    }




}
