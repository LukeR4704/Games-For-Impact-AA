using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class QuestBrain : MonoBehaviour
{
    public static QuestBrain instance;
    public List<QuestData> activeQuests = new List<QuestData>();
    public List<GameObject> activeQuestObjs = new List<GameObject>();
    public bool[] questsStarted;



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




}
