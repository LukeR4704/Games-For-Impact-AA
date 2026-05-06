using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceUI : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    public bool questAvailable;
    [SerializeField] private bool bedChoice;
    private TextBox textBox;

    public void ShowChoices(DialogueChoice[] choices, TextBox targetTextBox)
    {
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
                targetTextBox.onDialogueComplete.AddListener(TimeManagerScript.Instance.NextDay);
            }
            if (questAvailable)
            {
                gameObject.GetComponent<QuestStarter>().StartQuest();
                questAvailable = false;
            }
        }

        if (choices.Length > 1)
        {
            rightButton.gameObject.SetActive(true);
            rightButton.GetComponentInChildren<TextMeshProUGUI>().text = choices[1].choiceText;

            rightButton.onClick.RemoveAllListeners();
            rightButton.onClick.AddListener(() => Select(choices[1]));
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
}