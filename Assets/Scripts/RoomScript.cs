using UnityEngine;
using System.Collections.Generic;
public class RoomScript : MonoBehaviour
{
    //nvmd all of this is silly
    [SerializeField] private EventItems[] day1, day2, day3, day4, day5;
    [SerializeField] private Transform npcLocation;
    [SerializeField] private TextBox textBox;
    private EventItems curEvent;
    private int curTime;
    private int curDay;
    



    void Awake()
    {
        List<EventItems[]> eventList = new List<EventItems[]>(){ day1, day2, day3, day4, day5 };
        curTime = TimeManagerScript.Instance.currentHour;
        curDay = TimeManagerScript.Instance.currentDay;

        try //exception catch to load the default room if theres no event
        {
            curEvent = eventList[curDay][curTime];
        }
        catch
        {
            curEvent = null;
        }
        if(curEvent != null)
        {
            CreateNPC();
            ChangeEnvironment();

        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //loads an npc, if there is one
    void CreateNPC()
    {
        if (curEvent.npcObj != null)
        {
            GameObject npc = Instantiate(curEvent.npcObj, npcLocation);
            //npc.GetComponentInChildren<DialogueTrigger>().textBox = textBox;

        }
        else
        {
            return;
        }
    }

    void ChangeEnvironment()
    {
        
    }


}
