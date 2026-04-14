using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "Scriptable Objects/QuestData")]
public class QuestData : ScriptableObject
{
    
    public string questName;
    public int questStep;
    public string[] questStepDesc;

}
