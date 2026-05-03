using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private float cooldownTime = 0.3f;

    public void TriggerCooldown()
    {
        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        // Disable all buttons
        foreach (Button btn in buttons)
        {
            btn.interactable = false;
        }

        yield return new WaitForSeconds(cooldownTime);

        // Re-enable all buttons
        foreach (Button btn in buttons)
        {
            btn.interactable = true;
        }
    }
}