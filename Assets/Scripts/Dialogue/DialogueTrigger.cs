using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private TextBox textBox;

    [TextArea(3, 10)]
    public string[] dialogue;

    [Header("Optional Choices")]
    [SerializeField] private ChoiceUI choiceUI;
    [SerializeField] private DialogueChoice leftChoice;
    [SerializeField] private DialogueChoice rightChoice;

    private bool choicesShown;

    public void TriggerDialogue()
    {
        if (textBox.IsDialogueActive())
            return;

        choicesShown = false; //reset choices so you can choose a different option
        textBox.onLineComplete.AddListener(OnLineComplete);
        textBox.StartDialogue(dialogue);
    }

    private void OnLineComplete()
    {
        if (choicesShown)
            return;

        if (!textBox.IsLastLine())
            return;

        if (choiceUI == null || leftChoice == null || rightChoice == null)
            return;

        choicesShown = true;
        choiceUI.ShowChoices(leftChoice, rightChoice, textBox);
    }
}