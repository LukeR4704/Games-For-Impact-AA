using UnityEngine;

[CreateAssetMenu(fileName = "EventItems", menuName = "Scriptable Objects/EventItems")]
public class EventItems : ScriptableObject
{
    //this object carries the variables needed to trigger the correct event at the correct time

    //the npc to be loaded, if applicable
    public GameObject npcObj;

    //unused for now. array of ints used to load any changes to backgrounds, etc in a room. 
    public int[] environTriggers;
}
