using UnityEngine.UI;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    [SerializeField] private GameObject[] theChildren;
    [SerializeField] private Button talk;
    [SerializeField] private TextBox text;



    void OnEnable()
    {
        text.onDialogueComplete.AddListener(CheckForQuestComplete);
        if (QuestBrain.instance.mainQuestState != 2)
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
        else
        {
            CheckForQuestComplete();
        }
        
    }

    private void OnDisable()
    {
        text.onDialogueComplete.RemoveAllListeners();
    }

    void CheckForQuestComplete()
    {
        if (QuestBrain.instance.mainQuestState == 2)
        {
            int d = 5;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            theChildren[d].SetActive(true);

            RoomBrain b = GameObject.FindWithTag("RoomBrain").GetComponent<RoomBrain>();
            talk.onClick.RemoveAllListeners();
            talk.onClick.AddListener(theChildren[d].GetComponent<DialogueTrigger>().TriggerDialogue);
        }
    }
}
