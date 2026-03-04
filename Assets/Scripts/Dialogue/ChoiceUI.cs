using UnityEngine;
using UnityEngine.UI;

public class ChoiceUI : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    private DialogueChoice leftChoice;
    private DialogueChoice rightChoice;
    private TextBox textBox;

    public void ShowChoices(DialogueChoice left, DialogueChoice right, TextBox targetTextBox)
    {
        leftChoice = left;
        rightChoice = right;
        textBox = targetTextBox;

        leftButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = left.choiceText;
        rightButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = right.choiceText;

        leftButton.onClick.RemoveAllListeners();
        rightButton.onClick.RemoveAllListeners();

        leftButton.onClick.AddListener(() => SelectChoice(leftChoice));
        rightButton.onClick.AddListener(() => SelectChoice(rightChoice));

        gameObject.SetActive(true);
    }

    private void SelectChoice(DialogueChoice choice)
    {
        gameObject.SetActive(false);
        textBox.StartDialogue(choice.nextDialogue);
    }
}