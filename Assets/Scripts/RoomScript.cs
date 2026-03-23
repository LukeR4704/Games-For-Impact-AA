using UnityEngine;
using System.Collections.Generic;
public class RoomScript : MonoBehaviour
{
    [SerializeField] private EventItems[] day1, day2, day3, day4, day5;
    [SerializeField] private Transform npcLocation;
    private EventItems curEvent;
    private int curTime;
    private int curDay;
    



    void Awake()
    {
        List<EventItems[]> eventList = new List<EventItems[]>(){ day1, day2, day3, day4, day5 };
        curTime = TimeManagerScript.instance.currentHour;
        curDay = TimeManagerScript.instance.currentDay;

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
            Instantiate(curEvent.npcObj, npcLocation);
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
