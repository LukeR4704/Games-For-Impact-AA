using UnityEngine.UI;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    [SerializeField] private GameObject[] theChildren;
    [SerializeField] private Button talk;



    void OnEnable()
    {
        int d = TimeManagerScript.Instance.currentDay;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        theChildren[d].SetActive(true);

        RoomBrain b = GameObject.FindWithTag("RoomBrain").GetComponent<RoomBrain>();
        b.starter = theChildren[d].GetComponent<QuestStarter>();
        b.brancher = theChildren[d].GetComponent<DialogueBrancher>();
        talk.onClick.RemoveAllListeners();
        talk.onClick.AddListener(theChildren[d].GetComponent<DialogueBrancher>().TriggerDialogueQuest);
        
    }

}
