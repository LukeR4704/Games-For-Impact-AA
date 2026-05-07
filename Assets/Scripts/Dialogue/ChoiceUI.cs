using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceUI : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    public bool questAvailable;
    [SerializeField] private bool bedChoice;
    [SerializeField] private bool childChoice;
    private TextBox textBox;
    private QuestStarter starter;

    public void ShowChoices(DialogueChoice[] choices, TextBox targetTextBox)
    {
        starter = GameObject.FindWithTag("RoomBrain").GetComponent<RoomBrain>().starter;
        textBox = targetTextBox;

        textBox.SetInputEnabled(false);

        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);

        if (choices.Length > 0)
        {
            leftButton.gameObject.SetActive(true);
            leftButton.GetComponentInChildren<TextMeshProUGUI>().text = choices[0].choiceText;

            leftButton.onClick.RemoveAllListeners();
            leftButton.onClick.AddListener(() => Select(choices[0]));
            if (bedChoice)
            {
                leftButton.onClick.AddListener(GoToBed);
                
            }
            if (questAvailable || childChoice)
            {
                leftButton.onClick.AddListener(AcceptQuest);

            }
        }

        if (choices.Length > 1)
        {
            rightButton.gameObject.SetActive(true);
            rightButton.GetComponentInChildren<TextMeshProUGUI>().text = choices[1].choiceText;

            rightButton.onClick.RemoveAllListeners();
            rightButton.onClick.AddListener(() => Select(choices[1]));

            if (childChoice)
            {
                rightButton.onClick.AddListener(AcceptQuest);

            }

        }

        gameObject.SetActive(true);
    }

    private void Select(DialogueChoice choice)
    {
        gameObject.SetActive(false);

        textBox.SetInputEnabled(true);
        textBox.ForceEndDialogue();

        textBox.StartDialogue(choice.nextNode.dialogue);

        // Tell TextBox / system what the next node is
        DialogueManager.Instance.SetCurrentNode(choice.nextNode);
    }

    private void AcceptQuest()
    {
        starter.StartQuest();
        questAvailable = false;
    }

    private void GoToBed()
    {

        textBox.onDialogueComplete.AddListener(TimeManagerScript.Instance.NextDay);
    }
}