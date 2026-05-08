using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class NpcManager : MonoBehaviour
{
    [SerializeField] private GameObject[] dialogues;
    [SerializeField] private Button talk;
    [SerializeField] private QuestData quest;
    [SerializeField] private int QuestDay;
    private RoomBrain b;
    [SerializeField] private TextBox textBox;



    private void Start()
    {

        b = GameObject.FindWithTag("RoomBrain").GetComponent<RoomBrain>();

        NpcUpdate();

        
    }

    void NpcUpdate()
    {
        if (QuestBrain.instance.optionalQuestsCleared[quest.questID - 5])
        {
            LoadDialogue(2);

        }
        else if (TimeManagerScript.Instance.currentDay >= QuestDay)
        {
            LoadDialogue(1);
        }
        else if (TimeManagerScript.Instance.currentDay <QuestDay)
        {
            QuestClearedDialogue();
        }


    }


    private void LoadDialogue(int i)
    {
        if(i == 1) { 
        foreach (GameObject d in dialogues)
        {
            d.SetActive(false);
        }
            dialogues[1].SetActive(true);

            b.brancher = dialogues[1].GetComponent<DialogueBrancher>();

            b.starter = dialogues[i].GetComponent<QuestStarter>();
            b.brancher = dialogues[i].GetComponent<DialogueBrancher>();
            talk.onClick.RemoveAllListeners();
            talk.onClick.AddListener(dialogues[i].GetComponent<DialogueBrancher>().TriggerDialogueQuest);
        }
        else if (i == 2 ){
            foreach (GameObject d in dialogues)
            {
                d.SetActive(false);
            }
            dialogues[2].SetActive(true);

            talk.onClick.RemoveAllListeners();
            talk.onClick.AddListener(dialogues[0].GetComponent<DialogueTrigger>().TriggerDialogue);
        }

    }

    void QuestClearedDialogue()
    {
        foreach (GameObject d in dialogues)
        {
            d.SetActive(false);
        }
        dialogues[0].SetActive(true);

        talk.onClick.RemoveAllListeners();
        talk.onClick.AddListener(dialogues[0].GetComponent<DialogueTrigger>().TriggerDialogue);
    }

    

}
