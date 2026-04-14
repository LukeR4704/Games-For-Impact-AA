using UnityEngine;
using System.Collections.Generic;

public class QuestLogSingleton : MonoBehaviour
{
    public static QuestLogSingleton instance;
    public List<QuestData> activeQuests = new List<QuestData>(); 


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
