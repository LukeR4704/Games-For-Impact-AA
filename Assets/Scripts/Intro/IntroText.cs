using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class IntroTextBox : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Typing")]
    [SerializeField] private float letterDelay = 0.05f;
    [SerializeField] private float lineDelay = 1.5f; // time before next line starts

    [Header("Events")]
    public UnityEvent onDialogueComplete;

    private string[] lines;
    private int currentLineIndex;
    private Coroutine typingCoroutine;

    public void StartDialogue(string[] dialogueLines)
    {
        if (dialogueLines == null || dialogueLines.Length == 0)
        {
            Debug.LogWarning("Intro dialogue is empty!");
            return;
        }

        lines = dialogueLines;
        currentLineIndex = 0;

        gameObject.SetActive(true);
        ShowLine();
    }

    private void ShowLine()
    {
        if (currentLineIndex >= lines.Length)
        {
            EndDialogue();
            return;
        }

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine(lines[currentLineIndex]));
    }

    private IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(letterDelay);
        }

        // Wait before moving to next line
        yield return new WaitForSeconds(lineDelay);

        currentLineIndex++;
        ShowLine();
    }

    private void EndDialogue()
    {
        onDialogueComplete?.Invoke();
        gameObject.SetActive(false);
    }
}