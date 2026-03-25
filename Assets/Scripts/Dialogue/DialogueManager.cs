using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private TextBox textBox;
    [SerializeField] private ChoiceUI choiceUI;

    private DialogueNode currentNode;

    private void Awake()
    {
        Instance = this;
    }

    public void StartDialogue(DialogueNode node)
    {
        currentNode = node;

        textBox.onLineComplete.AddListener(CheckForChoices);
        textBox.StartDialogue(node.dialogue);
    }

    public void SetCurrentNode(DialogueNode node)
    {
        currentNode = node;
    }

    private void CheckForChoices()
    {
        if (!textBox.IsLastLine())
            return;

        if (currentNode.choices == null || currentNode.choices.Length == 0)
            return;

        choiceUI.ShowChoices(currentNode.choices, textBox);
    }
}