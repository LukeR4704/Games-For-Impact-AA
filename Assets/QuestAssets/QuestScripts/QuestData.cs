using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "Scriptable Objects/QuestData")]
public class QuestData : ScriptableObject
{
    
    public string questName;
    public int questID;
    public int questStep;
    public string[] questStepDesc;

}
