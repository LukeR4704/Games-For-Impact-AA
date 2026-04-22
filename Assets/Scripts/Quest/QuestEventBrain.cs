using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class QuestEventBrain : MonoBehaviour
{

    //This script calls events for the individual quest script to do things without needing its specific name to be called

    public UnityEvent questProg, questClose;

    public void QuestProg()
    {
        Debug.Log("Brain message! Prog quest!");
        questProg.Invoke();

    }

    public void QuestClose()
    {
        Debug.Log("Brain message! Close quest!");
        questClose.Invoke();
    }

}
