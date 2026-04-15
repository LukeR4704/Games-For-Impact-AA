using UnityEngine;

public class IntroController : MonoBehaviour
{
    [SerializeField] private IntroTextBox introTextBox;

    [TextArea(3,10)]
    [SerializeField] private string[] introDialogue;

    void Start()
    {
        introTextBox.StartDialogue(introDialogue);
    }
}