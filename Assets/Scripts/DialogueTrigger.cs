using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private TextBox textBox;

    public string[] dialogue =
    {
        "Hold it!",
        "You say you were at the crime scene at midnight.",
        "But the security logs say otherwise."
    };

    void Start()
    {
        textBox.StartDialogue(dialogue);
    }
}