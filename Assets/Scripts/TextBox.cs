using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TextBox : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Typing")]
    [SerializeField] private float letterDelay = 0.03f;

    [Header("Input System")]
    [SerializeField] private InputActionReference clickAction;

    [Header("Events")]
    public UnityEvent onLineStart;
    public UnityEvent onLineComplete;
    public UnityEvent onDialogueComplete;

    public bool IsLastLine()
    {
        return currentLineIndex == lines.Length - 1;
    }

    private string[] lines;
    private int currentLineIndex;
    private Coroutine typingCoroutine;
    private bool isTyping;

    private void OnEnable()
    {
        clickAction.action.performed += OnClick;
        clickAction.action.Enable();
    }

    private void OnDisable()
    {
        clickAction.action.performed -= OnClick;
        clickAction.action.Disable();
    }

    public void StartDialogue(string[] dialogueLines)
    {
        lines = dialogueLines;
        currentLineIndex = 0;
        gameObject.SetActive(true);
        ShowLine();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        if (isTyping)
        {
            FinishLineInstantly();
        }
        else
        {
            AdvanceLine();
        }
    }

    private void ShowLine()
    {
        onLineStart?.Invoke();

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine(lines[currentLineIndex]));
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(letterDelay);
        }

        isTyping = false;
        onLineComplete?.Invoke();
    }

    private void FinishLineInstantly()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        dialogueText.text = lines[currentLineIndex];
        isTyping = false;
        onLineComplete?.Invoke();
    }

    private void AdvanceLine()
    {
        currentLineIndex++;

        if (currentLineIndex >= lines.Length)
        {
            EndDialogue();
        }
        else
        {
            ShowLine();
        }
    }

    private void EndDialogue()
    {
        onDialogueComplete?.Invoke();
        gameObject.SetActive(false);
    }
}